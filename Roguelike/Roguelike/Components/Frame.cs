using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roguelike.Components
{

    public class Frame
    {
        public string[][] VisualArr { get; set; }
        public int[][] ColorsArr { get; set; }

        public enum TypeBorder
        {
            STANDARD,
            DOUBLE,
            DOTTED,
            ROUNDED,
            EXRTABOLD
        }

        public Frame(int wight, int hieght)
        {
            VisualArr = ArrFunc.CreateEmptyArray(wight, hieght, " ");
            ColorsArr = ArrFunc.CreateEmptyArray(wight, hieght, 0);
        }

        public void DrawBorders(Colors colorBorder = Colors.WHITE, TypeBorder typeBorder = TypeBorder.STANDARD)
        {
            string[] border;
            switch (typeBorder)
            {
                case TypeBorder.STANDARD:
                    border = ["┌", "┐", "└", "┘", "─", "│"];
                    break;
                case TypeBorder.DOUBLE:
                    border = ["╔", "╗", "╚", "╝", "═", "║"];
                    break;
                case TypeBorder.DOTTED:
                    border = ["┌", "┐", "└", "┘", "╌", "┆"];
                    break;
                case TypeBorder.ROUNDED:
                    border = ["╭", "╮", "╰", "╯", "─", "│"];
                    break;
                case TypeBorder.EXRTABOLD:
                    border = ["▅", "▅", "█", "█", "▅", "█"];
                    break;
                default:
                    border = ["┌", "┐", "└", "┘", "─", "│"];
                    break;
            }

            VisualArr[0][0] = border[0];
            VisualArr[0][VisualArr[0].Length - 1] = border[1];
            VisualArr[VisualArr.Length - 1][0] = border[2];
            VisualArr[VisualArr.Length - 1][VisualArr[0].Length - 1] = border[3];

            for (int i = 0; i < VisualArr.Length; i++)
            {
                for (int j = 0; j < VisualArr[0].Length; j++)
                {
                    if ((i == 0 && j == 0) || (i == VisualArr.Length-1 && j == VisualArr[0].Length - 1) ||
                        (i == VisualArr.Length - 1 && j == 0) || (i == 0 && j == VisualArr[0].Length - 1))
                    {
                        ColorsArr[i][j] = (int)colorBorder;
                        continue;
                    } else
                    {
                        if (i == 0 || i == VisualArr.Length - 1)
                        {
                            ColorsArr[i][j] = (int)colorBorder;
                            VisualArr[i][j] = border[4];
                        }
                        if (j==0 || j == VisualArr[0].Length - 1)
                        {
                            ColorsArr[i][j] = (int)colorBorder;
                            VisualArr[i][j] = border[5];
                        }
                    }
                }
            }
        }

        public void Draw()
        {
            for (int i = 0; i < VisualArr.Length; i++)
            {
                for (int j = 0; j < VisualArr[i].Length; j++)
                {
                    if (ColorsArr[i][j] == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else if (ColorsArr[i][j] == 1)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    else if (ColorsArr[i][j] == 2)
                    {
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                    else if (ColorsArr[i][j] == 3)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }

                    Console.Write(VisualArr[i][j]);
                }
                Console.WriteLine();
            }
            Console.ResetColor();
        }

        public void Paint(Colors colorBorder = Colors.WHITE)
        {
            for (int i = 0; i < ColorsArr.Length; i++)
            {
                for (int j = 0; j < ColorsArr[i].Length; j++)
                {
                    if (colorBorder == Colors.WHITE)
                    {
                        ColorsArr[i][j] = 0;
                    }
                    else if (colorBorder == Colors.RED)
                    {
                        ColorsArr[i][j] = 1;
                    }
                    else if (colorBorder == Colors.GRAY)
                    {
                        ColorsArr[i][j] = 2;
                    }
                    else if (colorBorder == Colors.GREEN)
                    {
                        ColorsArr[i][j] = 3;
                    }
                }
            }
        }
    }
}
