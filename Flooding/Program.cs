using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Board
{
	private int height, length;
	private Cell[,] board;

	public Board(int height, int length)
	{
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
		foreach (Cell cell in board)
		{
			System.Console.WriteLine(cell);
		}
	}

	public class Cell
	{
		int earth;
		int water;

		public Cell()
		{
			Random rand = new Random();

			earth = rand.Next(10);
			water = rand.Next(5);
		}

		public override string ToString()
		{
			return String.Format("{0}({1})", earth, water);
		}
	}
}

namespace Flood
{
	public class Flood
	{
		Board board = new Board(5, 5);

	}
}
