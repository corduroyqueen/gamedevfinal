using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class AddMenu : EditorWindow {

	[MenuItem("Edit/Reset Playerprefs")]

	public static void DeletePlayerPrefs()
	{
		PlayerPrefs.DeleteAll();
	}

}
