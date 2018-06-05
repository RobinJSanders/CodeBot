using System.Collections.Generic;
using System.Windows.Forms;


namespace Code_Bot.Props
{

    static class WallBuild
    {
        public static void Horizontal(int x, int y, int length, List<Wall> walls, Form form)
        {//builds walls from left to right
            int l = x + length;
            while (x < l)
            {
                walls.Add(new Props.Wall(x, y, form));
                x++;
            }
        }
        public static void Vertical(int x, int y, int length, List<Wall> walls, Form form)
        {//builds walls from top to bottom
            int l = y + length;
            while (y < l)
            {
                walls.Add(new Props.Wall(x, y, form));
                y++;
            }
        }
    }
}
