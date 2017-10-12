using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour {
	bool attack = false;
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Fire2")) 
		{
			attack = true;
		}
			
	}
}
