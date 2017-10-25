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
	void OnTriggerEnter(Collider other)
	{
			tageting = true;
			print ("taget start");
			characterStatus = FindObjectOfType<CharacterStatus> ();
			HP = characterStatus.HP;
			MaxHP = characterStatus.MaxHP;
			CharacterName = characterStatus.characterName;
	}
	void OnTriggerStay(Collider other)
	{
		tageting = true;
		HP = characterStatus.HP;
		MaxHP = characterStatus.MaxHP;
		CharacterName = characterStatus.characterName;
	}

}
