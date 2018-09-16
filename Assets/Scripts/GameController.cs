using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public GameObject highlight;
	public BoardCreator boardCreator;

	public Text counterText;
	public Text timerText;
	public GameObject winMessage;



	private float startingTime = 0.0f;
	private int pointCounter = 0;
	private int MATCH_VALUE = 100;
	private int FAIL_VALUE = 50;

	private bool win = false;

	public void resetGame() {
		boardCreator.createBoard ();
		pointCounter = 0;
		counterText.text = "Points: " + pointCounter;
		startingTime = Time.fixedTime;
		win = false;
		winMessage.SetActive (false);
	}

	protected void Update() {
		// ACTIVE PIECES
		GameObject[] activePieces = GameObject.FindGameObjectsWithTag("Active");
		placeHighlightOn (activePieces);

		// INACTIVE PIECES
		GameObject[] inactivePieces = GameObject.FindGameObjectsWithTag("Inactive");
		removeHighlightOn (inactivePieces);

		if (activePieces.Length >= 2) {
			Material pieceMaterial = activePieces [0].GetComponent<Renderer> ().material;
			Material otherPieceMaterial = activePieces [1].GetComponent<Renderer> ().material;
			if (pieceMaterial.name.Equals(otherPieceMaterial.name)) {
				Destroy (activePieces [0]);
				Destroy (activePieces [1]);
				increasePoints ();
			} else {
				setPiecesInactive (activePieces);
				decreasePoints ();
			}
		}

		updateTime ();
		checkWin (activePieces, inactivePieces);
	}	

	private void setPiecesInactive(GameObject[] activePieces) {
		foreach (GameObject activePiece in activePieces) {
			activePiece.tag = "Inactive";
		}
	}

	private void placeHighlightOn(GameObject[] pieces) {
		foreach (GameObject piece in pieces) {
			if (piece.transform.childCount == 0) {
				Vector3 highlightPosition = new Vector3(
					piece.transform.position.x, 
					piece.transform.position.y + 1, 
					piece.transform.position.z);

				GameObject newHighlight = Instantiate(
					highlight, 
					highlightPosition, 
					piece.transform.rotation);

				newHighlight.transform.parent = piece.transform;
			}
		}
	}

	private void removeHighlightOn(GameObject[] pieces) {
		foreach (GameObject piece in pieces) {
			if (piece.transform.childCount > 0) {
				Destroy (piece.transform.GetChild(0).gameObject);
			}
		}
	}

	private void increasePoints () {
		pointCounter = pointCounter + MATCH_VALUE;
		counterText.text = "Points: " + pointCounter;
	}

	private void decreasePoints () {
		pointCounter = pointCounter - FAIL_VALUE;
		counterText.text = "Points: " + pointCounter;
	}

	private void updateTime () {
		if (!win) {
			float gameTime = Time.fixedTime - startingTime;

			string minutes = Mathf.Floor(gameTime / 60).ToString("00");
			string seconds = (gameTime % 60).ToString("00");

			timerText.text = "Timer: " + minutes + ":" + seconds;
		}
	}

	private void checkWin (GameObject[] activePieces, GameObject[] inactivePieces) {
		if (activePieces.Length == 0 && inactivePieces.Length == 0) {
			win = true;
			winMessage.SetActive (true);
		}
	}
}
