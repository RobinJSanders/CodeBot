using System.Windows.Forms;
using System.Drawing;
using Code_Bot.Logic;
using Code_Bot.Properties;


namespace Code_Bot.Props
{
    public class Wall
    {
        //position of wall in blocks relative to grid:
        public int GridPositionX { get; set; }
        public int GridPositionY { get; set; }
        //position of wall in pixels relative to form:
        public PictureBox pbxWall = new PictureBox();
        Bitmap _wall = Resources.Wall;
       

        public Wall(int x, int y, Form form)
        {
            GridPositionX = x;
            GridPositionY = y;
            pbxWall.Image = _wall;
            pbxWall.Visible = true;
            pbxWall.Location = new Point(PositionConvert.GridToFormX(x), PositionConvert.GridToFormY(y));
            pbxWall.Size = new Size(30, 30);
            form.Controls.Add(pbxWall);
            pbxWall.BringToFront();
        }
    }
}