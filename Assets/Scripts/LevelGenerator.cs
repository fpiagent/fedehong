using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour {

	private static int[,] board10 = new int[6, 11] {
		{ 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1}, 
		{ 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
		{ 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
		{ 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
		{ 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
		{ 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1}
	};

	private static int[,] board11 = new int[4, 9] { 
		{ 1, 1, 1, 1, 1, 1, 1, 1, 1}, 
		{ 1, 1, 1, 1, 1, 1, 1, 1, 1},
		{ 1, 1, 1, 1, 1, 1, 1, 1, 1},
		{ 1, 1, 1, 1, 1, 1, 1, 1, 1}
	};

	private static int[,] board12 = new int[2, 7] { 
		{ 1, 1, 1, 1, 1, 1, 1}, 
		{ 1, 1, 1, 1, 1, 1, 1}
	};

	private static int[,] board13 = new int[2, 8] { 
		{ 1, 1, 1, 1, 1, 1, 1, 1},
		{ 1, 1, 1, 1, 1, 1, 1, 1}
	};

	private static int[,] board14 = new int[1, 8] { 
		{ 1, 1, 1, 1, 1, 1, 1, 1}
	};

	private static List<int[,]> board1 = new List<int[,]>
	{
		board10,
		board11,
		board12,
		board13,
		board14
	};

	/* ---------------  */
	/* ---------------  */
	/* ---------------  */

	private static int[,] board20 = new int[7, 7] {
		{ 1, 1, 1, 0, 1, 1, 1}, 
		{ 1, 1, 1, 1, 1, 1, 1},
		{ 0, 1, 1, 1, 1, 1, 0},
		{ 0, 0, 1, 1, 1, 0, 0},
		{ 0, 0, 1, 1, 1, 0, 0},
		{ 0, 0, 1, 1, 1, 0, 0},
		{ 1, 0, 1, 1, 1, 0, 1}
	};

	private static int[,] board21 = new int[6, 7] {
		{ 1, 1, 1, 0, 1, 1, 1}, 
		{ 1, 1, 1, 1, 1, 1, 1},
		{ 0, 1, 1, 1, 1, 1, 0},
		{ 0, 0, 1, 1, 1, 0, 0},
		{ 0, 0, 1, 1, 1, 0, 0},
		{ 0, 0, 1, 1, 1, 0, 0}
	};

	private static int[,] board22 = new int[6, 2] {
		{ 1, 1}, 
		{ 1, 1},
		{ 1, 1},
		{ 1, 1},
		{ 1, 1},
		{ 1, 1}
	};

	private static int[,] board23 = new int[6, 2] {
		{ 1, 1}, 
		{ 1, 1},
		{ 1, 1},
		{ 1, 1},
		{ 1, 1},
		{ 1, 1}
	};

	private static int[,] board24 = new int[5, 1] {
		{ 1},
		{ 1},
		{ 1},
		{ 1},
		{ 1}
	};



	private static List<int[,]> board2 = new List<int[,]>
	{
		board20,
		board21,
		board22,
		board23,
		board24
	};

	/* ---------------  */
	/* ---------------  */
	/* ---------------  */

	private static List<int[,]> boardTest = new List<int[,]>
	{
		new int[2, 10] { 
			{ 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
			{ 1, 1, 1, 1, 1, 1, 1, 1, 1, 1}
		}
	};

	private static List<List<int[,]>> allBoards = new List<List<int[,]>>
	{
		boardTest,
		board1,
		board2
	};

	public List<int[,]> getBoard(int boardId) {
		return allBoards[boardId];
	}
}
