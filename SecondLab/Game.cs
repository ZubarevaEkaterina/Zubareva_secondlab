using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SecondLab
{
  class Game
    {   public readonly int Size_of_field;
        public readonly int[,] Field;
        private Locations[] location;

        public Game(params int[] field)
        {
            {
             //   string line = @"C:\Users\User\Desktop\laba\text.csv";
              //  FromCSV(line);

              Check(field);
             
                Size_of_field = Convert.ToInt32(Math.Sqrt(field.Length));

                Field = new int[Size_of_field, Size_of_field];
                
                location = new Locations[field.Length];

                int index = 0;
                for (int x = 0; x < Size_of_field; x++)
                {
                    for (int y = 0; y < Size_of_field; y++)
                    {
                        if (index != field.Length)
                        {
                            Field[x, y] = field[index];
                            location[field[index]] = new Locations(x, y);
                            index++;
                        }
                        }
                }

               
            }
        }
       



        public void Check(int[] field)
        {

           if (field.Length % Math.Sqrt(field.Length) != 0)
            {
                throw new ArgumentException("Error: Wrong number of parameters");
            }

            if (Array.IndexOf(field, 0) < 0)
            {
                throw new Exception("Error: All cells are filled");
            }

            for (int i = 0; i < field.Length; i++)
            {
                for (int j = 0; j < field.Length; j++)
                {
                    if (field[i] == field[j] && i != j)
                    {
                        throw new Exception("Error: The values are repeated");
                    }
                    
                }
            }
        }

        public Locations GetLocation(int value)
        {
            return location[value];
        }

        public int this[int x, int y]
        {
            get
            {
                return Field[x, y];
            }
            set
            {
                Field[x, y] = value;
            }
        }


        public bool Shift(int value)
        {
            
            Locations zeroPoint = GetLocation(0);
    
            Locations selectedPoint = GetLocation(value);


            if ((Math.Abs(selectedPoint.x - zeroPoint.x) == 1 && (selectedPoint.y == zeroPoint.y)) ||
              (Math.Abs(selectedPoint.y - zeroPoint.y) == 1 && (selectedPoint.x == zeroPoint.x)))
            

            {
                    var t = Field[zeroPoint.x, zeroPoint.y];
                    Field[zeroPoint.x, zeroPoint.y] = Field[selectedPoint.x, selectedPoint.y];
                    Field[selectedPoint.x, selectedPoint.y] = t;


                    Locations temp = location[t];
                    location[t] = location[Field[zeroPoint.x, zeroPoint.y]];
                    location[Field[zeroPoint.x, zeroPoint.y]] = temp;

                return true;
            }
               


            else return false;
        }


        public bool End_of_the_game()
        {

        int k=1;
            for (int x = 0; x < Size_of_field; x++)
            {
                for (int y = 0; y < Size_of_field; y++)
                {
                    if (Field[x, y] != k && k < Field.Length)

                        return false;
                        k++;

                }
            }
              return true;

        }

        public static Game FromCSV(string file)
        {
           
            string[] lines = File.ReadAllLines(file);
            int size = lines.Length;
            string temp;
            int[] numbers = new int[size * size];
            int k = 0;

          

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    temp = lines[i].Substring(0, lines[i].IndexOf(',')).Trim();
                    numbers[k] = Convert.ToInt32(temp);
                    lines[i] = lines[i].Substring(lines[i].IndexOf(','));
                    k++;
                }
            }
            return new Game(numbers);
        }

    }
}
    