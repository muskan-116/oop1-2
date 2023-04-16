using EZInput;
using System;
using System.Threading;

namespace Project1
{
    class Program
    {
        static int score = 0;
        static void Main(string[] args)
        {
            int RabbitX = 1;
            int RabbitY = 1;
            char[,] rabbit = new char[5, 8];

            int trollX = 18;
            int trollY = 9;

            char[,] troll = new char[3, 9];
            string troll = "down";

            int gobblinX = 20;
            int gobblinY 10;

            char[,] gobblin = new char[7, 15];
            string gobblin = "down";

            int[]  bullletX = new int [1000];
            int[]  bulletY = new int [1000];
            int bcount = 0;

            char[,] maze = new char[50, 50];




            
            {
            { '%', '%', '%', '%', '%', '%', '%', '%', '%', '%', '%', '%', '%', '%', '%', '%', '%', '%', '%', '%'},
            { '%', ' ', ' ', '.', ' ', '.', '.', '.', ' ', ' ', ' ', ' ', '.', '.', '.', ' ', '.', ' ', '.', '%'},
            { '%', '.', ' ', '.', ' ', ' ', '.', ' ', ' ', ' ', ' ', ' ', ' ', '.', ' ', ' ', '.', ' ', '.', '%'},
            { '%', '.', ' ', '.', ' ', '.', '.', '.', ' ', ' ', ' ', ' ', '.', '.', '.', ' ', '.', ' ', '.', '%'},
            { '%', '.', ' ', '.', ' ', ' ', '.', ' ', ' ', ' ', ' ', ' ', ' ', '.', ' ', ' ', '.', ' ', '.', '%'},
            { '%', '.', ' ', '.', ' ', '.', '.', '.', ' ', ' ', ' ', ' ', '.', '.', '.', ' ', '.', ' ', '.', '%'},
            { '%', '.', ' ', '.', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '.', ' ', '.', '%'},
            { '%', '.', ' ', '.', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '.', ' ', '.', '%'},
            { '%', '.', ' ', '.', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '.', ' ', '.', '%'},
            { '%', '.', ' ', '.', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '.', ' ', '.', '%'},
            { '%', ' ', '.', ' ', '.', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '.', ' ', '.', ' ', '%'},
            { '%', ' ', '.', ' ', '.', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '.', ' ', '.', ' ', '%'},
            { '%', ' ', '.', ' ', '.', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '.', ' ', '.', ' ', '%'},
            { '%', ' ', '.', ' ', '.', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '.', ' ', '.', ' ', '%'},
            { '%', ' ', '.', ' ', ' ', '.', '.', '.', ' ', ' ', ' ', ' ', '.', '.', '.', ' ', ' ', '.', ' ', '%'},
            { '%', ' ', '.', ' ', '.', ' ', '.', ' ', ' ', ' ', ' ', ' ', ' ', '.', ' ', '.', ' ', '.', ' ', '%'},
            { '%', ' ', '.', ' ', ' ', '.', '.', '.', ' ', ' ', ' ', ' ', '.', '.', '.', ' ', ' ', '.', ' ', '%'},
            { '%', ' ', '.', ' ', '.', ' ', '.', ' ', ' ', ' ', ' ', ' ', ' ', '.', ' ', '.', ' ', '.', ' ', '%'},
            { '%', ' ', '.', ' ', ' ', '.', '.', '.', ' ', ' ', ' ', ' ', '.', '.', '.', ' ', ' ', '.', ' ', '%'},
            { '%', '%', '%', '%', '%', '%', '%', '%', '%', '%', '%', '%', '%', '%', '%', '%', '%', '%', '%', '%'}};
            printMaze(maze);
            Console.SetCursorPosition(trollY, trollX);
            Console.SetCursorPosition(RabbitY, RabbitX);
            Console.Write("S");

            while (true)
            {
                Thread.Sleep(150);
                printScore();
                if (Keyboard.IsKeyPressed(Key.UpArrow))
                {
                    moveRabbitUp(maze, ref RabbitX, ref RabbitY);
                }
                if (Keyboard.IsKeyPressed(Key.DownArrow))
                {
                    moveSnakeDown(maze, ref RabbitX, ref RabbitY);
                }
                if (Keyboard.IsKeyPressed(Key.LeftArrow))
                {
                    moveSnakeLeft(maze, ref RabbitX, ref RabbitY);
                }
                if (Keyboard.IsKeyPressed(Key.RightArrow))
                {
                    moveRabbitRight(maze, ref snakeX, ref snakeY);
                }
                moveEnemy(maze, ref enemyX, ref enemyY, ref enemydirection);

            }
        }
        static void printMaze(char[,]maze)
        {
            for (int row = 0; row < 20; row++)
            {
                for (int col = 0; col < 20; col++)
                {
                    Console.Write(maze[row,col]);
                }
            Console.WriteLine();
            }
        }
        static void moveRabbitUp(char[,] maze, ref int RabbitX, ref int RabbitY)
        {
            if (maze[RabbitX - 1, RabbitY] == ' ' || maze[RabbitX - 1, RabbitY] == '.')
            {
                maze[RabbitX, RabbitY] = ' ';
                Console.SetCursorPosition(RabbitY, RabbitX);
                Console.Write(" ");
                RabbitX = RabbitX - 1;
                if (maze[RabbitX, RabbitY] == '.')
                {
                    calculateScore();
                }
                maze[snakeX, snakeY] = 'R';
                Console.SetCursorPosition(RabbitY, RabbitX);
                Console.Write("R");
            }
        }
        static void moveSnakeDown(char[,] maze, ref int RabbitX, ref int RabbitY)
        {
            if (maze[RabbitX + 1, RabbitY] == ' ' || maze[RabbitX + 1, RabbitY] == '.')
            {
                maze[RabbitX, RabbitY] = ' ';
                Console.SetCursorPosition(RabbitY, RabbitX);
                Console.Write(" ");
                RabbitX = RabbitX + 1;
                Console.SetCursorPosition(RabbitY, RabbitX);
                if (maze[RabbitX, RabbitY] == '.')
                {
                    calculateScore();
                }
                maze[RabbitX, RabbitY] = 'R';
                Console.Write("R");
            }
        }
        static void moveSnakeLeft(char[,] maze, ref int snakeX, ref int snakeY)
        {
            if (maze[RabbitX, RabbitY - 1] == ' ' || maze[RabbitX, RabbitY - 1] == '.')
            {
                maze[RabbitX, RabbitY] = ' ';
                Console.SetCursorPosition(RabbitY, RabbitX);
                Console.Write(" ");
                RabbitY = RabbitY - 1;
                if (maze[RabbitX, RabbitY] == '.')
                {
                    calculateScore();
                }
                Console.SetCursorPosition(RabbitY, RabbitX);
                maze[RabbitX, RabbitY] = 'R';
                Console.Write("R");
            }
        }
        static void moveSnakeRight(char[,] maze, ref int RabbitX, ref int RabbitY)
        {
            if (maze[RabbitX, RabbitY + 1] == ' ' || maze[RabbitX, RabbitY + 1] == '.')
            {
                maze[RabbitX, RabbitY] = ' ';
                Console.SetCursorPosition(RabbitY, RabbitX);
                Console.Write(" ");
                RabbitY = RabbitY + 1;
                if (maze[RabbitX, RabbitY] == '.')
                {
                    calculateScore();
                }
                Console.SetCursorPosition(RabbitY, RabbitX);
                maze[RabbitX, RabbitY] = 'R';
                Console.Write("R");
            }
        }
        static void movetroll(char[,] maze, ref int trollX, ref int trollY, ref string trolldirection)
        {
            if (maze[trollX, trollY - 1] == 'R' || maze[trollX, trollY + 1] == 'R' || maze[trollX + 1, trollY] == 'R' || maze[trollX - 1, trollY] == 'R')
            {
                Environment.Exit(0);
            }
            if (enemydirection == "Up")
            {
                if (maze[trollX - 1, trollY] == ' ')
                {
                    maze[trollX, trollY] = ' ';
                    Console.SetCursorPosition(trollY, trollX);
                    Console.Write(" ");
                    trollX = trollX - 1;
                    Console.SetCursorPosition(trollY, trollX);
                    Console.Write("T");
                }
                else
                {
                    trolldirection = "Down";
                }
            }
            if (trolldirection == "Down")
            {
                if (maze[trollX + 1, trollY] == ' ')
                {
                    maze[trollX, trollY] = ' ';
                    Console.SetCursorPosition(trollY, trollX);
                    Console.Write(" ");
                    trollX = trollX + 1;
                    Console.SetCursorPosition(trollY, trollX);
                    Console.Write("T");
                }
                else
                {
                    enemydirection = "Up";
                }
            }
        }
        static void printScore()
        {
            Console.SetCursorPosition(3, 21);
            Console.WriteLine("SCORE: " + score);
        }
        static void calculateScore()
        {
            score ++;
        }
    }
}

