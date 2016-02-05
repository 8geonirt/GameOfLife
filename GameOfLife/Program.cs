using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    /// <summary>
    /// Game of Life Programm
    /// Autor: José Trinidad Espinoza González
    /// Email: trinoeg8@gmail.com
    /// Creation: 05/02/2016
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            GameOfLife game = new GameOfLife(new Cell[24, 24]);
            game.Init();
            Console.ReadKey();
        }
    }
}
