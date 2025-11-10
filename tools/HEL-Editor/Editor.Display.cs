// Members and methods related to mainDisplay
using System.Data.Common;

using modsDictionary = System.Collections.Generic.Dictionary<string, Mod>;
public partial class HIOXModEditor : Form
{
    private RichTextBox mainDisplay = null!;
    private Dictionary<int, int> modLineMap = new Dictionary<int, int>();

    // Holds the last clicked line number (anchor for SHIFT selection)
    private int lastClickedLine = -1;

    // Dictionary of marked (selected) mod IDs and their counts.
    private Dictionary<int, int> markIndices = new Dictionary<int, int>();
    private Dictionary<int, int> previousMarkIndices = new Dictionary<int, int>();

    private void InitializeMainDisplay(double margin, int splitYLeft, int splitX, double padding)
    {
        // Display Region
        displayRegion = new Panel
        {
            Bounds = new Rectangle((int)margin, (int)margin, splitX - 2 * (int)margin, splitYLeft - 2 * (int)margin),
            BackColor = Color.LightGray
        };
        this.Controls.Add(displayRegion);

        titleLabel = new Label
        {
            Text = TitleText,
            Font = new Font("Monaco", 12, FontStyle.Bold),
            Location = new Point((int)padding, (int)padding),
            AutoSize = true
        };
        displayRegion.Controls.Add(titleLabel);

        mainDisplay = new RichTextBox
        {
            Multiline = true,
            ReadOnly = true,
            ScrollBars = RichTextBoxScrollBars.Both,
            WordWrap = false,
            Location = new Point((int)padding, titleLabel.Bottom + (int)padding),
            Size = new Size(displayRegion.Width - 2 * (int)padding, displayRegion.Height - titleLabel.Height - 3 * (int)padding)
        };
        displayRegion.Controls.Add(mainDisplay);
        mainDisplay.Cursor = Cursors.Arrow;
        mainDisplay.MouseDown += MainDisplay_MouseDown;
        mainDisplay.Text = "";
    }

    
    private void UpdateDisplayRegion(int margin, int padding, int splitYLeft, int splitYRight, int splitX)
    {
        // Adjust Display Region
        displayRegion.Bounds = new Rectangle(
            margin,
            margin,
            splitX - 2 * margin,
            splitYLeft - 2 * margin
        );
        mainDisplay.Bounds = new Rectangle(
            padding,
            titleLabel.Bottom + padding,
            displayRegion.Width - 2 * padding,
            displayRegion.Height - titleLabel.Height - 3 * padding
        );
    }

    // Common method to render a single mod line into mainDisplay.
    // If the target line exists, it replaces that line; otherwise, it appends at the end.
    private void RenderModLine(int line, Color color = default)
    {
        int modID = MapLine2Mod(line);
        Mod? m = modsDict.Values.FirstOrDefault(mod => mod.modid == modID);
        if (m is null) {
            WriteMessage($"ERROR: Bad Line Render (line={line}, modID={modID}).", Color.Red);
            return;
        }
        SuspendDrawing(mainDisplay);
        bool wasReadOnly = mainDisplay.ReadOnly;
        mainDisplay.ReadOnly = false;

        if (line < mainDisplay.Lines.Length)
        {
            int start = mainDisplay.GetFirstCharIndexFromLine(line);
            int end = (line < mainDisplay.Lines.Length - 1)
                        ? mainDisplay.GetFirstCharIndexFromLine(line + 1)
                        : mainDisplay.TextLength;
            int length = end - start;
            mainDisplay.SelectionStart = start;
            mainDisplay.SelectionLength = length;
            mainDisplay.SelectedText = ""; // Remove old line.
            mainDisplay.SelectionStart = start;
        }
        else
        {
            // Append at end.
            mainDisplay.SelectionStart = mainDisplay.TextLength;
        }

        if (color == default) {
            int which = 0;
            if (markIndices.ContainsKey(modID) && markIndices[modID] > 0)
                which += 1;
            if (m != null && playerEquippedMods.ContainsKey(m.uuid))
                which += 2;
            switch (which) {
                case 1:
                    color = Color.Green;
                    break;
                case 2: 
                    color = Color.Blue;
                    break;
                case 3: 
                    color = Color.Red;
                    break;
                default:
                    color = Color.Black;
                    break;
            }
        }
 
        // Write the mod line using the common formatting function.
        WriteModLine(m, modID, color);

        mainDisplay.ReadOnly = wasReadOnly;  //### WHAT IS THIS?
        ResumeDrawing(mainDisplay);
    }

