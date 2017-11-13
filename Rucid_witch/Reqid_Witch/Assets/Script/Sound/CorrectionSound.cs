using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorrectionSound : MonoBehaviour {

	// Use this for initialization
	void Start () {
		AudioSource audioSource = GetComponent<AudioSource> ();
		audioSource.volume = Singletone.Instance.Sound;
	}
	void Awake()
	{
		DontDestroyOnLoad (this);
	}
}
