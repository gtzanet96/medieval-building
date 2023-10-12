using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckEvents : MonoBehaviour {

	public GameObject loot;
	//private bool enter;
	public GameObject goldIcon;
	public static bool lootTaken = false;
	AudioSource audio2;

	void Update () {
		AudioSource audio2 = GetComponent<AudioSource>();
			if (Input.GetKeyDown ("f")) {
				audio2.Play ();
				Destroy (loot);
				goldIcon.SetActive(true);
				lootTaken = true;
			}
		
	}
}
