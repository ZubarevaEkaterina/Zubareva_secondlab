using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SecondLab
{
    class Game
    {

        public readonly int[,] Field;
        private Locations[] location;

        public Game(params int[] field)
        {
            {
                Check(field);

                Field = new int[Convert.ToInt32(Math.Sqrt(field.Length)), Convert.ToInt32(Math.Sqrt(field.Length))];

                location = new Locations[field.Length];

                int index = 0;
                for (int x = 0; x < Field.GetLength(0); x++)
                {
                    for (int y = 0; y < Field.GetLength(1); y++)
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
                        throw new Exception("Error: Values are repeated");
                    }

                }
            }
        }

        public Locations GetLocation(int value)
        {
            return location[value];
        }

        public int this[int x, int y]  // позволяет определить, какое значение находится в игре по координате[x, y]. 

        {
            get
            {
                return Field[x, y];
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

            int k = 1;
            for (int x = 0; x < Field.GetLength(0); x++)
            {
                for (int y = 0; y < Field.GetLength(1); y++)
                {
                    if (Field[x, y] != k && k < Field.Length)

                        return false;
                    k++;

                }
            }
            return true;

        }

    }
}