    //###############################################################################
    // Continue with removal of sortedModIDs (use modLineMap). Also add functions
    // to update modLineMap when sorting, inserting, deleting and appending mods.

    //@#####################################################################

    // Writes out a single mod's details using various text styles.
    private void WriteModLine(Mod m, int modId, Color color)
    {
        WriteRichText(mainDisplay, $"{m.type:D2} ", color);
        // Show count from markIndices if marked, otherwise from playerModInventory if equipped
        int count = 0;
        if (markIndices.ContainsKey(modId))
            count = markIndices[modId];
        else if (m != null && playerEquippedMods.ContainsKey(m.uuid))
            count = 1;
        WriteRichText(mainDisplay, $"{count}x ", color);
        WriteRichText(mainDisplay, $"{modId:D4} ", color, FontStyle.Bold);
        WriteRichText(mainDisplay, $"{m.modweight:D3} ", color);
        WriteRichText(mainDisplay, $"{(m.hasProc != 0 ? "Y" : "N")} ", color);
        string pad_name = PadText(m.name, 190, mainDisplay.Font);
        WriteRichText(mainDisplay, $"{pad_name} ", color, FontStyle.Italic);
        WriteRichText(mainDisplay, $"{(string.IsNullOrEmpty(m.equation) ? "NONE" : m.equation)}\t ", color, FontStyle.Bold);
        WriteRichText(mainDisplay, $"{m.val1min:0.###}<{m.val1max:0.###}, {m.val2min:0.###}<{m.val2max:0.###} \t", color, FontStyle.Italic);
        WriteRichText(mainDisplay, $"({m.desc})\r\n", color);
    }

    // Helper for writing text with a specified color and font style.
    private void WriteRichText(RichTextBox box, string text, Color color, FontStyle style = FontStyle.Regular)
    {
        box.SelectionColor = color;
        box.SelectionFont = (style != FontStyle.Regular) ? new Font(box.Font, style) : box.Font;
        box.SelectedText = text;
        // Reset to defaults.
        box.SelectionColor = box.ForeColor;
        box.SelectionFont = box.Font;
    }

    // Pads or truncates text so that its rendered width is close to targetWidth.
    public static string PadText(string s, int targetWidth, Font font)
    {
        int diff = TextRenderer.MeasureText(s, font).Width - targetWidth;
        if (diff > 0)
        {
            while (s.Length > 0 && TextRenderer.MeasureText(s, font).Width > targetWidth)
            {
                s = s.Substring(0, s.Length - 1);
            }
        }
        else if (diff < 0)
        {
            while (TextRenderer.MeasureText(s, font).Width < targetWidth)
            {
                s += " ";
            }
        }
        return s;
    }

