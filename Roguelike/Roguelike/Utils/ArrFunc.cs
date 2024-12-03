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
        public static int[][] Join(int[][] arr1, int[][] arr2)
        {
            int rowCount = Math.Min(arr1.Length, arr2.Length);

            int[][] joinArr = new int[rowCount][];

            for (int i = 0; i < rowCount; i++)
            {
                joinArr[i] = new int[arr1[i].Length + arr2[i].Length];

                Array.Copy(arr1[i], 0, joinArr[i], 0, arr1[i].Length);
                Array.Copy(arr2[i], 0, joinArr[i], arr1[i].Length, arr2[i].Length);
            }

            return joinArr;
        }

        public static string[][] Join(string[][] arr1, string[][] arr2)
        {
            int rowCount = Math.Min(arr1.Length, arr2.Length);

            string[][] joinArr = new string[rowCount][];

            for (int i = 0; i < rowCount; i++)
            {
                joinArr[i] = new string[arr1[i].Length + arr2[i].Length];

                Array.Copy(arr1[i], 0, joinArr[i], 0, arr1[i].Length);
                Array.Copy(arr2[i], 0, joinArr[i], arr1[i].Length, arr2[i].Length);
            }

            return joinArr;
        }
        public static string[][] ArrInArr(string[][] mainArr, string[][] littleArr, int line = 0, int margin = 0, Position pos = Position.Center)
        {
            if (pos == Position.Center)
            {
                margin = (mainArr[0].Length - littleArr[0].Length) / 2;
            }
            if (pos == Position.Right)
            {
                margin = mainArr[0].Length - littleArr[0].Length - margin;
            }

            for (int i = 0; i < littleArr.Length; i++)
            {
                for (int j = margin; j < margin + littleArr[0].Length; j++)
                {
                    mainArr[line + i][j] = littleArr[i][j - margin];
                }
            }

            return mainArr;
        }

        public static int[][] ArrInArr(int[][] mainArr, int[][] littleArr, int line = 0, int margin = 0, Position pos = Position.Center)
        {
            if (pos == Position.Center)
            {
                margin = (mainArr[0].Length - littleArr[0].Length) / 2;
            }
            if (pos == Position.Right)
            {
                margin = mainArr[0].Length - littleArr[0].Length - margin;
            }

            for (int i = 0; i < littleArr.Length; i++)
            {
                for (int j = margin; j < margin + littleArr[0].Length; j++)
                {
                    mainArr[line + i][j] = littleArr[i][j - margin];
                }
            }

            return mainArr;
        }

        public static string[][] TextInArr(string[][] arr, string text, int line = 0, int margin = 0, Position pos = Position.Center)
        {
            if (pos == Position.Center)
            {
                if (arr[0].Length != text.Length)
                {
                    margin = margin + (arr[0].Length - text.Length) / 2;
                }
            }
            if (pos == Position.Right)
            {
                margin = arr[0].Length - text.Length - margin;
            }

            for (int i = margin; i < margin + text.Length; i++)
            {
                arr[line][i] = text[i - margin].ToString();
            }
            return arr;
        }

        public static int[][] CreateEmptyArray(int whight, int height, int val)
        {
            int[][] arr = new int[height][];

            for (int i = 0; i < height; i++)
            {
                arr[i] = new int[whight];
                for (int j = 0; j < whight; j++)
                {
                    arr[i][j] = val;
                }
            }
            return arr;
        }

        public static string[][] CreateEmptyArray(int width, int height, string val)
        {
            string[][] arr = new string[height][];

            for (int i = 0; i < height; i++)
            {
                arr[i] = new string[width];
                for (int j = 0; j < width; j++)
                {
                    arr[i][j] = val;
                }
            }
            return arr;
        }
    }
}
