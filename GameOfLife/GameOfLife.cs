using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    /// <summary>
    /// GameOfLife: This class performs Conway's Game of Life using the Blinker Pattern
    /// </summary>
    public class GameOfLife
    {
        private Cell[,] Cells { get; set; }

        /// <summary>
        /// Initialize the class with the quantity of cells in the Life Board
        /// </summary>
        /// <param name="cells">Number of cells [x,y]</param>
        public GameOfLife(Cell[,] cells)
        {
            Cells = cells;
            Initialize();
            ApplyPattern();
        }

        private void Initialize()
        {
            for (int i = 0; i < Cells.GetLength(0); i++)
            {
                for (int j = 0; j < Cells.GetLength(1); j++)
                {
                    Cells[i, j] = new Cell(new Position(i, j));
                }
            }
        }

        /// <summary>
        /// Applies the Blink Pattern according to this page: https://en.wikipedia.org/wiki/Conway%27s_Game_of_Life
        /// </summary>
        private void ApplyPattern()
        {
            int c = 0;
            for (int i = 0; i < Cells.GetLength(0); i++)
            {
                for (int j = 0; j < Cells.GetLength(1); j++)
                {
                    if (i % 2 == 0)
                    {
                        Cells[i, j].IsAlive = c == 0 ? false : true;
                        c++;
                        if (c == 4) c = 0;
                    }
                }
            }
        }

        /// <summary>
        /// Creates a new Generation depending on the actual state of every cell
        /// </summary>
        private void CreateGeneration()
        {
            Console.Clear();
            int aliveCells = 0;
            for (int i = 0; i < Cells.GetLength(0); i++)
            {
                for (int j = 0; j < Cells.GetLength(1); j++)
                {
                    UpdateCellStatus(Cells[i, j]);
                    if (Cells[i, j].IsAlive) aliveCells++;
                    Console.Write(String.Format(" {0} ", Cells[i, j].IsAlive ? "x" : "-"));
                }
                Console.WriteLine("\n");
            }
            System.Threading.Thread.Sleep(1000);
        }

        /// <summary>
        /// Update the status of a cell according to the rules
        /// </summary>
        /// <param name="cell">The cell that will be updated according to the rules</param>
        private void UpdateCellStatus(Cell cell)
        {
            Cell[] neighbors = new Cell[8];
            neighbors[0] = GetNeighbor(cell.PosX - 1, cell.PosY - 1);//Top left
            neighbors[1] = GetNeighbor(cell.PosX, cell.PosY - 1);//Top
            neighbors[2] = GetNeighbor(cell.PosX + 1, cell.PosY - 1);//Top right 
            neighbors[3] = GetNeighbor(cell.PosX - 1, cell.PosY);//left
            neighbors[4] = GetNeighbor(cell.PosX + 1, cell.PosY);//right
            neighbors[5] = GetNeighbor(cell.PosX - 1, cell.PosY + 1);//bottom left
            neighbors[6] = GetNeighbor(cell.PosX, cell.PosY + 1);//bottom
            neighbors[7] = GetNeighbor(cell.PosX + 1, cell.PosY + 1);//bottom right
            cell.SetAliveStatus(neighbors);
        }

        /// <summary>
        /// Get the neighbor of the cell at the current position (x,y)
        /// </summary>
        /// <param name="posX">PosX</param>
        /// <param name="posY">PosY</param>
        /// <returns></returns>
        private Cell GetNeighbor(int posX, int posY)
        {
            int totalRows = Cells.GetLength(0);
            int totalCols = Cells.GetLength(1);
            Cell neighbor = new Cell();
            if ((posX >= 0 && posX < totalRows) && (posY >= 0 && posY < totalCols))
                neighbor = Cells[posX, posY];
            return neighbor;
        }

        /// <summary>
        /// Starts the creation of 200 generations in the game
        /// </summary>
        public void Init()
        {
            for (int i = 0; i < 200; i++)
                CreateGeneration();
        }
    }
}
