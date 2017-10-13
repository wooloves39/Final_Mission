using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack :  MonoBehaviour  {
	public bool attack = false;
	public float Speed = 5.0f;
	Vector3 prevposition;
	FollowCamera followCamera;
	// Update is called once per frame
	void Start () {
		followCamera = FindObjectOfType<FollowCamera>();
	}
	void Update () {
		if (Input.GetButtonDown ("Fire2")&& !attack) 
		{
			attack = true;
			transform.rotation =followCamera.transform.rotation;
			transform.position =  followCamera.transform.position;
			prevposition = new Vector3(transform.position.x,transform.position.y,transform.position.z);
		}
		if (attack) {
			transform.Translate (Vector3.forward * Speed * Time.deltaTime * 2, Space.Self);
			if (Vector3.Distance (prevposition, transform.position) > Speed * 4) {
				attack = false;
				transform.position = prevposition + new Vector3(0,-100,0);
			}
		}
	}
}