    // Handles mouse clicks in mainDisplay for selecting mods.
    private void MainDisplay_MouseDown(object? sender, MouseEventArgs e)
    {
        int charIndex = mainDisplay.GetCharIndexFromPosition(e.Location);
        int clickedLine = mainDisplay.GetLineFromCharIndex(charIndex);
        bool shiftDown = (ModifierKeys & Keys.Shift) == Keys.Shift;
        bool isRightClick = e.Button == MouseButtons.Right;

        // Save current markIndices state for comparison
        var oldMarkIndices = new Dictionary<int, int>(markIndices);

        int startLine, endLine;
        if (mainDisplay.SelectionLength > 0)
        {
            startLine = mainDisplay.GetLineFromCharIndex(mainDisplay.SelectionStart);
            endLine = mainDisplay.GetLineFromCharIndex(mainDisplay.SelectionStart + mainDisplay.SelectionLength - 1);
        }
        else
        {
            startLine = clickedLine;
            endLine = clickedLine;
        }

        // Determine the range of lines affected.
        List<int> affectedLines = Enumerable.Range(startLine, endLine - startLine + 1).ToList();

        if (!shiftDown)
        {
            // Simple click - affect only clicked mod
            int modId = MapLine2Mod(clickedLine);
            if (modId != int.MaxValue)
            {
                var mod = modsDict.Values.FirstOrDefault(m => m.modid == modId);
                bool isEquipped = mod != null && playerEquippedMods.ContainsKey(mod.uuid);
                
                if (isEquipped)
                {
                    // Equipped: Only change selection
                    if (isRightClick)
                    {
                        // Right-click: Remove from selection if present
                        markIndices.Remove(modId);
                    }
                    else
                    {
                        // Left-click: Add to selection with equipped count
                        if (!markIndices.ContainsKey(modId))
                        {
                            markIndices[modId] = 1; // Equipped mods always have count 1
                        }
                    }
                }
                else
                {
                    // Not equipped: Change count
                    if (isRightClick)
                    {
                        // Decrement count (minimum 0)
                        if (markIndices.ContainsKey(modId) && markIndices[modId] > 0)
                        {
                            markIndices[modId]--;
                            if (markIndices[modId] == 0)
                            {
                                markIndices.Remove(modId);
                            }
                        }
                    }
                    else
                    {
                        // Increment count
                        if (!markIndices.ContainsKey(modId))
                            markIndices[modId] = 0;
                        markIndices[modId]++;
                    }
                }
            }
            lastClickedLine = clickedLine;
        }
        else
        {
            // SHIFT+click - affect range from anchor to clicked line
            int anchor = (lastClickedLine == -1) ? clickedLine : lastClickedLine;
            int rangeStart = Math.Min(anchor, clickedLine);
            int rangeEnd = Math.Max(anchor, clickedLine);
            
            for (int line = rangeStart; line <= rangeEnd; line++)
            {
                int modId = MapLine2Mod(line);
                if (modId != int.MaxValue)
                {
                    var mod = modsDict.Values.FirstOrDefault(m => m.modid == modId);
                bool isEquipped = mod != null && playerEquippedMods.ContainsKey(mod.uuid);
                    
                    if (isEquipped)
                    {
                        // Equipped: Only change selection
                        if (isRightClick)
                        {
                            // Right-click: Remove from selection if present
                            markIndices.Remove(modId);
                        }
                        else
                        {
                            // Left-click: Add to selection with equipped count
                            if (!markIndices.ContainsKey(modId))
                            {
                                markIndices[modId] = 1; // Equipped mods always have count 1
                            }
                        }
                    }
                    else
                    {
                        // Not equipped: Change count
                        if (isRightClick)
                        {
                            // Decrement count (minimum 0)
                            if (markIndices.ContainsKey(modId) && markIndices[modId] > 0)
                            {
                                markIndices[modId]--;
                                if (markIndices[modId] == 0)
                                {
                                    markIndices.Remove(modId);
                                }
                            }
                        }
                        else
                        {
                            // Increment count
                            if (!markIndices.ContainsKey(modId))
                                markIndices[modId] = 0;
                            markIndices[modId]++;
                        }
                    }
                }
            }
        }

        // Save current state for next time
        previousMarkIndices = new Dictionary<int, int>(markIndices);

        // Determine which mods have changed and update their display lines
        var changedModIds = new HashSet<int>();
        foreach (var kvp in oldMarkIndices)
        {
            if (!markIndices.ContainsKey(kvp.Key) || markIndices[kvp.Key] != kvp.Value)
                changedModIds.Add(kvp.Key);
        }
        foreach (var kvp in markIndices)
        {
            if (!oldMarkIndices.ContainsKey(kvp.Key) || oldMarkIndices[kvp.Key] != kvp.Value)
                changedModIds.Add(kvp.Key);
        }

        // Update display for changed mods
        foreach (int modId in changedModIds)
        {
            int line = MapMod2Line(modId);
            if (line != int.MaxValue && line < modsDict.Count)
                RenderModLine(line);
        }
    }

