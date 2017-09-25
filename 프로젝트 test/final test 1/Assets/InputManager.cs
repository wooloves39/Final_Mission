
﻿using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour {
	Vector2 slideStartPosition;
	Vector2 prevPosition;
	Vector2 delta = Vector2.zero;
	Vector2 movePosition;
	bool moved = false;
	GameObject copy;
	int cnt =0;
	public GameObject[] arr = new GameObject[250];
	void Start(){
		copy = Resources.Load ("sphere") as GameObject;
	}

	void Update()
	{

		// 슬라이드 시작 지점.
		if (Input.GetButtonDown ("Fire1")) {
			slideStartPosition = GetCursorPosition ();
		}

		// 화면 너비의 2% 이상 커서를 이동시키면 슬라이드 시작으로 판단한다.
		if (Input.GetButton("Fire1")) {
			if (Vector2.Distance (slideStartPosition, GetCursorPosition ()) >= (Screen.width * 0.02f)) {
				print ("is Click Ture");
				copy.transform.position = GetCursorPosition();
				arr[cnt++] = Instantiate (copy)as GameObject;
				moved = true;
			}
		}	

		// 슬라이드가 끝났는가.
		if (!Input.GetButtonUp ("Fire1") && !Input.GetButton ("Fire1")) {
			if (moved) {
				for (int i = 0; i < 250; ++i) {
					if (arr [i] == null)
						break;
					arr [i] = null;
					Destroy (arr [i]);
				}
				moved = false; 
				cnt = 0;
			}
		}
		// 이동량을 구한다.
		if (moved) 
			delta = GetCursorPosition () - prevPosition;
		else
			delta = Vector2.zero;

		// 커서 위치를 갱신한다.
		prevPosition = GetCursorPosition();
	}

	// 클릭되었는가.
	public bool Clicked()
	{
		if (!moved && Input.GetButtonUp ("Fire1")) {
			return true;
		}
		else
			return false;
	}	

	// 슬라이드할 때 커서 이동량.
	public Vector2 GetDeltaPosition()
	{
		return delta;
	}

	// 슬라이드 중인가.
	public bool Moved()
	{
		return moved;
	}

	public Vector2 GetCursorPosition()
	{
		return Input.mousePosition;
	}
}