// Mods Stats Region display

using statsDictionary = System.Collections.Generic.Dictionary<string, Stat>;
public partial class HIOXModEditor : Form
{
    private Panel statsRegion = null!;
    private RichTextBox statsBox = null!;
    statsDictionary previousStats = null!;

    private void InitializeStatsRegion(double margin, int splitYRight, int splitX)
    {
        // Stats Region
        statsRegion = new Panel
        {
            Bounds = new Rectangle(splitX + (int)margin, (int)margin, this.ClientSize.Width - splitX - 2 * (int)margin, splitYRight - 2 * (int)margin),
            BackColor = Color.LightGreen
        };
        this.Controls.Add(statsRegion);

        statsBox = new RichTextBox
        {
            Multiline = true,
            ReadOnly = true,
            ScrollBars = RichTextBoxScrollBars.Both,
            WordWrap = false,
            Dock = DockStyle.Fill
        };
        statsRegion.Controls.Add(statsBox);
    }

    private void UpdateStatsRegion(int margin, int padding, int splitYLeft, int splitYRight, int splitX)
    {
        // Adjust Stats Region
        statsRegion.Bounds = new Rectangle(
            splitX + margin,
            margin,
            this.ClientSize.Width - splitX - 2 * margin,
            splitYRight - 2 * margin
        );
    }

    private void DisplayStats(statsDictionary stats, statsDictionary? prev = default, bool reset = false)
    {
        if (prev == default)
            prev = statsDict;
        statsBox.Clear();
        foreach (string sname in statsOrder) {
            Stat stat = stats[sname];
            float prev_value = prev[sname].value;
            Color dColor = default;
            if (prev_value < stats[sname].value)
                dColor = Color.Green;
            else if (prev_value > stats[sname].value)
                dColor = Color.Red;
            WriteStatLine(stat, prev_value, dColor);
        }
        previousStats = stats;
    }

    // Writes out a single mod's details using various text styles.
    private void WriteStatLine(Stat s, float prev = default, Color color = default)
    {
        if (color == default)
            color = Color.Black;

        string pad_name = PadText(s.name, 130, statsBox.Font);
        string diffStr = $"{(s.value - prev):+0.##;-0.##;=0}";
        WriteRichText(statsBox, $"{pad_name} \t", color, FontStyle.Bold);
        WriteRichText(statsBox, $"{s.value,5:0.##} {diffStr} \t", color);
        WriteRichText(statsBox, $"({s.min},{s.max}) \t", color);
        WriteRichText(statsBox, $"{s.desc}\r\n", color, FontStyle.Italic);
    }

}