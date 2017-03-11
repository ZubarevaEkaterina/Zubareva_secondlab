using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondLab
{
  class Game
    { private int Size_of_field;
        public int[,] Field { get; set; }
        private Coordinates[] coordinates;

        public Game(params int[] field)
        {
            {

                if (field.Length % Math.Sqrt(field.Length) != 0)
                {
                    throw new ArgumentException("Error: Wrong number of parameters");
                }

                if (Array.IndexOf(field, 0) < 0)
                {
                    throw new Exception("Error: All cells are filled");
                }



                Size_of_field = Convert.ToInt32(Math.Sqrt(field.Length));


                Field = new int[Size_of_field, Size_of_field];
                coordinates = new Coordinates[field.Length];

                int index = 0;
                for (int x = 0; x < Size_of_field; x++)
                {
                    for (int y = 0; y < Size_of_field; y++)
                    {
                        if (index != field.Length)
                        {
                            Field[x, y] = field[index];
                            coordinates[field[index]] = new Coordinates(x, y);
                            index++;
                        }
                        }
                }
            }
        }


        public Coordinates GetLocation(int value)
        {
            
            return coordinates[value];
        }


        public bool Shift(int value)
        {
            
            Coordinates zeroPoint = GetLocation(0);
    
            Coordinates selectedPoint = GetLocation(value);


            if ((Math.Abs(selectedPoint.x - zeroPoint.x) == 1 && (selectedPoint.y == zeroPoint.y)) ||
              (Math.Abs(selectedPoint.y - zeroPoint.y) == 1 && (selectedPoint.x == zeroPoint.x)))
            { 

            {
                    var t = Field[zeroPoint.x, zeroPoint.y];
                    Field[zeroPoint.x, zeroPoint.y] = Field[selectedPoint.x, selectedPoint.y];
                    Field[selectedPoint.x, selectedPoint.y] = t;


                    Coordinates temp = coordinates[t];
                    coordinates[t] = coordinates[Field[zeroPoint.x, zeroPoint.y]];
                    coordinates[Field[zeroPoint.x, zeroPoint.y]] = temp;


                }
                return true; }


            else return false;

              
            



        }



        public void Print()
        {
            for (int x = 0; x <Field.GetLength(0); ++x)
            {
                for (int y = 0; y < Field.GetLength(1); ++y)
                {
                    Console.Write(Field[x, y] + " ");
                }
                Console.WriteLine();
            }

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
        
    }
}
    