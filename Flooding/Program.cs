using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Flood
{
	public enum Directions { TopLeft, Top, TopRight, Left, Right, BotLeft, Bot, BotRight };

	public class Board
	{
		

		private int height, length;
		private Cell[,] board;

		// PLACEHOLDER: Constructor with hard coded board values for test purposes
		public Board()
		{
			height = 4;
			length = 4;

			board = new Cell[height, length];

			board[0, 0] = new Cell(2,0);
			board[1, 0] = new Cell(7,0);
			board[2, 0] = new Cell(2,0);
			board[3, 0] = new Cell(4,2);

			board[0, 1] = new Cell(3,4);
			board[1, 1] = new Cell(10,0);
			board[2, 1] = new Cell(5,2);
			board[3, 1] = new Cell(1,3);

			board[0, 2] = new Cell(2,2);
			board[1, 2] = new Cell(6,0);
			board[2, 2] = new Cell(3,5);
			board[3, 2] = new Cell(5,3);

			board[0, 3] = new Cell(1,3);
			board[1, 3] = new Cell(7,8);
			board[2, 3] = new Cell(6,2);
			board[3, 3] = new Cell(4,3);
		}

		public Board(int height, int length)
		{
			this.height = height;
			this.length = length;

			board = new Cell[height, length];

			for (int x = 0; x < length; x++)
			{
				for (int y = 0; y < height; y++)
				{
					board[x, y] = new Cell();
				}
			}
		}

		public void print()
		{
			for (int y = 0; y < this.length; y++)
			{
				for (int x = 0; x < this.height; x++)
				{
					System.Console.Write(board[x, y] + "\t");
				}
				System.Console.Write("\n");
			}
		}

		public void floodNeighbours()
		{

			// Find lower
			// how?

		}

		// PLACEHOLDE: for testing only
		public void test()
		{
			int x1, x2, y1, y2;

			x1 = 0;
			y1 = 0;
			x2 = 0;
			y2 = 1;

			if (board[x1, y1].canFlood(board[x2, y2]))
				System.Console.WriteLine("{0} can flood {1}", board[x1, y1], board[x2, y2]);
			else
				System.Console.WriteLine("{0} cannot flood {1}", board[x1, y1], board[x2, y2]);

			if (board[x1, y1] > board[x2, y2])
				System.Console.WriteLine("{0} is greater than {1}", board[x1, y1], board[x2, y2]);
			else if (board[x1, y1] < board[x2, y2])
				System.Console.WriteLine("{0} is lesser than {1}", board[x1, y1], board[x2, y2]);
			else if (board[x1, y1] == board[x2, y2])
				System.Console.WriteLine("{0} is equal to {1}", board[x1, y1], board[x2, y2]);

			System.Console.WriteLine();

			x1 = 1;
			y1 = 1;
			x2 = 0;
			y2 = 0;

			if (board[x1, y1].canFlood(board[x2, y2]))
				System.Console.WriteLine("{0} can flood {1}", board[x1, y1], board[x2, y2]);
			else
				System.Console.WriteLine("{0} cannot flood {1}", board[x1, y1], board[x2, y2]);

			if (board[x1, y1] > board[x2, y2])
				System.Console.WriteLine("{0} is greater than {1}", board[x1, y1], board[x2, y2]);
			else if (board[x1, y1] < board[x2, y2])
				System.Console.WriteLine("{0} is lesser than {1}", board[x1, y1], board[x2, y2]);
			else if (board[x1, y1] == board[x2, y2])
				System.Console.WriteLine("{0} is equal to {1}", board[x1, y1], board[x2, y2]);

			System.Console.WriteLine();

			x1 = 2;
			y1 = 1;
			x2 = 3;
			y2 = 1;

			if (board[x1, y1].canFlood(board[x2, y2]))
				System.Console.WriteLine("{0} can flood {1}", board[x1, y1], board[x2, y2]);
			else
				System.Console.WriteLine("{0} cannot flood {1}", board[x1, y1], board[x2, y2]);

			if (board[x1, y1] > board[x2, y2])
				System.Console.WriteLine("{0} is greater than {1}", board[x1, y1], board[x2, y2]);
			else if (board[x1, y1] < board[x2, y2])
				System.Console.WriteLine("{0} is lesser than {1}", board[x1, y1], board[x2, y2]);
			else if (board[x1, y1] == board[x2, y2])
				System.Console.WriteLine("{0} is equal to {1}", board[x1, y1], board[x2, y2]);

			System.Console.WriteLine();

			board[x1, y1].flood(board[x2, y2]);

		}

		public class Cell : IComparable
		{
			private static readonly Random random = new Random();
			private int earth;
			private int water;

			public Cell()
			{
				// PLACEHOLDER: Random values for earth and water
				earth = random.Next(10);
				water = random.Next(5);
			}

			public Cell(int earth, int water)
			{
				this.earth = earth;
				this.water = water;
			}

			public override string ToString()
			{
				return String.Format("{0}({1})", earth, water);
			}

			public bool canFlood(Cell other)
			{
				if ((this.currentLevel() > (other.currentLevel() + 1)) && this.water > 0)
					return true;
				else
					return false;
			}

			public bool flood(Cell other)
			{
				if(this.canFlood(other))
				{
					this.water--;
					other.water++;

					return true;
				}
				else
				{
					return false;
				}
			}

			public int currentLevel()
			{
				return earth + water;
			}

			public int CompareTo(object obj)
			{
				if (obj == null) return 1;

				Cell other = obj as Cell;

				return this.currentLevel() - other.currentLevel();
			}

			public static bool operator <(Cell c1, Cell c2)
			{
				return c1.CompareTo(c2) < 0;
			}

			public static bool operator >(Cell c1, Cell c2)
			{
				return c1.CompareTo(c2) > 0;
			}
		}

		public struct Point
		{
			public int X { get; set; }
			public int Y { get; set; }
		}
	}

	public class Game
	{
		public static void Main()
		{
			Board board = new Board();

			board.print();

			System.Console.WriteLine();
			board.test();

			board.print();


			System.Console.ReadLine();
        }
		
	}
}
