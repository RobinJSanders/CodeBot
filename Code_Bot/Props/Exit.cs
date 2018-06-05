using System.Windows.Forms;
using System.Drawing;
using Code_Bot.Logic;
using Code_Bot.Properties;


namespace Code_Bot.Props
{
    public class Exit
    {
       
        public int GridPositionX { get; set; }
        public int GridPositionY { get; set; }        //position of exit in blocks relative to grid
        public Form NextLevel { get; private set; }
        public Form ThisLevel { get; private set; }
        PictureBox pbxExit = new PictureBox();
        Bitmap _exit = Resources.Exit;

        public Exit(int x, int y, Form thisLevel, Form nextLevel)
        {
            ThisLevel = thisLevel;
            NextLevel = nextLevel;
            GridPositionX = x;
            GridPositionY = y;
            pbxExit.Image = _exit;
            pbxExit.Visible = true;
            pbxExit.Location = new Point(PositionConvert.GridToFormX(x), PositionConvert.GridToFormY(y));
            pbxExit.Size = new Size(30, 30);
            thisLevel.Controls.Add(pbxExit);
            pbxExit.BringToFront();
        }
    }
}