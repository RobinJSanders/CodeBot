using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Bot.Logic
{

   static class PositionConvert
    {

        public static int FormToGridX(int X)
        {//converts position relative to the form's board in pixels to a position on the grid in blocks
            int gridX = (X - Levels.ParentLevel.BoardX) / 30 + 1;
            return gridX;
        }

        public static int FormToGridY(int Y)
        {
            int gridY = (Y - Levels.ParentLevel.BoardY) / 30 + 1;
            return gridY;
        }

        public static int GridToFormX(int X)
        {//converts position on the grid in blocks to a position relative to the form's board in pixels 
            int formX = (X * 30) + Levels.ParentLevel.BoardX - 30;
            return formX;
        }

        public static int GridToFormY(int Y)
        {
            int formY = (Y * 30) + Levels.ParentLevel.BoardY - 30;
            return formY;
        }

    }
}
