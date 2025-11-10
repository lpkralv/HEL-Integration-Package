using System.IO;
using System.Windows.Forms;
    
// Members and methods related to Command Buttons
public partial class HIOXModEditor : Form
{
    private Panel commandRegion = null!;
    private FlowLayoutPanel buttonArea = null!;
    private RichTextBox messageArea = null!;

    private bool HELP_IS_ON = false;


    private void InitializeCommandsNMessages(double margin, int splitYLeft, int splitX)
    {
        // Command Region
        commandRegion = new Panel
        {
            Bounds = new Rectangle((int)margin, splitYLeft + (int)margin, splitX - 2 * (int)margin, this.ClientSize.Height - splitYLeft - 2 * (int)margin),
            BackColor = Color.LightYellow
        };
        this.Controls.Add(commandRegion);

        // Create a TableLayoutPanel to divide the command region
        var layoutPanel = new TableLayoutPanel
        {
            Dock = DockStyle.Fill,
            RowCount = 2,
            ColumnCount = 1,
        };
        layoutPanel.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;

        // Define explicit RowStyles
        layoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 125));  // Fixed height for buttonArea
        layoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 75));  // Remaining space for messageArea

        //Console.WriteLine($"Row 0 Style: {layoutPanel.RowStyles[0].Height}");
        //Console.WriteLine($"Row 1 Style: {layoutPanel.RowStyles[1].Height}");


        // Create buttonArea
        // buttonArea = new FlowLayoutPanel
        // {
        //     Dock = DockStyle.Fill,
        //     AutoScroll = true,
        //     FlowDirection = FlowDirection.LeftToRight,
        //     WrapContents = true,
        //     BackColor = Color.LightBlue // Temporary background for debugging
        // };

        // Add buttons to buttonArea
        InitializeButtonRegion();

        // Create messageArea
        messageArea = new RichTextBox
        {
            Multiline = true,
            ReadOnly = true,  // Ensures the text cannot be edited by the user.
            ScrollBars = RichTextBoxScrollBars.Vertical,
            Dock = DockStyle.Fill,
            Margin = new Padding(0),   // Remove outer margin.
            Padding = new Padding(0),  // Remove inner padding.
            Text = $"HIOX Mod Editor version {version}\r",
            BackColor = Color.LightGray
        };


        // Add controls to layoutPanel
        layoutPanel.Controls.Add(buttonArea, 0, 0); // Add buttonArea to the first row
        layoutPanel.Controls.Add(messageArea, 0, 1); // Add messageArea to the second row

        // Add layoutPanel to commandRegion
        commandRegion.Controls.Add(layoutPanel);

    }

    private void UpdateCommandRegion(int margin, int padding, int splitYLeft, int splitYRight, int splitX)
    {
        // Adjust Command Region
        commandRegion.Bounds = new Rectangle(
            margin,
            splitYLeft + margin,
            splitX - 2 * margin,
            this.ClientSize.Height - splitYLeft - 2 * margin
        );
        messageArea.Bounds = new Rectangle(
            padding,
            buttonArea.Bottom + padding,
            commandRegion.Width - 2 * padding,
            commandRegion.Height - buttonArea.Height - 3 * padding
        );
    }


    private void WriteMessage(string message, Color? color = null, Font? customFont = null, FontStyle style = FontStyle.Regular)
    {
        // Append a new line at the end of the message.
        string fullMessage = ((message[^1] != '~') ? message + Environment.NewLine : message[0..^1]);

        // Use the provided color or fall back to the control's ForeColor.
        Color msgColor = color ?? messageArea.ForeColor;
        // Use the provided font or fall back to the control's Font.
        Font msgFont = customFont ?? messageArea.Font;

        // Move selection to the end.
        messageArea.SelectionStart = messageArea.TextLength;
        messageArea.SelectionLength = 0;

        // Apply the desired formatting.
        messageArea.SelectionColor = msgColor;
        messageArea.SelectionFont = new Font(msgFont, style);
        
        // Append the text.
        messageArea.AppendText(fullMessage);

        // Reset selection formatting (optional).
        messageArea.SelectionColor = messageArea.ForeColor;
        messageArea.SelectionFont = messageArea.Font;

        // Auto-scroll: move caret to the end and scroll to caret.
        messageArea.SelectionStart = messageArea.TextLength;
        messageArea.ScrollToCaret();
    }

    private void InitializeButtonRegion()
    {
        // Create the FlowLayoutPanel for buttons
        buttonArea = new FlowLayoutPanel
        {
            Dock = DockStyle.Fill,                // Fill the button region
            AutoScroll = true,                   // Enable scrolling if needed
            FlowDirection = FlowDirection.LeftToRight, // Arrange buttons left-to-right
            WrapContents = true                  // Allow buttons to wrap to the next line
        };

        // Add buttons to the FlowLayoutPanel
        AddButtons(buttonArea);

        // Add the button area to the command region
        commandRegion.Controls.Add(buttonArea);
    }

    // Add buttons dynamically
    private void AddButtons(FlowLayoutPanel buttonArea)
    {
        // Define button groups (Each array represents a new row)
        string[][] buttonGroups =
        {
            // The blank buttons at the end of each row help to correct button wrapping when window is stretched larger.
            new[] { "SELECT ALL", "UNSELECT", "---", "EQUIP", "UNEQUIP", "---", "SORT ID", "SORT NAME", "SORT EQUIP", "HELP OFF", "", "", "", "", "", "" },
            new[] { "COPY", "UPDATE", "ADD NEW", "DELETE", "---", "CLEAR INPUT", "---", "RESET STATS", "", "CLEAR_MSGS", "", "", "", "", "", "" },
            new[] { "CHECK", "EVALUATE", "ANALYZE", "---","CSV SAVE", "CSV LOAD", "YAML SAVE", "YAML LOAD", "---", ""}
        };
        buttonArea.Padding = new Padding(0); // Remove extra padding
        buttonArea.Margin = new Padding(0);  // Ensure tight layout

        foreach (string[] group in buttonGroups)
        {
            FlowLayoutPanel buttonRow = new FlowLayoutPanel
            {
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                FlowDirection = FlowDirection.LeftToRight,
                WrapContents = false,
                Margin = new Padding(0, 3, 0, 3),  // Reduce vertical spacing
                Padding = new Padding(0),          // Remove extra padding inside rows
                Anchor = AnchorStyles.Left | AnchorStyles.Top
            };

            foreach (string name in group)
            {
 
                if (string.IsNullOrEmpty(name))
                {
                    // Create a Panel instead of a Button to reserve space.
                    Panel dummyPanel = new Panel
                    {
                        // Match margins/padding so it lines up with other controls
                        Margin = new Padding(4, 2, 4, 2),
                        Width = 50,  // match approximate button width
                        Height = 25, // match approximate button height
                    };
                    buttonRow.Controls.Add(dummyPanel);
                }
                else
                {
                    // Normal button creation
                    Button button = new Button
                    {
                        Text = name,
                        AutoSize = true,
                        Margin = new Padding(2, 1, 2, 1) // Keep horizontal spacing, reduce vertical spacing
                    };
                    // Attach the Click event handler
                    button.Click += Button_Click;
                    button.MouseHover += Button_MouseHover;
                    
                    buttonRow.Controls.Add(button);
                }
            }

            buttonArea.Controls.Add(buttonRow);
        }
    }

    private void Button_Click(object? sender, EventArgs e)
    {
        if (sender is Button clickedButton)
        {
            string buttonText = clickedButton.Text;
            //WriteMessage($"Button clicked: {buttonText}");
            Mod? m;
            int modid;

            // Add logic based on button text
            switch (buttonText)
            {
                case "SELECT ALL":
                    markIndices = new Dictionary<int, int>();
                    // Set all mods to count 1
                    foreach (var mod in modsDict.Values)
                    {
                        markIndices[mod.modid] = 1;
                    }
                    previousMarkIndices = new Dictionary<int, int>();
                    // Redraw the entire mainDisplay with the updated selection
                    DisplayAllMods();
                    break;
                case "UNSELECT":
                    markIndices = new Dictionary<int, int>();
                    previousMarkIndices = new Dictionary<int, int>();
                    // Redraw the entire mainDisplay with the updated selection
                    DisplayAllMods();
                    break;
                case "EQUIP":
                    // Add marked mods to playerEquippedMods
                    foreach (var kvp in markIndices)
                    {
                        if (kvp.Value > 0)
                        {
                            var mod = modsDict.Values.FirstOrDefault(m => m.modid == kvp.Key);
                            if (mod != null)
                            {
                                playerEquippedMods[mod.uuid] = mod;
                            }
                        }
                    }
                    markIndices = previousMarkIndices = new Dictionary<int, int>();
                    DisplayAllMods();
                    break;
                case "UNEQUIP":
                    // Remove marked mods from playerEquippedMods
                    var modsToUnequip = new List<int>(markIndices.Keys);
                    foreach (int modId in modsToUnequip)
                    {
                        var mod = modsDict.Values.FirstOrDefault(m => m.modid == modId);
                        if (mod != null)
                        {
                            playerEquippedMods.Remove(mod.uuid);
                        }
                    }
                    // Don't clear markIndices - keep the selection
                    // Re-render the unequipped lines (they should show as green now)
                    foreach (int modId in modsToUnequip) {
                        int line = MapMod2Line(modId);
                        if (line != int.MaxValue)
                            RenderModLine(line);
                    }
                    break;
                case "SORT ID":
                    markIndices = previousMarkIndices = new Dictionary<int, int>();
                    SortModsByModID();
                    break;
                case "SORT NAME":
                    markIndices = previousMarkIndices = new Dictionary<int, int>();
                    SortModsByName();
                    break;
                case "SORT EQUIP":
                    markIndices = previousMarkIndices = new Dictionary<int, int>();
                    StableSortModsByPlayerMembership();
                    break;
                case "HELP OFF":
                    WriteMessage("HELP is ON.");
                    clickedButton.Text = "HELP ON";
                    HELP_IS_ON = true;
                    break;
                case "HELP ON":
                    WriteMessage("HELP is OFF.");
                    clickedButton.Text = "HELP OFF";
                    HELP_IS_ON = false;
                    break;

                case "COPY":
                    int modID = GetFirstSelectedModID();
                    if (modID >= 0)
                    {
                        var mod = modsDict.Values.FirstOrDefault(m => m.modid == modID);
                        if (mod != null) CopyMod2InputFields(mod);
                    }
                    break;
                case "UPDATE":
                    m = ReadInputFields();
                    if (m is not null) {
                        if (GetFirstSelectedModID() == GetEditedModID()
                            && ConfirmDialog($"Replace MOD {m.modid} '{m.name}' with edited value?", "Replace MOD?", "Replace")) 
                        {
                            unsavedChanges = true;
                            // Find the existing mod and update it using its UUID
                            var existingMod = modsDict.Values.FirstOrDefault(mod => mod.modid == m.modid);
                            if (existingMod != null)
                            {
                                m.uuid = existingMod.uuid; // Preserve the UUID
                                modsDict[m.uuid] = m;
                            }
                            int line = MapMod2Line(m.modid);
                            RenderModLine(line);
                            WriteMessage($"MOD {m.modid} UPDATED: {m.modid} '{m.name}'.");
                        }
                    } else {
                        modid = GetEditedModID();
                        WriteMessage($"ERROR: MOD {(modid == -1 ? "" : modid)} could not be UPDATED.", Color.Red);
                    }
                    break;
                case "ADD NEW":
                    m = ReadInputFields();
                    if (m is not null && m.modid > 0)
                    {
                        if (modsDict.Values.Any(mod => mod.modid == m.modid)) {
                            if (!ConfirmDialog($"MOD {m.modid} ALREADY exists. Overwrite it?", "MOD Exists...", "Overwrite!", "Cancel"))
                                break;
                        }
                        unsavedChanges = true;
                        // Generate UUID for new mod
                        if (string.IsNullOrEmpty(m.uuid))
                        {
                            m.uuid = $"uuid-{m.modid}-{System.Guid.NewGuid().ToString("N")[..6]}";
                        }
                        int lineno = modLineMap[m.modid] = modsDict.Count();
                        modsDict[m.uuid] = m;
                        previousMarkIndices = markIndices;
                        markIndices = new Dictionary<int, int> { { m.modid, 1 } };
                        DisplayAllMods();
                    }
                    break;
                case "DELETE":
                    if (markIndices.Count == 0)
                        Console.Beep();
                    else if (ConfirmDialog($"Delete {markIndices.Count} MODs?", "Delete MODs", "DELETE", "Cancel")) {
                        unsavedChanges = true;
                        foreach (int modId in markIndices.Keys) {
                            if (! modLineMap.Remove(modId) )
                                Console.Beep();
                            var modToDelete = modsDict.Values.FirstOrDefault(m => m.modid == modId);
                            if (modToDelete == null || !modsDict.Remove(modToDelete.uuid))
                                Console.Beep();
                        }
                        markIndices.Clear();
                        DisplayAllMods();
                    }
                    break;
                case "CHECK":
                    CheckAllMods();
                    break;
                case "EVALUATE":
                    EvaluateSelectedMods();
                    break;
                case "ANALYZE":
                    AnalyzeAllMods();
                    break;
                case "CLEAR INPUT":
                    ClearInputFields();
                    break;
                case "CSV SAVE":
                    if (ConfirmFileOverwrite(modsCSVFilePath))
                        HELCSVFile.WriteAsset(modsCSVFilePath, modsDict);
                    break;
                case "CSV LOAD":
                    PopulateMainDisplayWithMods(false /*YAML*/); //function checks for overwrite
                    break;
                case "YAML SAVE":
                    if (ConfirmFileOverwrite(modsYAMLFilePath))
                        HELYAMLFile.WriteAsset(modsYAMLFilePath, modsDict);
                    break;
                case "YAML LOAD":
                    PopulateMainDisplayWithMods(true /*YAML*/); //function checks for overwrite
                    break;
                case "---":
                    break;
                case "CLEAR MSGS":
                    messageArea.Clear();
                    break;
                case "RESET STATS":
                    DisplayStats(statsDict, default, true);
                    break;

                default:
                    //MessageBox.Show($"Unhandled button: {buttonText}");
                    WriteMessage($"Unhandled button {buttonText}", Color.Red);
                    break;
            }
        }
    }

    private void Button_MouseHover(object? sender, EventArgs e)
    {
        if (sender is Button button && HELP_IS_ON)
        {
            string s = "";

            switch (button.Text)
            {
                case "SELECT ALL":
                    s = "Selects ALL Mods (green or yellow). Click or Drag-Click to select specific.";
                    break;
                case "UNSELECT":
                    s = "De-Selects ALL selected Mods";
                    break;
                case "EQUIP":
                    s = "Equip player with selected mods (green).";
                    break;
                case "UNEQUIP":
                    s = "Unequip selected mods (green or yellow).";
                    break;
               case "SORT ID":
                    s = "Sort ALL mods by ID.";
                    break;
                case "SORT NAME":
                    s = "Sort ALL mods by NAME.";
                    break;
                case "SORT EQUIP":
                    s = "Move ALL EQUIPPED mods to the top. Previous order retained";
                    break;
                case "HELP OFF":
                    s = "Turns off button help messages.";
                    break;
                case "COPY":
                    s = "Copy MOD values to Input/Edit Area.";
                    break;
                case "UPDATE":
                    s = "Write edited MOD back to list.";
                    break;
                case "ADD NEW":
                    s = "Add the newly input MOD to the list.";
                    break;
                case "Delete":
                    s = "Delete the selected MODs from the list.";
                    break;
                case "CLEAR INPUT":
                    s = "Clear all Input/Edit fields.";
                    break;
                case "CHECK":
                    s = "Check syntax of ALL MODs.";
                    break;
                case "EVALUATE":
                    s = "Evaluate STAT changes of selected MOD(s) given equipped MODs.";
                    break;
                case "ANALYZE":
                    s = "Analyze MOD effects on STATs via simulation.";
                    break;
                case "CSV SAVE":
                    s = "Save ALL mods to 'ModsData.csv'.";
                    break;
                case "CSV LOAD":
                    s = "Load ALL mods from 'ModsData.csv'.";
                    break;
                case "YAML SAVE":
                    s = "Save ALL mods to 'ModsData.asset'.";
                    break;
                case "YAML LOAD":
                    s = "Load ALL mods from 'ModsData.asset'";
                    break;
                case "CLEAR MSGS":
                    s = "Clear the Message Area.";
                    break;

                // Add additional cases for other buttons as needed.

                default:
                    // Optionally, a default action.
                    break;
            }

            WriteMessage(s);
        }
    }

    private void SortModsByModID()
    {
        // Sorting by modID (unique) is inherently stable.
        List<int> sortedModIDs = modsDict.Values
            .OrderBy(mod => mod.modid)
            .ThenBy(mod => mod.modid) // This is redundant for unique keys, but shows our intent.
            .Select(mod => mod.modid)
            .ToList();

        modLineMap.Clear();
        for (int i = 0; i < sortedModIDs.Count; i++)
        {
            modLineMap[sortedModIDs[i]] = i;
        }

        DisplayAllMods();
    }

    private void SortModsByName()
    {
        // Sort mods by name, and then by modID as a tie-breaker to ensure stability.
        List<int> sortedByName = modsDict.Values
            .OrderBy(mod => mod.name)
            .ThenBy(mod => mod.modid)
            .Select(mod => mod.modid)
            .ToList();

        modLineMap.Clear();
        for (int i = 0; i < sortedByName.Count; i++)
        {
            modLineMap[sortedByName[i]] = i;
        }

        DisplayAllMods();
    }

    private void StableSortModsByPlayerMembership()
    {
        // Get the current order of modIDs based on their display line numbers.
        List<int> currentOrder = modLineMap
            .OrderBy(pair => pair.Value)
            .Select(pair => pair.Key)
            .ToList();

        // Perform a stable sort that partitions mods by membership.
        // Mods in playerModInventory with count > 0 get a key of 0, others 1.
        // OrderBy is stable, so the relative order in currentOrder is preserved within each group.
        List<int> sortedOrder = currentOrder
            .OrderBy(modID => {
                var mod = modsDict.Values.FirstOrDefault(m => m.modid == modID);
                return (mod != null && playerEquippedMods.ContainsKey(mod.uuid)) ? 0 : 1;
            })
            .ToList();

        // Rebuild modLineMap with the new ordering.
        modLineMap.Clear();
        for (int i = 0; i < sortedOrder.Count; i++)
        {
            modLineMap[sortedOrder[i]] = i;
        }

        // Refresh the display.
        DisplayAllMods();
    }

    public static bool ConfirmFileOverwrite(string filepath)
    {
        // If the file doesn't exist, we can proceed.
        if (!File.Exists(filepath))
            return true;

        // Get just the file name to show in the message.
        string fileName = Path.GetFileName(filepath);

        // Show a confirmation dialog.
        return ConfirmDialog($"File '{fileName}' already exists. Replace it?", "Confirm File Replace", "Replace MOD");
    }

    private int GetFirstSelectedModID()
    {
        if (markIndices == null || markIndices.Count == 0) {
            WriteMessage("ERROR: No Mod selected.", Color.Red); // Or return int.MaxValue, or throw an exception as appropriate.
            return -1;
        }
        
        // Get the smallest line number from the current selection.
        int firstLine = int.MaxValue;
        foreach (int modId in markIndices.Keys)
        {
            int line = MapMod2Line(modId);
            if (line != int.MaxValue && line < firstLine)
                firstLine = line;
        }
        
        if (firstLine == int.MaxValue) {
            WriteMessage("ERROR: No valid line found for selected mods.", Color.Red);
            return -1;
        }
        
        // Return the modID corresponding to that line.
        return MapLine2Mod(firstLine);
    }


}