using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SceneManager {

	private static Dictionary<string, string> SCENE_ARGUMENTS = new Dictionary<string, string>();

	public static void LoadScene(string sceneName, Dictionary<string, string> arguments)
	{
		SCENE_ARGUMENTS = arguments;
		Application.LoadLevel(sceneName);
	}

	public static int GetIntArgument(string key)
	{
		if (SCENE_ARGUMENTS.ContainsKey ("lvl")) {
			return int.Parse (SCENE_ARGUMENTS ["lvl"]);
		} else {
			return 1;
		}
	}

	public static IDictionary GetSceneArguments()
	{
		return SCENE_ARGUMENTS;
	}
}
