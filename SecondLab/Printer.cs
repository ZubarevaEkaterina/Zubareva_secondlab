using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondLab
{
    class Printer
    {
        static public void Print(Game game)
        {
            for (int x = 0; x < game.Field.GetLength(0); ++x)
            {
                for (int y = 0; y < game.Field.GetLength(1); ++y)
                {
                    Console.Write(game.Field[x, y] + " ");
                }
                Console.WriteLine();
            }


        }
    }
}