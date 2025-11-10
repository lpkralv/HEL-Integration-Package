using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;

// Add the namespace where HELAssetLoader and Mod are declared if necessary, e.g.:
// using YourNamespaceForHEL;

using statsDictionary = System.Collections.Generic.Dictionary<string, Stat>;
using modsDictionary = System.Collections.Generic.Dictionary<string, Mod>;


public partial class HIOXModEditor : Form
{
    // Screen is divided into 4 regions. 
    // Constants for layout proportions
    private const string version = "0.9";
    private const int WindowHeight = 800;
    private const int WindowWidth = 1200;
    private const double MarginSizePct = 0.01; // 2% - Outer window margin as a portion of window width.
    private const double PaddingSizePct = 0.0; // 1% - Padding between regions as a portion of width.
    private const string TitleText = "HIOX Mods Editor/Evaluator";
    private const double SplitXPct = 0.7; // 70% - Portion of width for left regions.
    private const double SplitYLeftPct = 0.7; // 70% - Portion of height for top-left region.
    private const double SplitYRightPct = 0.5; // 50% - Portion of height for top-right region.
    private const string modsYAMLFilePath = "ModsData.asset"; // Adjust path as needed.
    private const string modsCSVFilePath = "ModsData.csv"; // Adjust path as needed.
     private const string statsYAMLFilePath = "StatsData.asset"; // Adjust path as needed.
    private const string statsCSVFilePath = "StatsData.csv"; // Adjust path as needed.

    // UI Window Regions
    private Panel displayRegion = null!;
    private Label titleLabel = null!;
   //Internal storage for Mod definitions.
    private modsDictionary modsDict = null!;      // Storage of Mods data for manipulation
    private statsDictionary statsDict = null!; // Storage of Stats data for manipulation
    private List<string> statsOrder = null!;       // Remember the load order of stats to display in this order

    // Player's equipped mods (UUID -> Mod)
    private Dictionary<string, Mod> playerEquippedMods = new();

    // Application STATE
    private bool unsavedChanges = false;

   

//-----------------------------------------------------------------------------------------------------
    const int WM_SETREDRAW = 0x0B;
    
    [DllImport("user32.dll", CharSet = CharSet.Auto)]
    private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);

    private void SuspendDrawing(Control target)
    {
        SendMessage(target.Handle, WM_SETREDRAW, IntPtr.Zero, IntPtr.Zero);
    }

    private void ResumeDrawing(Control target)
    {
        SendMessage(target.Handle, WM_SETREDRAW, new IntPtr(1), IntPtr.Zero);
        target.Refresh();
    }
//-------------------------------------------------------------------------------------------------

    // Main entry point
    [STAThread]
    public static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(new HIOXModEditor());
    }

    public HIOXModEditor()
    {
        // Load the data
        LoadMods();
        LoadStats();

        // Set up the main form
        this.Text = "HIOX Mods Editor";
        this.ClientSize = new Size(WindowWidth, WindowHeight);
        this.FormBorderStyle = FormBorderStyle.Sizable;
        this.StartPosition = FormStartPosition.CenterScreen;
        this.Resize += OnFormResize;
        this.FormClosing += HIOXModEditor_FormClosing;


        // Initialize UI regions
        InitializeUI();

        // Populate the main display with mods from the asset file
        PopulateMainDisplayWithMods(true);

        // Display Base Stats
        DisplayStats(statsDict, default, true);

        // Clear Input Text Fields
        ClearInputFields();

        // Initialize Analysis
        InitializeAnalysis();
    }

    private void InitializeUI()
    {
        double margin = MarginSizePct * this.ClientSize.Width;
        double padding = PaddingSizePct * this.ClientSize.Width;
        int splitX = (int)(SplitXPct * this.ClientSize.Width);
        int  splitYLeft = (int)(SplitYLeftPct * this.ClientSize.Height);
        int  splitYRight = (int)(SplitYRightPct * this.ClientSize.Height);

    
        InitializeMainDisplay(margin, splitYLeft, splitX, padding);
 
        InitializeCommandsNMessages(margin, splitYLeft, splitX);
        
        InitializeInputRegion(margin, splitYRight, splitX);

        InitializeStatsRegion(margin, splitYRight, splitX);
    }

    private void OnFormResize(object? sender, EventArgs e)
    {
        int margin = (int)(MarginSizePct * this.ClientSize.Width);
        int padding = (int)(PaddingSizePct * this.ClientSize.Width);
        int splitX = (int)(SplitXPct * this.ClientSize.Width);
        int splitYLeft = (int)(SplitYLeftPct * this.ClientSize.Height);
        int splitYRight = (int)(SplitYRightPct * this.ClientSize.Height);

        UpdateDisplayRegion(margin, padding, splitYLeft, splitYRight, splitX);
        UpdateCommandRegion(margin, padding, splitYLeft, splitYRight, splitX);
        UpdateInputRegion(margin, padding, splitYLeft, splitYRight, splitX);
        UpdateStatsRegion(margin, padding, splitYLeft, splitYRight, splitX);
    }

    private void LoadMods()
    {
        var t = HELYAMLFile.LoadAsset(modsYAMLFilePath, "mods:");
        modsDict = (modsDictionary) t.Item1;
    }

    private void LoadStats()
    {
        var t = HELYAMLFile.LoadAsset(statsYAMLFilePath, "stats:");
        statsDict = (statsDictionary) t.Item1;
        statsOrder = (List<string>) t.Item2!;
    }

    private void HIOXModEditor_FormClosing(object? sender, FormClosingEventArgs e)
    {
        if (unsavedChanges &&
            ConfirmDialog($"WARNING: You have unsaved changes? Save them to {modsYAMLFilePath}?", "Save Changes", "Save", "Discard Changes")) {
            HELYAMLFile.WriteAsset(modsYAMLFilePath, modsDict);
        }
    }
}
