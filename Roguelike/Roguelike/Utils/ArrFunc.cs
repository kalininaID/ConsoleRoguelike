using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Roguelike.Components;

namespace Roguelike
{
    internal class ArrFunc
    {
        public static string[][] Join(string[][] arr1, string[][] arr2)
        {
            int rowCount = Math.Min(arr1.Length, arr2.Length);

            string[][] join_arr = new string[rowCount][];

            for (int i = 0; i < rowCount; i++)
            {
                join_arr[i] = new string[arr1[i].Length + arr2[i].Length];

                Array.Copy(arr1[i], 0, join_arr[i], 0, arr1[i].Length);
                Array.Copy(arr2[i], 0, join_arr[i], arr1[i].Length, arr2[i].Length);
            }

            return join_arr;
        }

        public static string[][] TextInArr(string[][] arr, string text, int line = 0, int marginLeft = 0, Position pos = Position.Center)
        {
            int buff = marginLeft;

            if (pos == Position.Center)
            {
                buff = buff + (arr[0].Length - text.Length) / 2;
            }
            if (pos == Position.Right)
            {
                buff = buff + arr.Length - text.Length;
            }

            for (int i = buff; i < buff + text.Length; i++)
            {
               // arr[line][i] = text[i - buff];
            }
            return arr;
        }
    }
}
