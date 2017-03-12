﻿using System;
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
            Console.WriteLine("Хотите перейти к файлу? Да - y , нет - любая другая клавиша");
            char answer;
            answer = Convert.ToChar(Console.ReadLine());
            StreamReader file = new StreamReader(@"C:\Users\User\Desktop\laba\text.txt");
            Game game;

            if (answer == 'y')
            {
                game = new Game(txt_file.m(file));
            }
            else game = new Game(1, 2, 3, 4, 5, 6, 7, 8, 0);
            
            Printer.Print(game);
            
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
                    goto start; 
                }
                Printer.Print(game);

            }
           
            Console.WriteLine("Game over. You win!");


            Console.ReadLine();

        }
    }
}
