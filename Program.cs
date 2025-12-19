using System;
using System.Drawing;
using System.Windows.Forms;

namespace FlashingWarning;

public class WarningForm : Form
{
    private readonly Label warningLabel;
    private readonly System.Windows.Forms.Timer flashTimer;
    private bool isRed = true;

    public WarningForm()
    {
        Text = "Warning";
        Size = new Size(400, 200);
        StartPosition = FormStartPosition.CenterScreen;
        BackColor = Color.Black;
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;

        warningLabel = new Label
        {
            Text = "⚠ 5 CONFLICTS FOUND ⚠",
            Font = new Font("Arial", 20, FontStyle.Bold),
            ForeColor = Color.Red,
            AutoSize = false,
            Size = new Size(380, 100),
            Location = new Point(10, 50),
            TextAlign = ContentAlignment.MiddleCenter
        };
        Controls.Add(warningLabel);

        flashTimer = new System.Windows.Forms.Timer
        {
            Interval = 500
        };
        flashTimer.Tick += FlashTimer_Tick;
        flashTimer.Start();
    }

    private void FlashTimer_Tick(object? sender, EventArgs e)
    {
        isRed = !isRed;
        warningLabel.ForeColor = isRed ? Color.Red : Color.Yellow;
        BackColor = isRed ? Color.Black : Color.DarkRed;
    }
}

static class Program
{
    [STAThread]
    static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(new WarningForm());
    }
}
