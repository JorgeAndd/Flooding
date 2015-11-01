using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Flood
{
	public class Board
	{
		private int height, length;
		private Cell[,] board;

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
			for (int x = 0; x < this.length; x++)
			{
				for (int y = 0; y < this.height; y++)
				{
					System.Console.Write(board[x, y] + "\t");
				}
				System.Console.Write("\n");
			}
		}

		public class Cell
		{
			private static readonly Random random = new Random();
			int earth;
			int water;

			public Cell()
			{
				earth = random.Next(10);
				water = random.Next(5);
			}

			public override string ToString()
			{
				return String.Format("{0}({1})", earth, water);
			}
		}
	}

	public class Game
	{
		public static void Main()
		{
			Board board = new Board(5, 5);

			board.print();

			System.Console.ReadLine();
        }
		
	}
}
