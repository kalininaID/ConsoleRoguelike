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
                buff = (mainArr[0].Length - littleArr[0].Length) / 2;
            }
            if (pos == Position.Right)
            {
                buff = mainArr[0].Length - littleArr[0].Length;
            }

            for (int i = 0; i < littleArr.Length; i++)
            {
                for (int j = buff; j < buff + littleArr[0].Length; j++)
                {
                    mainArr[line + i][j] = littleArr[i][j - buff];
                }
            }

            return mainArr;
        }

        public static char[][] TextInArr(char[][] arr, string text, int line = 0, int margin = 0, Position pos = Position.Center)
        {
            int buff = margin;

            if (pos == Position.Center)
            {
                if (arr[0].Length != text.Length)
                {
                    buff = buff + (arr[0].Length - text.Length) / 2;
                }
            }
            if (pos == Position.Right)
            {
                buff = arr[0].Length - text.Length - margin;
            }

            for (int i = buff; i < buff + text.Length; i++)
            {
                arr[line][i] = text[i - buff];
            }
            return arr;
        }
    }
}
