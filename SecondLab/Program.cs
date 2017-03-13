using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SecondLab
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {

                Console.WriteLine("Do you want to take values for field from a file? \nYes - Y , no - press any other key");
                char answer;
                answer = Convert.ToChar(Console.ReadLine());


                Game game;

                if (answer == 'y' || answer == 'Y' || answer == 'Н' || answer == 'н')
                {
                    StreamReader file = new StreamReader(@"C:\Users\User\Desktop\laba\text.txt"); 
                    game = new Game(txt_file.reader(file));
                }
                else game = new Game(1, 2, 3, 4, 5, 6, 7, 0, 8);



                Printer.Print(game);


                
                //  Console.WriteLine(game[0,1]);

                while (!game.End_of_the_game())
                {

                    Console.WriteLine("Enter the value you want to move");
                    start:
                    int value = 0;

                    value = Convert.ToInt32(Console.ReadLine());

              //      Console.WriteLine("Координаты выбранного элемента до перестановки: {0},{1}", game.GetLocation(value).x, game.GetLocation(value).y);

                    if (value <= 0 || value >= game.Field.Length)
                    {
                        Console.WriteLine("Error: this value doesn't exist");
                        goto start;
                    }


                    if (game.Shift(value) == false)
                    {
                        Console.WriteLine("Error: Change your value, because you can't move it");
                        goto start;
                    }
                    Printer.Print(game);
                 //   Console.WriteLine("Координаты выбранного элемента после перестановки: {0},{1}", game.GetLocation(value).x, game.GetLocation(value).y);

                }
                    Console.WriteLine("Game over. You win!");
                }
            
            
            catch (Exception)
            {
                Console.WriteLine("Game doesn't exist");

            }

        

            Console.ReadLine();

        }
    }
}
