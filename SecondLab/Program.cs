using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondLab
{
    class Program
    {
        static void Main(string[] args)
        {

            Game game = new Game(1, 2, 3, 4, 5, 6, 7, 0, 8);

            game.Print();

            while (!game.End_of_the_game())
            {

                Console.WriteLine("Enter the value you want to move");
                start:
                int value = 0;
                value = Convert.ToInt32(Console.ReadLine());

              
                if (value <= 0 || value >= game.Field.Length)
                {

                    Console.WriteLine("Error: this value doesn't exists");
                    goto start;
                }


                if (game.Shift(value) == false)
                {
                    Console.WriteLine("Error: Change your value, because you can't move it");
                    game.Print();
                    goto start;
                }
                game.Print();
                 
            }

            Console.WriteLine("Game over. You win!");


            Console.ReadLine();

        }
    }
}
