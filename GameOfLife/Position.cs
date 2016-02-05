using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    /// <summary>
    /// Position: this class allows to any cell to set its position on the Life Board
    /// </summary>
    public class Position
    {
        public int PosX { get; set; }
        public int PosY { get; set; }

        public Position(int x, int y)
        {
            PosX = x;
            PosY = y;
        }
    }
}