    // Re-renders all mods in mainDisplay.
    private void DisplayAllMods()
    {
       //Initialize modLineMap
        modLineMap.Clear();
        int count = 0;
        foreach (var mod in modsDict.Values.OrderBy(m => m.modid)) 
            modLineMap[mod.modid] = count++;

        // Save scroll position.
        int firstCharIndex = mainDisplay.GetCharIndexFromPosition(new Point(0, 0));
        int firstVisibleLine = mainDisplay.GetLineFromCharIndex(firstCharIndex);

        SuspendDrawing(mainDisplay);
        mainDisplay.Clear();

        for (int m=0; m<modLineMap.Count; m++)
            RenderModLine(m);

        // Restore scroll position.
        int newFirstCharIndex = mainDisplay.GetFirstCharIndexFromLine(firstVisibleLine);
        mainDisplay.SelectionStart = newFirstCharIndex;
        mainDisplay.ScrollToCaret();

        ResumeDrawing(mainDisplay);
    }

    // Loads mods and then displays them.
    private void PopulateMainDisplayWithMods(bool loadYAML)
    {
        if ( mainDisplay.Lines.Count() == 0 || ConfirmDialog( $"Displayed MODs will be Replaced.", "Confirm Replace") ) {
            try
            {
                var t = ( loadYAML ? HELYAMLFile.LoadAsset(modsYAMLFilePath, "mods:")
                                   : HELCSVFile.LoadAsset(modsCSVFilePath, "mods:") );
                if (t.Item1 is modsDictionary tempModsDict)
                {
                    modsDict = tempModsDict;
                    DisplayAllMods();
                }
                else
                {
                    WriteMessage("Failed to load mods from asset file.\r\n", Color.DarkGoldenrod);
                }
            }
            catch (Exception ex)
            {
                WriteMessage($"Error loading mods: {ex.Message}\r\n", Color.Red);
            }
        }
    }

    private int MapMod2Line(int modID)
    {
        if (modLineMap.TryGetValue(modID, out int lineNum)) 
            return lineNum;
        else
            return int.MaxValue;
    }

    private int MapLine2Mod(int lineNum)
    {
        if (lineNum < modLineMap.Count)
            return modLineMap.FirstOrDefault(pair => pair.Value == lineNum).Key;
        else
            return int.MaxValue;
    }

    private List<int> MapModList2LineList(List<int> modList)
    {
        return modList.Select(modID => MapMod2Line(modID)).ToList();
    }

