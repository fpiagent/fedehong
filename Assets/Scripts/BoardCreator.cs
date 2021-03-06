﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class BoardPosition
{
	// Diff to be used when placing chips
	public static float xDiff = 5.0f;
	public static float yDiff = 1.0f;
	public static float zDiff = 10.0f;

	public float xPos, yPos, zPos = 0;
	public float initX, initZ = 0;

	public void increaseX () {
		xPos = xPos + xDiff;
	}

	public void increaseY () {
		yPos = yPos + yDiff;
	}

	public void increaseZ () {
		zPos = zPos + zDiff;
	}

	// Reset to init
	public void resetX() {
		xPos = initX;
	}

	public void resetZ() {
		zPos = initZ;
	}
}

public class BoardCreator : MonoBehaviour {

	public GameObject[] piecePreFabs;
	public LevelGenerator levelGenerator;

	private System.Random rnd = new System.Random();

	public void createBoard(int boardId) {
		deleteAllPieces();

		Stack<int> pieceStack = pickPrefabs(levelGenerator.getBoard(boardId));
		BoardPosition pos = new BoardPosition ();
		foreach (int[,] lvl in levelGenerator.getBoard(boardId)) {
			float startingX = -(lvl.GetLength(1) * BoardPosition.xDiff / 2);
			float startingZ = -(lvl.GetLength(0) * BoardPosition.zDiff / 2);
			pos.initX = pos.xPos = startingX;
			pos.initZ = pos.zPos = startingZ;

			// LOOP ALL
			for (int k = 0; k < lvl.GetLength (0); k++) {
				for (int l = 0; l < lvl.GetLength (1); l++) {
					if (lvl [k, l] == 1) {
						Instantiate(
							piecePreFabs[pieceStack.Pop()], 
							new Vector3(
								pos.xPos, 
								pos.yPos, 
								pos.zPos), 
							Quaternion.Euler(
								0.0f, 
								0.0f, 
								180f
							)
						);
					}

					pos.increaseX ();
				}
				pos.increaseZ ();
				pos.resetX ();
			}

			pos.increaseY ();
		}
	}

	void Start ()
	{
		createBoard (SceneManager.GetIntArgument("lvl"));
	}

	// Pre-Picks all the preFabs to instantiate
	private Stack<int> pickPrefabs(List<int[,]> board) {
		int amountToPick = 0;
		foreach (int[,] lvl in board) {
			amountToPick = amountToPick + lvl.Length;
		}

		Stack<int> allPiecesStack = new Stack<int> ();

		int amountPerPrefab = amountToPick / piecePreFabs.Length;

		Debug.Log ("Generating: " + amountToPick + " pieces with: " + amountPerPrefab + " per prefab.");

		for (int i = 0; i < piecePreFabs.Length; i++) {
			for (int ii = 0; ii < amountPerPrefab; ii++) {
				allPiecesStack.Push (i);
			}
		}

		return shuffleStack (allPiecesStack); 	
	}

	private Stack<int> shuffleStack(Stack<int> stack)
	{
		int[] array = stack.ToArray ();
		int p = array.Length;
		for (int n = p - 1; n > 0; n--)
		{
			int r = rnd.Next(0, n);
			int t = array[r];
			array[r] = array[n];
			array[n] = t;
		}

		return new Stack<int> (array);
	}

	private void deleteAllPieces () {
		GameObject[] activePieces = GameObject.FindGameObjectsWithTag("Active");
		foreach (GameObject p in activePieces) {
			Destroy (p);
		}
		GameObject[] inactivePieces = GameObject.FindGameObjectsWithTag("Inactive");
		foreach (GameObject p in inactivePieces) {
			Destroy (p);
		}
	}
}
