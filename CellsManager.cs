using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeC_
{
    internal class CellsManager
    {
        public int[] cells = new int[9];
        public bool[] cellsOpen = new bool[9];
        public bool stopGame = false;
        public void WriteBoard()
        {
            Console.WriteLine(" ");
            //Console.WriteLine("  A  B  C");

            for (int i = 0; i < 3; i++)
            {
                WriteCells(i);
            }
            Console.WriteLine("");
            for (int i = 3; i < 6; i++)
            {
                WriteCells(i);              
            }
            Console.WriteLine("");
            for (int i = 6; i < 9; i++)
            {
                WriteCells(i);
            }
            Console.WriteLine("");
        }
        public void WriteCells(int i)
        {
            if (cells[i] == 0)
            {
                Console.Write("|   |");
            }
            else if (cells[i] == 1)
            {
                Console.Write("| X |");
            }

            else if (cells[i] == 2)
            {
                Console.Write("| 0 |");
            }
        }

        public void CheckWinner()
        {
            // first row
            if (cells[0] == cells[1] && cells[0] == cells[2] && cells[0]!= 0)
            {
                WhoWin(0);
            }
            // second row
            if (cells[3] == cells[4] && cells[3] == cells[5] && cells[3] != 0)
            {
                WhoWin(3);
            }
            // third row
            if (cells[6] == cells[7] && cells[6] == cells[8] && cells[6] != 0)
            {
                WhoWin(6);
            }

            // first column
            if (cells[0] == cells[3] && cells[0] == cells[6] && cells[0] != 0)
            {
                WhoWin(0);
            }
            // second column
            if (cells[1] == cells[4] && cells[1] == cells[7] && cells[1] != 0)
            {
                WhoWin(1);
            }
            // third column
            if (cells[2] == cells[5] && cells[2] == cells[8] && cells[2] != 0)
            {
                WhoWin(2);
            }

            // first diagonal
            if (cells[0] == cells[4] && cells[0] == cells[8] && cells[0] != 0)
            {
                WhoWin(0);
            }
            // second diagonal
            if (cells[2] == cells[4] && cells[2] == cells[6] && cells[2] != 0)
            {
                WhoWin(2);
            }
        }

        public void WhoWin(int c)
        {
            Console.WriteLine("");
            Console.WriteLine("----------------");
            if (cells[c] == 1)
            {
                Console.WriteLine("PLAYER 1 WIN");
                stopGame = true;
            }
            if (cells[c] == 2)
            {
                Console.WriteLine("PLAYER 2 WIN");
                stopGame = true;
            }
            Console.WriteLine("----------------");
            Console.WriteLine("");
        }

        public void CheckDraw()
        {
            if(stopGame) return;

            int drawCounter = 0;
            for(int i = 0; i < 9; i++)
            {
                if (cellsOpen[i] == false)
                {
                    drawCounter++;
                }
                else
                {
                    break;
                }
            }

            if(drawCounter == 9)
            {
                Console.WriteLine("");
                Console.WriteLine("----------------");
                Console.WriteLine("NO ONE WINS, DRAW");
                Console.WriteLine("----------------");
                Console.WriteLine("");
                stopGame = true;
            }
            else { drawCounter = 0; }
        }
    }
}
