using System;
using static System.Net.Mime.MediaTypeNames;

namespace TicTacToeC_
{
    internal class Program
    {

        static void Main(string[] args)
        {
            CellsManager cellsManager = new CellsManager();
            foreach(int i in cellsManager.cells)
            {
                cellsManager.cells[i] = 0;
            }
            for(int b = 0;  b < cellsManager.cellsOpen.Length; b++)
            {
                cellsManager.cellsOpen[b] = true;
            }
            //if (cellsManager.cellsOpen[3] == true)
            //{
            //    Console.WriteLine("| trueeee |");
            //}
            //else if (cellsManager.cellsOpen[3] == false)
            //{
            //    Console.WriteLine("| falseeeee |");
            //}
            cellsManager.WriteBoard();

            bool isGame = true;
            bool makeMove = false;
            int turn = 0;

            while (isGame)
            {
                makeMove = false;
                CheckTurn(turn);

                while (makeMove == false)
                { 
                    string input = Console.ReadLine();
                    int move;
                    if(Int32.TryParse(input, out move))
                    {
                        if (move <= 8)
                        {
                            if (cellsManager.cellsOpen[move] == true)
                            {
                                if (turn % 2 == 0)
                                {
                                    cellsManager.cells[move] = 1;
                                    cellsManager.cellsOpen[move] = false;
                                    makeMove = true;
                                }
                                else if (turn % 2 == 1)
                                {
                                    cellsManager.cells[move] = 2;
                                    cellsManager.cellsOpen[move] = false;
                                    makeMove = true;
                                }
                            }
                            else
                            {
                                Console.WriteLine("the cell il full, choose another cell");
                            }
                        }
                        else
                        {
                            Console.WriteLine("please, choose a valid cell");
                        }
                    }
                    else
                    {
                        Console.WriteLine("please, use a number between 0 and 8");
                    }   
                }
                Console.Clear();
                cellsManager.WriteBoard();
                turn++;

                cellsManager.CheckWinner();
                cellsManager.CheckDraw();

                if(cellsManager.stopGame == true)
                {
                    isGame = false;
                }
            }

            //Console.WriteLine("---------------------------");
            //Console.WriteLine("DO YOU WANT TO RESTART?");
            //Console.WriteLine("---------------------------");
            //string restart = Console.ReadLine();
            //if (restart == "yes")
            //{
            //    Console.WriteLine("----------------------");
            //    Console.WriteLine("THERE IS NOT THE CODE NOW");
            //    Console.WriteLine("----------------------");


            //}
            //else if (restart == "no")
            //{
            //    Console.WriteLine("----------------------");
            //    Console.WriteLine("OK! BYE!");
            //    Console.WriteLine("----------------------");
            //}
        }

        public static void CheckTurn(int turn)
        {
            Console.WriteLine(" ");
            if (turn % 2 == 0)
            {
                Console.WriteLine("| PLAYER 1 TURN |");
            }
            else
            {
                Console.WriteLine("| PLAYER 2 TURN |");
            }
            Console.WriteLine(" ");           
        }
    }
}
