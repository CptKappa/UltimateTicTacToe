using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UltimateTicTacToeLib;

namespace TicTacToeConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            (int, int) input;
            int x, y;
            
            bool parseRes;
            bool setRes;

            GameMaster gm = new GameMaster();
            gm.Win += Gm_Win;

            gm.Start();

            while (gm.Running)
            {
                ShowGame(gm);

                Console.WriteLine();
                
                parseRes = false;
                setRes = false;

                Console.WriteLine("INPUT-FORMAT: \"x,y\"");

                while (!(parseRes && setRes))
                {
                    parseRes = TryParseInput(Console.ReadLine(), out input);

                    if (parseRes)
                    {
                        (x, y) = input;

                        setRes = gm.Set(x, y);
                    }
                }
            }



            Console.ReadKey();
        }

        private static void Gm_Win(object sender, WinEventArgs e)
        {
            ShowGame((GameMaster)sender);

            Console.WriteLine();
            Console.WriteLine("WINNER: " + Enum.GetName(typeof(Labels), e.Winner));
        }

        static bool TryParseInput(string input, out (int, int) output)
        {
            bool result = true;
            output = (-1, -1);

            string[] parts = input.Split(',');

            if (parts.Length != 2) return false;

            result &= int.TryParse(parts[0].Trim(), out output.Item1);
            result &= int.TryParse(parts[1].Trim(), out output.Item2);

            return result;
        }

        static void ShowGame(GameMaster gm)
        {
            int fieldX, fieldY;
            int tileX, tileY;

            Labels label;

            Console.Clear();

            Console.WriteLine("    0   1   2   3   4   5   6   7   8");

            for (int y = 0; y < 9; y++)
            {
                Console.Write(" " + y + " ");

                for (int x = 0; x < 9; x++)
                {
                    fieldX = x / 3;
                    tileX = x % 3;

                    fieldY = y / 3;
                    tileY = y % 3;

                    label = gm.Get(fieldX, fieldY, tileX, tileY);

                    Console.Write(" {0} ", label == Labels.None ? " " : Enum.GetName(typeof(Labels), label));

                    if (x < 8)
                    {
                        if ((x+1) % 3 == 0)
                        {
                            Console.Write("|");
                        }
                        else
                        {
                            Console.Write(":");
                        }
                    }
                }

                Console.WriteLine();

                if (y < 8)
                {
                    if ((y + 1) % 3 == 0)
                    {
                        Console.WriteLine("   -----------------------------------");
                    }
                    else
                    {
                        Console.WriteLine("   ...................................");
                    }
                }
            }
        }
    }
}
