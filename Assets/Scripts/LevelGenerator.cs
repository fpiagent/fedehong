using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour {

	private static int[,] board10 = new int[5, 10] { 
		{ 1, 1, 1, 1, 1, 1, 1, 1, 1, 1}, 
		{ 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
		{ 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
		{ 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
		{ 1, 1, 1, 1, 1, 1, 1, 1, 1, 1}
	};

	private static int[,] board11 = new int[4, 9] { 
		{ 1, 1, 1, 1, 1, 1, 1, 1, 1}, 
		{ 1, 1, 1, 1, 1, 1, 1, 1, 1},
		{ 1, 1, 1, 1, 1, 1, 1, 1, 1},
		{ 1, 1, 1, 1, 1, 1, 1, 1, 1}
	};

	private static int[,] board12 = new int[3, 8] { 
		{ 1, 1, 1, 1, 1, 1, 1, 1}, 
		{ 1, 1, 1, 1, 1, 1, 1, 1},
		{ 1, 1, 1, 1, 1, 1, 1, 1}
	};

	private static int[,] board13 = new int[2, 7] { 
		{ 1, 1, 1, 1, 1, 1, 1}, 
		{ 1, 1, 1, 1, 1, 1, 1}
	};

	private static int[,] board14 = new int[1, 6] { 
		{ 1, 1, 1, 1, 1, 1}
	};

	private static List<int[,]> board1 = new List<int[,]>
	{
		board10,
		board11,
		board12,
		board13,
		board14
	};
}
