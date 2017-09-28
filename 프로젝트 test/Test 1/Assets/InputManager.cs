
﻿using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour {
	Vector2 slideStartPosition;
	Vector2 prevPosition;
	Vector2 delta = Vector2.zero;
	bool moved = false;
	GameObject copy;
	int cnt =0;
	private GameObject[] arr = new GameObject[2];
    //앞뒤로 만 체크하고 버리고 꼭지점만 저장한다.
    private GameObject bef;
    private GameObject af;
    private GameObject mid;
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
                cnt++;
                if (cnt % 5 == 0)
                {
                    af = Instantiate(copy) as GameObject;

                    if (!bef)
                    {
                        bef = af;
                        mid = af;
                    }
                    //if (Mathf.Abs((af.gameObject.transform.position.y - bef.gameObject.transform.position.y) / (af.gameObject.transform.position.x - bef.gameObject.transform.position.x)) > 2.0f)

                    //꼭지점 저장
                    float o1 = Mathf.Atan((af.gameObject.transform.position.y - mid.gameObject.transform.position.y) / (af.gameObject.transform.position.x - mid.gameObject.transform.position.x));
                    float o2 = Mathf.Atan((bef.gameObject.transform.position.y - mid.gameObject.transform.position.y) / (bef.gameObject.transform.position.x - mid.gameObject.transform.position.x));
                    float Point = Mathf.Abs(o1 - o2) * Mathf.Rad2Deg;

                    if (Point > 30.0f && Point < 120.0f)
                    {
                        Debug.Log(Point);
                        Debug.Log("꼭지점 저장하라");
                    }
                    bef = mid;
                    mid = af;
                }
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