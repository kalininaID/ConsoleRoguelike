using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Roguelike.Components;
using static System.Net.Mime.MediaTypeNames;

namespace Roguelike
{
    internal class ArrFunc
    {
        public static char[][] Join(char[][] arr1, char[][] arr2)
        {
            int rowCount = Math.Min(arr1.Length, arr2.Length);

            char[][] joinArr = new char[rowCount][];

            for (int i = 0; i < rowCount; i++)
            {
                joinArr[i] = new char[arr1[i].Length + arr2[i].Length];

                Array.Copy(arr1[i], 0, joinArr[i], 0, arr1[i].Length);
                Array.Copy(arr2[i], 0, joinArr[i], arr1[i].Length, arr2[i].Length);
            }

            return joinArr;
        }

        public static char[][] ArrInArr(char[][] mainArr, char[][] littleArr, int line = 0, Position pos = Position.Center)
        {
            int buff = 0;

            if (pos == Position.Center)
            {
                buff = buff + (mainArr[0].Length - mainArr.Length) / 2;
            }
            if (pos == Position.Right)
            {
                buff = buff + mainArr.Length - mainArr.Length;
            }

            char[][] resArr = new char[mainArr.Length][];

            for (int i = 0; i < littleArr[0].Length; i++)
            {
                for (int j = buff; j < buff + littleArr.Length; i++)
                {
                    mainArr[i][j] = littleArr[i][j - buff];
                }
            }

            return resArr;
        }

        public static char[][] TextInArr(char[][] arr, string text, int line = 0, int marginLeft = 0, Position pos = Position.Center)
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
                arr[line][i] = text[i - buff];
            }
            return arr;
        }
    }
}
