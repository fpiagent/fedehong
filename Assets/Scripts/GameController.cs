using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public GameObject highlight;

	protected void Update()
	{
		GameObject[] activePieces = GameObject.FindGameObjectsWithTag("Active");
		if (activePieces.Length == 1) {
			placeHighlightOn (activePieces [0]);
		} else if (activePieces.Length == 2) {
			Material pieceMaterial = activePieces [0].GetComponent<Renderer> ().material;
			Material otherPieceMaterial = activePieces [1].GetComponent<Renderer> ().material;
			if (pieceMaterial.color == otherPieceMaterial.color) {
				Destroy (activePieces [0]);
				Destroy (activePieces [1]);
			} else {
				cleanPieces (activePieces);
			}
		}
	}	

	private void cleanPieces(GameObject[] activePieces) {
		foreach (GameObject activePiece in activePieces) {
			activePiece.tag = "Inactive";
		}
	}

	private void placeHighlightOn(GameObject piece) {
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
