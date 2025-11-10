//Manage the MOD Input/Edit area
using System.Windows.Forms.VisualStyles;

public partial class HIOXModEditor : Form
{
    private Panel inputRegion = null!;
    private FlowLayoutPanel inputFields = null!;

    int editedModID = -1;

    private void InitializeInputRegion(double margin, int splitYRight, int splitX)
    {
        // Input Region
        inputRegion = new Panel
        {
            Bounds = new Rectangle(splitX + (int)margin, splitYRight + (int)margin, this.ClientSize.Width - splitX - 2 * (int)margin, this.ClientSize.Height - splitYRight - 2 * (int)margin),
            BackColor = Color.LightBlue
        };
        this.Controls.Add(inputRegion);

        inputFields = new FlowLayoutPanel
        {
            Dock = DockStyle.Fill,
            AutoScroll = true,
            FlowDirection = FlowDirection.TopDown,
            WrapContents = false,
            AutoSize = false
        };
        inputRegion.Controls.Add(inputFields);

        // Add combined rows
        inputFields.Controls.Add(CreateLabeledInputRow(("ID", 4, 5), ("TYPE", 4, 5)));
        inputFields.Controls.Add(CreateLabeledInputRow(("NAME", 12, 48)));
        inputFields.Controls.Add(CreateLabeledInputRow(("DESC", 16, 256)));
        inputFields.Controls.Add(CreateLabeledInputRow(("VAL1", 4, 16), ("VAL1 MIN", 4, 16), ("VAL1 MAX", 4, 16)));
        inputFields.Controls.Add(CreateLabeledInputRow(("VAL2", 4, 16), ("VAL2 MIN", 4, 16), ("VAL2 MAX", 4, 16)));
        inputFields.Controls.Add(CreateLabeledInputRow(("EQN", 24, 256)));
        inputFields.Controls.Add(CreateLabeledInputRow(("R", 3, 6), ("G", 3, 6), ("B", 3, 6), ("A", 3, 6)));
        inputFields.Controls.Add(CreateLabeledInputRow(("ARMOR EFFECT", 12, 32)));
        inputFields.Controls.Add(CreateLabeledInputRow(("ARMOR MESH", 12, 32)));
    }

    private void UpdateInputRegion(int margin, int padding, int splitYLeft, int splitYRight, int splitX)
    {
        // Adjust Input Region
        inputRegion.Bounds = new Rectangle(
            splitX + margin,
            splitYRight + margin,
            this.ClientSize.Width - splitX - 2 * margin,
            this.ClientSize.Height - splitYRight
        );
    }

