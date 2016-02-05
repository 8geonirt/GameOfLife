using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    /// <summary>
    /// Cell: This class contains the main functionality and attributes of a cell
    /// </summary>
    public class Cell
    {
        public bool IsAlive { get; set; }
        private Position _position { get; set; }

        public int PosX
        {
            get
            {
                return _position.PosX;
            }
            set
            {
                _position.PosX = value;
            }
        }

        public int PosY
        {
            get
            {
                return _position.PosY;
            }
            set
            {
                _position.PosY = value;
            }
        }

        public Cell()
        {
            _position = null;
            IsAlive = false;
        }

        public Cell(Position pos, bool isAlive = false)
        {
            _position = pos;
            IsAlive = isAlive;
        }

        /// <summary>
        /// Set the status of a cell (Alive or Dead) according to the following rules:
        /// 1.- Any live cell with fewer than two live neighbours dies, as if caused by under-population.
        /// 2.- Any live cell with two or three live neighbours lives on to the next generation.
        /// 3.- Any live cell with more than three live neighbours dies, as if by over-population.
        /// 4.- Any dead cell with exactly three live neighbours becomes a live cell, as if by reproduction.
        /// </summary>
        /// <param name="neighbors"></param>
        public void SetAliveStatus(Cell[] neighbors)
        {
            int neighborsAlive = neighbors.Where(x => x.IsAlive).Count();
            if (IsAlive && (neighborsAlive == 3 || neighborsAlive == 2))//Should live
                IsAlive = true;
            if (IsAlive && neighborsAlive > 3 || neighborsAlive < 2)
                IsAlive = false;
            if (!IsAlive && neighborsAlive == 3)//Born
                IsAlive = true;
        }

    }
}
