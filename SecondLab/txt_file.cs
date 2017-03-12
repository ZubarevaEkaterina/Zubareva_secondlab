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
        public static int[] (StreamReader file)
        {
            string line = file.ReadToEnd();
            string[] spliter = line.Split(new Char[] { ' ' });

            int[] intspliter = new int[spliter.Length];

            for (int i = 0; i < intspliter.Length; i++)
            {
                intspliter[i] = Convert.ToInt32(spliter[i]);
            }

            return intspliter;
        }
    }
}