    private List<int> MapLineList2ModList(List<int> lineList)
    {
        return lineList.Select(lineNum => MapLine2Mod(lineNum)).ToList();
    }
}
/*

// Members and methods related to mainDisplay
public partial class HIOXModEditor : Form
{
    private RichTextBox mainDisplay = null!;

    //A sorted list of Mod IDs defining display ordering. May be sorted in many different ways.
    private List<int> sortedModIDs = [];

    //Mapping between Mod ID and display line.
    private Dictionary<int, int> modLineMap = new Dictionary<int, int>();


    // Holds the last clicked line number (as an anchor for SHIFT selection)
    private int lastClickedLine = -1;

    //A list of line numbers identifying "marked" or selected mods in the mainDisplay.
    private List<int> markIndices = [];

   // Global variable to track previous marked indices.
    private List<int> previousMarkIndices = new List<int>();



    private void InitializeMainDisplay(double padding) 
    {
       mainDisplay = new RichTextBox
        {
            Multiline = true,
            ReadOnly = true,
            ScrollBars = RichTextBoxScrollBars.Both,
            WordWrap = false,
            Location = new Point((int)padding, titleLabel.Bottom + (int)padding),
            Size = new Size(displayRegion.Width - 2 * (int)padding, displayRegion.Height - titleLabel.Height - 3 * (int)padding)
        };
        displayRegion.Controls.Add(mainDisplay);
        mainDisplay.MouseClick += MainDisplay_MouseClick;
        mainDisplay.Text = "";
    }
    
    private void MainDisplay_MouseClick(object? sender, MouseEventArgs e)
    {
        int charIndex = mainDisplay.GetCharIndexFromPosition(e.Location);
        int clickedLine = mainDisplay.GetLineFromCharIndex(charIndex);
        bool shiftDown = (ModifierKeys & Keys.Shift) == Keys.Shift;
        bool ctrlDown  = (ModifierKeys & Keys.Control) == Keys.Control;

        int startLine, endLine;
        if (mainDisplay.SelectionLength > 0)
        {
            // Drag-click (a range was selected).
            startLine = mainDisplay.GetLineFromCharIndex(mainDisplay.SelectionStart);
            endLine = mainDisplay.GetLineFromCharIndex(mainDisplay.SelectionStart + mainDisplay.SelectionLength - 1);
            Console.WriteLine($"Selection between {startLine + 1} and {endLine + 1}.");
        }
        else
        {
            // Single click.
            startLine = clickedLine;
            endLine = clickedLine;
            Console.WriteLine($"Mouse clicked on line: {clickedLine + 1}");
        }

        // Build the new range from the explicit selection.
        List<int> newRange = Enumerable.Range(startLine, endLine - startLine + 1).ToList();
        List<int> newMarkIndices;

        // Case 1: No modifier – replace the selection.
        if (!shiftDown && !ctrlDown)
        {
            newMarkIndices = new List<int>(newRange);
            lastClickedLine = clickedLine; // Update anchor.
        }
        // Case 2: SHIFT only – extend the selection contiguously.
        else if (shiftDown && !ctrlDown)
        {
            // Use the anchor: if none exists, use the clicked line.
            int anchor = (lastClickedLine == -1) ? clickedLine : lastClickedLine;
            int contiguousStart = Math.Min(anchor, clickedLine);
            int contiguousEnd = Math.Max(anchor, clickedLine);
            newMarkIndices = previousMarkIndices.Union(
                            Enumerable.Range(contiguousStart, contiguousEnd - contiguousStart + 1))
                            .OrderBy(x => x).ToList();
        }
        // Case 3: CTRL only – add just the explicit new range (non-contiguous).
        else if (!shiftDown && ctrlDown)
        {
            newMarkIndices = previousMarkIndices.Union(newRange).OrderBy(x => x).ToList();
        }
        // Case 4: Both SHIFT and CTRL – choose a behavior (here, we treat it as CTRL only).
        else // (shiftDown && ctrlDown)
        {
            newMarkIndices = previousMarkIndices.Union(newRange).OrderBy(x => x).ToList();
        }

        Console.WriteLine($"Marked Indices: {string.Join(", ", newMarkIndices)}");

        // Determine which lines have changed (either newly marked or unmarked).
        var changedUnselected = previousMarkIndices.Except(newMarkIndices);
        var changedSelected = newMarkIndices.Except(previousMarkIndices);
        var changedIndices = changedUnselected.Union(changedSelected);

        // Update only the changed lines.
        foreach (int line in changedIndices)
        {
            if (line >= 0 && line < sortedModIDs.Count)
            {
                int modId = sortedModIDs[line];
                Color newColor;
                if (newMarkIndices.Contains(line))
                    newColor = Color.Green;  // Selected.
                else if (playerModInventory.ContainsKey(modId) && playerModInventory[modId] > 0)
                    newColor = Color.Blue;   // Player mod.
                else
                    newColor = Color.Red;    // Default.

                if (modsDict.TryGetValue(modId, out Mod? m) && m is not null)
                {
                    AppendOneMod(modId, m!, newColor, line);
                }
            }
        }

        // Save the new selection for next time.
        previousMarkIndices = new List<int>(newMarkIndices);
        markIndices = new List<int>(newMarkIndices);
    }

    private void WriteModText(RichTextBox box, string text, Color color, FontStyle style = FontStyle.Regular)
    {
        box.SelectionColor = color;
        box.SelectionFont = (style != FontStyle.Regular) ? new Font(box.Font, style) : box.Font;
        box.SelectedText = text;
        // Reset to defaults after writing.
        box.SelectionColor = box.ForeColor;
        box.SelectionFont = box.Font;
    }
    
    private void WriteModLine(Mod m, int modId, Color color)
    {
        WriteModText(mainDisplay, $"{m.type:D2} ", color);
        WriteModText(mainDisplay, $"{modId:0000} ", color, FontStyle.Bold);
        WriteModText(mainDisplay, $"{(m.hasProc != 0 ? "Y" : "N")} ", color);
        string pad_name = PadText(m.name, 190, mainDisplay.Font);
        WriteModText(mainDisplay, $"{pad_name} ", color, FontStyle.Italic);
        WriteModText(mainDisplay, $"{(string.IsNullOrEmpty(m.equation) ? "X" : m.equation)}\t ", color, FontStyle.Bold);
        WriteModText(mainDisplay, $"({m.desc})\r\n", color);
    }

    public static string PadText(string s, int targetWidth, Font font)
    {
        int diff = TextRenderer.MeasureText(s, font).Width - targetWidth;

        if (diff > 0) {
            // Truncate the string if its rendered width is greater than targetWidth.
            while (s.Length > 0 && TextRenderer.MeasureText(s, font).Width > targetWidth)
            {
                s = s.Substring(0, s.Length - 1);
            }
        } else if (diff < 0) {
            // Pad with spaces until the rendered width is at least targetWidth.
            while (TextRenderer.MeasureText(s, font).Width < targetWidth)
            {
                s += " ";
            }
        }

        return s;
    }

    private void AppendOneMod(int modId, Mod m, Color color, int? lineNumber = null)
    {
        // Determine target line: if not provided, append to the end.
        int targetLine = lineNumber ?? mainDisplay.Lines.Length;

        SuspendDrawing(mainDisplay);

        // Temporarily disable read-only to avoid the beep.
        bool wasReadOnly = mainDisplay.ReadOnly;
        mainDisplay.ReadOnly = false;


        if (targetLine < mainDisplay.Lines.Length)
        {
            // Replace the existing line.
            int start = mainDisplay.GetFirstCharIndexFromLine(targetLine);
            int end = (targetLine < mainDisplay.Lines.Length - 1)
                    ? mainDisplay.GetFirstCharIndexFromLine(targetLine + 1)
                    : mainDisplay.TextLength;
            int length = end - start;

            mainDisplay.SelectionStart = start;
            mainDisplay.SelectionLength = length;
            mainDisplay.SelectedText = ""; // Remove the old line.
            mainDisplay.SelectionStart = start;
        }
        else
        {
            // Append at the end.
            mainDisplay.SelectionStart = mainDisplay.TextLength;
        }

        // Write the mod line with the desired formatting.
        WriteModLine(m, modId, color);

        // Restore the read-only status.
        mainDisplay.ReadOnly = wasReadOnly;


        ResumeDrawing(mainDisplay);

        // Update the global mapping (modLineMap) if needed.
        modLineMap[modId] = targetLine;
    }

    private void DisplayAllMods()
    {
        // Save scroll position.
        int firstCharIndex = mainDisplay.GetCharIndexFromPosition(new Point(0, 0));
        int firstVisibleLine = mainDisplay.GetLineFromCharIndex(firstCharIndex);

        SuspendDrawing(mainDisplay);
        mainDisplay.Clear();
        modLineMap.Clear();
        int count = 0;
        foreach (var kvp in modsDict)
        {
            Color modColor = Color.Red;
            if (markIndices.Contains(count))
                modColor = Color.Green;
            else if (playerModInventory.ContainsKey(kvp.Key) && playerModInventory[kvp.Key] > 0)
                modColor = Color.Blue;
            AppendOneMod(kvp.Key, kvp.Value, modColor);
            count++;
        }
        int newFirstCharIndex = mainDisplay.GetFirstCharIndexFromLine(firstVisibleLine);
        mainDisplay.SelectionStart = newFirstCharIndex;
        mainDisplay.ScrollToCaret();

        ResumeDrawing(mainDisplay);
    }

    private void PopulateMainDisplayWithMods()
    {
        // Specify the path to your mods asset file
        string modsFilePath = "ModsData.asset"; // Adjust the path as necessary

        try
        {
            // Load the mods asset; the root node should start with 'm' (e.g., "mods:")
            var modsObject = HELAssetLoader.LoadAsset(modsFilePath, "mods:");
            if (modsObject is modsDictionary tempModsDict)
            {
                modsDict = tempModsDict;
                sortedModIDs = modsDict.Keys.ToList();
                playerModInventory.Clear();
                markIndices = [];
                previousMarkIndices = [];
                DisplayAllMods();
            }
            else
            {
                mainDisplay.AppendText("Failed to load mods from asset file.\r\n");
            }
        }
        catch (Exception ex)
        {
            mainDisplay.AppendText("Error loading mods: " + ex.Message + "\r\n");
        }
    }


}
*/