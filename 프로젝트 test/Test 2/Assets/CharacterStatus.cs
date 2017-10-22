using UnityEngine;
using System.Collections;

public class CharacterStatus : MonoBehaviour {
	// status
	public int HP = 100;
	public int MaxHP = 100;
	public int Power = 10;
	bool Hit = false;
	CharacterStatus characterStatus;

	// name
	public string characterName = "Enemy1";
	//충돌 체크 
	void OnTriggerEnter(Collider other)
	{
		characterStatus = GetComponent<CharacterStatus>();
		if (!Hit) {
			Hit = true;
			//other 캐릭터의 파워만큼 감소
			characterStatus.HP -= characterStatus.Power;
			print ("Hit");
			Hit = false;
		}
	}
	
}
