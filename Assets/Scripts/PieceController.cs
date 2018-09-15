using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceController : MonoBehaviour {

	void OnMouseDown()
	{
		if (this.CompareTag ("Active")) 
		{
			this.tag = "Inactive";
		} 
		else 
		{
			this.tag = "Active"; 
		}

	}
}