    private TableLayoutPanel CreateLabeledInputRow(
        params (string labelText, int inputWidth, int inputMaxLength)[] pairs)
    {
        var rowTLP = new TableLayoutPanel
        {
            RowCount = 1,
            ColumnCount = pairs.Length * 2,

            // Let the table auto-size in height to show its contents
            AutoSize = true,
            AutoSizeMode = AutoSizeMode.GrowAndShrink,

            // Dock to the top so each row stacks vertically in the FlowLayoutPanel
            Dock = DockStyle.Top,

            // FlowLayoutPanel doesn't fully respect Anchor for child controls,
            // so the left/right anchoring is optional here.
            Margin = new Padding(0),
            Padding = new Padding(0)
        };

        // For each column: label is AutoSize, textbox is percent-based
        for (int i = 0; i < rowTLP.ColumnCount; i++)
        {
            if (i % 2 == 0)
                rowTLP.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            else
                rowTLP.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f / pairs.Length));
        }

        // One row sized to content
        rowTLP.RowStyles.Add(new RowStyle(SizeType.AutoSize));

        int col = 0;
        foreach (var (labelText, inputWidth, inputMaxLength) in pairs)
        {
            // Create label
            var label = new Label
            {
                Text = labelText,
                AutoSize = true,
                Margin = new Padding(0, 0, 10, 0)
            };
            rowTLP.Controls.Add(label, col++, 0);

            // Create textbox
            var inputBox = new TextBox
            {
                // Fill horizontally in its cell
                Dock = DockStyle.Fill,
                MaxLength = inputMaxLength,
                // This sets a minimum width, so it's not too small
                MinimumSize = new Size(inputWidth * 10, 0)
            };
            rowTLP.Controls.Add(inputBox, col++, 0);
        }

        return rowTLP;
    }       

    private void ClearInputFields()
    {   
        editedModID = -1;
        
        // Iterate over each control in the inputFields panel.
        foreach (Control row in inputFields.Controls)
            // Each row is a TableLayoutPanel.
            if (row is TableLayoutPanel table)
                // Iterate over the controls in the table.
                foreach (Control ctrl in table.Controls)
                    // If the control is a TextBox, clear its text.
                    if (ctrl is TextBox tb)
                        tb.Clear();
    }

    private void CopyMod2InputFields(Mod mod)
    {
        editedModID = mod.modid;

        // Iterate over each row in the inputFields panel.
        foreach (Control row in inputFields.Controls)
        {
            if (row is TableLayoutPanel table)
            {
                // Each row contains alternating labels and textboxes.
                for (int i = 0; i < table.Controls.Count; i++)
                {
                    if (table.Controls[i] is Label label)
                    {
                        // Use trimmed text to match field names.
                        string fieldName = label.Text.Trim();
                        // Ensure the next control exists and is a TextBox.
                        if (i + 1 < table.Controls.Count && table.Controls[i + 1] is TextBox tb)
                        {
                            switch (fieldName)
                            {
                                case "ID":
                                    tb.Text = mod.modid.ToString();
                                    break;
                                case "NAME":
                                    tb.Text = mod.name;
                                    break;
                                case "DESC":
                                    tb.Text = mod.desc;
                                    break;
                                case "TYPE":
                                    tb.Text = mod.type.ToString();
                                    break;
                                case "VAL1":
                                    tb.Text = mod.val.ToString();
                                    break;
                                case "VAL2":
                                    tb.Text = mod.val2.ToString();
                                    break;
                                case "VAL1 MIN":
                                    tb.Text = mod.val1min.ToString();
                                    break;
                                case "VAL1 MAX":
                                    tb.Text = mod.val1max.ToString();
                                    break;
                                case "VAL2 MIN":
                                    tb.Text = mod.val2min.ToString();
                                    break;
                                case "VAL2 MAX":
                                    tb.Text = mod.val2max.ToString();
                                    break;
                                case "EQN":
                                    tb.Text = mod.equation;
                                    break;
                                case "R":
                                    tb.Text = mod.modColor.r.ToString();
                                    break;
                                case "G":
                                    tb.Text = mod.modColor.g.ToString();
                                    break;
                                case "B":
                                    tb.Text = mod.modColor.b.ToString();
                                    break;
                                case "A":
                                    tb.Text = mod.modColor.a.ToString();
                                    break;
                                case "ARMOR EFFECT":
                                    tb.Text = mod.armorEffectName is null ? "N/A" : mod.armorEffectName.ToString();
                                    break;
                                case "ARMOR MESH":
                                    tb.Text = mod.armorMeshName is null ? "N/A" : mod.armorMeshName.ToString();
                                    break;
                                default:
                                    // For any fields you don't handle, leave them unchanged.
                                    break;
                            }
                        }
                    }
                }
            }
        }
    }

    private int GetEditedModID()
    {
        Control row = inputFields.Controls[0];
        if (row is TableLayoutPanel table)
            if (1 < table.Controls.Count && table.Controls[1] is TextBox tb)
                if (int.TryParse(tb.Text.Trim(), out int temp))
                    return temp;
 
        return editedModID;
    }

    private Mod? ReadInputFields()
    {
        Mod mod = new Mod();
        int errct = 0;
        
        // Iterate over each row in the inputFields panel.
        for (int r = 0; r < inputFields.Controls.Count; r++)
        {
            Control row = inputFields.Controls[r];
        //}
        //foreach (Control row in inputFields.Controls)
        //{
            if (row is TableLayoutPanel table)
            {
                // Each row contains alternating labels and textboxes.
                for (int i = 0; i < table.Controls.Count; i++)
                {
                    if (errct == 0) {
                        if (table.Controls[i] is Label label)
                        {
                            string fieldName = label.Text.Trim();
                            // Ensure the next control exists and is a TextBox.
                            if (i + 1 < table.Controls.Count && table.Controls[i + 1] is TextBox tb)
                            {
                                string value = tb.Text.Trim();
                                try
                                {
                                    float tempf;
                                    int temp;

                                    switch (fieldName)
                                    {
                                        case "ID":
                                            if (!int.TryParse(value, out temp)) {
                                                BadDataError("ID", value, "int");
                                                errct ++;
                                            } else
                                                mod.modid = temp;
                                            break;
                                        case "NAME":
                                            mod.name = value;
                                            break;
                                        case "DESC":
                                            mod.desc = value;
                                            break;
                                        case "TYPE":
                                            if (!int.TryParse(value, out temp)) {
                                                BadDataError("TYPE", value, "int");
                                                errct ++;
                                            } else
                                                mod.type = temp;
                                            break;
                                        case "VAL1":
                                            if (!float.TryParse(value, out tempf)) {
                                                BadDataError("VAL1", value, "float");
                                                errct ++;
                                            } else
                                                mod.val = tempf;
                                            break;
                                        case "VAL2":
                                            if (!float.TryParse(value, out tempf)) {
                                                BadDataError("VAL2", value, "float");
                                                errct ++;
                                            } else
                                                mod.val2 = tempf;
                                            break;
                                        case "VAL1 MIN":
                                            if (!float.TryParse(value, out tempf)) {
                                                BadDataError("VAL1MIN", value, "float");
                                                errct ++;
                                            } else
                                                mod.val1min = tempf;
                                            break;
                                        case "VAL1 MAX":
                                            if (!float.TryParse(value, out tempf)) {
                                                BadDataError("VAL1MAX", value, "float");
                                                errct ++;
                                            } else
                                                mod.val1max = tempf;
                                            break;
                                        case "VAL2 MIN":
                                            if (!float.TryParse(value, out tempf)) {
                                                BadDataError("VAL2MIN", value, "float");
                                                errct ++;
                                            } else
                                                mod.val2min = tempf;
                                            break;
                                        case "VAL2 MAX":
                                            if (!float.TryParse(value, out tempf)) {
                                                BadDataError("VAL2MAX", value, "float");
                                                errct ++;
                                            } else
                                                mod.val2max = tempf;
                                            break;
                                        case "EQN":
                                            mod.equation = value;
                                            break;
                                        case "R":
                                            mod.modColor.r = int.Parse(value);
                                            break;
                                        case "G":
                                            mod.modColor.g = int.Parse(value);
                                            break;
                                        case "B":
                                            mod.modColor.b = int.Parse(value);
                                            break;
                                        case "A":
                                            mod.modColor.a = int.Parse(value);
                                            break;
                                        case "ARMOR EFFECT":
                                            mod.armorEffectName = value.Equals("N/A", StringComparison.OrdinalIgnoreCase) ? null! : value;
                                            break;
                                        case "ARMOR MESH":
                                            mod.armorMeshName = value.Equals("N/A", StringComparison.OrdinalIgnoreCase) ? null! : value;
                                            break;
                                        default:
                                            // Leave any unrecognized fields unchanged.
                                            break;
                                    }
                                }
                                catch (Exception ex)
                                {
                                    WriteMessage($"Error parsing field '{fieldName}': {ex.Message}", Color.Red);
                                }
                            }
                        }
                    }   
                }
            }
        }

        return (errct == 0) ? mod : null;
    }

    private static void BadDataError(string varname, string value, string type) 
    {
        ConfirmDialog($"{varname} ({value}) is not a {type}.", $"Bad {type}", "OK", "Whatever");
    }

    

}