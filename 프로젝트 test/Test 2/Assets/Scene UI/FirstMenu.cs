﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FirstMenu : MonoBehaviour {
	public int UIWidth = 300;
	public int UIHeight = 70;
	void OnGUI()
	{
		if (GUI.Button (new Rect (Screen.width / 2 - (UIWidth / 2), Screen.height / 2 - 135 - (UIHeight / 2), UIWidth, UIHeight), "새로시작"))
			SceneManager.LoadScene("map&player");
		if(GUI.Button (new Rect  (Screen.width/2-(UIWidth/2), Screen.height/2 - 45 -(UIHeight/2), UIWidth, UIHeight), "이어하기"))
			SceneManager.LoadScene("map&player");
		if(GUI.Button (new Rect  (Screen.width/2-(UIWidth/2), Screen.height/2 + 45 -(UIHeight/2), UIWidth, UIHeight), "멀티플레이"))
			Debug.Log ("Multi Game");
		if(GUI.Button (new Rect  (Screen.width/2-(UIWidth/2), Screen.height/2 + 135 -(UIHeight/2), UIWidth, UIHeight), "옵션"))
			Debug.Log ("Option");
	}
}
