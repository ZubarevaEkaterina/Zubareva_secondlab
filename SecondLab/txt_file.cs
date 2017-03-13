using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SecondLab
{

    class txt_file
    {
        public static int[] reader(StreamReader file)
        {
            string line = file.ReadToEnd();
            string[] spliter = line.Split(new Char[] { ' ', ',', ';', '.' });


            int[] numbers = new int[spliter.Length];

            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = Convert.ToInt32(spliter[i]);
            }

            return numbers;
        }
    }
}