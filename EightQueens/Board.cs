using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EightQueens
{
    public class Board
    {
        // For testing purposes - easier to see what's happening using the char grid 
        // than the 2D bool array
        public char[,] Grid { get; set; }

        // A 'safe spot' is an unoccoupied square on the board that is not in danger of 
        // being attacked by another queen
        public bool[,] SafeSpots { get; set; }

        public bool[,] QueenLocations { get; set; }
        public int[] Spot { get; set; }
        public int QueensPlaced { get; set; }
        public int SpotsFree { get; set; }
        public Random rand = new Random();

        public Board()
        {
            QueenLocations = new bool[8,8];
            SafeSpots = new bool[8, 8];
            Grid = new char[8, 8];
            Spot = new int[2];
            QueensPlaced = 0;
            SpotsFree = 64;
        }

        public void InitSafeSpots()
        {
            for(var row = 0; row < 8; row++)
            {
                for(var col = 0; col < 8; col++)
                {
                    SafeSpots[row, col] = true;
                }
            }
        }

        public void InitGrid()
        {
            for (var row = 0; row < 8; row++)
            {
                for (var col = 0; col < 8; col++)
                {
                    Grid[row, col] = 'T';
                }
            }
        }

        public void GenerateSpot()
        {
            var x = rand.Next(0, 8);
            var y = rand.Next(0, 8);
            Spot[0] = x;
            Spot[1] = y;
        }

        public bool IsSafeSpot()
        {
            if (SafeSpots[Spot[0], Spot[1]] == true)
                return true;
            else return false;
        }

        public void UpdateSpots()
        {
            QueenLocations[Spot[0], Spot[1]] = true;
            QueensPlaced++;
            SafeSpots[Spot[0], Spot[1]] = false;
            Grid[Spot[0], Spot[1]] = 'F';
            SpotsFree--;
            UpdateSafeSpots();
        }

        public void UpdateSafeSpots()
        {
            var x = Spot[0];
            var y = Spot[1];

            // Mark spots on the queen's vertical axis as unsafe
            for(var row = x; row >= 0; row--)
            {
                SafeSpots[row, y] = false;
                Grid[row, y] = 'F';
                  SpotsFree--;
            }

            for (var row = x; row < 8; row++)
            {
                SafeSpots[row, y] = false;
                Grid[row, y] = 'F';
                SpotsFree--;
            }

            // Mark spots on the queeen's horizontal axis as unsafe
            for (var col = y; col >= 0; col--)
            {
                SafeSpots[x, col] = false;
                Grid[x, col] = 'F';
                SpotsFree--;
            }

            for (var col = y; col < 8; col++)
            {
                SafeSpots[x, col] = false;
                Grid[x, col] = 'F';
                SpotsFree--;
            }

            // Mark spots on the queen's diagonal axis as unsafe
            // Southeast direction
            var x2 = x;
            var y2 = y;
            while (x2 < 7 && y2 < 7)
            {
                x2++;
                y2++;
                SafeSpots[x2, y2] = false;
                Grid[x2, y2] = 'F';
            }

            // Southwest
            var x3 = x;
            var y3 = y;
            while (x3 > 0 && y3 < 7)
            {
                x3--;
                y3++;
                SafeSpots[x3, y3] = false;
                Grid[x3, y3] = 'F';
            }

            // Northwest
            var x4 = x;
            var y4 = y;
            while (x4 > 0 && y4 > 0)
            {
                x4--;
                y4--;
                SafeSpots[x4, y4] = false;
                Grid[x4, y4] = 'F';
            }

            // Northeast
            var x5 = x;
            var y5 = y;
            while (x5 < 7 && y5 > 0)
            {
                x5++;
                y5--;
                SafeSpots[x5, y5] = false;
                Grid[x5, y5] = 'F';
            }
        }

        public void DisplayQueenLocations()
        {
            for(var row = 0; row < 8; row++)
            {
                for(var col = 0; col < 8; col++)
                {
                    Console.Write(QueenLocations[row, col] + " ");
                }
                Console.WriteLine();
            }
        }

        public void DisplayGrid()
        {
            for (var row = 0; row < 8; row++)
            {
                for (var col = 0; col < 8; col++)
                {
                    Console.Write(Grid[row, col] + " ");
                }
                Console.WriteLine();
            }
        }

        public void DisplaySafeSpots()
        {
            for (var row = 0; row < 8; row++)
            {
                for (var col = 0; col < 8; col++)
                {
                    Console.Write(SafeSpots[row, col] + " ");
                }
                Console.WriteLine();
            }
        }

        public bool PlaceQueens()
        {
            while (QueensPlaced < 8 && SpotsFree >= 0)
            {
                GenerateSpot();
                var isSafeSpot = IsSafeSpot();
                if (isSafeSpot)
                {
                    UpdateSpots();
                }
            }

            if (QueensPlaced == 8)
                return true;
            else return false;

        }
    }
}
