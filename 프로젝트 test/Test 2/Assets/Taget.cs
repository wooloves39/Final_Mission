using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Taget : MonoBehaviour {
	//FollowCamera followCamera;
	CharacterStatus characterStatus;
	public int HP;
	public int MaxHP;
	public string CharacterName;
	bool tageting = false;
	void Start () {
		//followCamera = FindObjectOfType<FollowCamera>();
	}

	void Update () {
		
	}

	void OnTriggerStay(Collider other)
	{
		characterStatus = other.GetComponent<CharacterStatus> ();
		HP = characterStatus.HP;
		MaxHP = characterStatus.MaxHP;
		CharacterName = characterStatus.characterName;
	}
	void OnTriggerExit(Collider other)
	{
		tageting = false;
		print ("taget exit");
		HP = 0;
		MaxHP = 0;
		CharacterName = null;
		characterStatus = null;

	}

}
