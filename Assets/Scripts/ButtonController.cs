using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour {

	public void level1() {
		Dictionary<string, string> arguments = new Dictionary<string, string> ();
		arguments.Add ("lvl", "1");
		SceneManager.LoadScene("_Scenes/scene1", arguments);
	}

	public void level2() {
		Dictionary<string, string> arguments = new Dictionary<string, string> ();
		arguments.Add ("lvl", "2");
		SceneManager.LoadScene("_Scenes/scene1", arguments);
	}
}
