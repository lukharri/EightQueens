using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EightQueens
{
    /*
     * Brute force algorithm that attempts to find a soloution to the 'Eight Queens' problem.
     * Problem Domain: Can 8 Queens be placed on a chess board such that they cannot be attacked
     *                 by any of the other queens?
     */
    class Program
    {
        static void Main(string[] args)
        {
            bool canPlace = true;
            Board board;
            var counter = 0;

            do
            {
                board = new Board();
                board.InitSafeSpots();
                board.InitGrid();
                counter++;
                Console.WriteLine();
                Console.WriteLine(counter);
                canPlace = board.PlaceQueens();
                board.DisplayGrid();

            } while (!canPlace);

            board.DisplayGrid();
            board.DisplayQueenLocations();
        }
    }
}
