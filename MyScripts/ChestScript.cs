using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChestScript : MonoBehaviour {

	public GameObject goldObject;
	public GameObject redLight;
	private bool enter;
	bool chestLocked = true;
	AudioSource audio;

	void Start( ){
		
	}

	void Update () {
		if (NPCDialogue4.acquiredKey == true) {
			if (chestLocked == true) {
				redLight.SetActive (true);
			} else {
				redLight.SetActive (false);
			}
			AudioSource audio = GetComponent<AudioSource> ();
			if (Input.GetKeyDown ("f")) {
				audio.Play ();
				chestLocked = false;
			}
			if (!audio.isPlaying) {
				if (chestLocked == false) {
					goldObject.SetActive (true);
					Destroy (this.gameObject);
				}
			}
		} else {
			redLight.SetActive (false);
		}	
	}

	public void OnTriggerEnter (Collider col)
	{
		if (col.gameObject.tag == "Player") {
			enter = true;
		}
	}

	public void OnTriggerExit (Collider other){
		if (other.gameObject.tag == "Player") {
			enter = false;
		}
	}

	public void OnGUI(){
		if (enter) {
			if (NPCDialogue4.acquiredKey == false) {
				GUI.Label (new Rect (Screen.width / 2 - 75, Screen.height - 200, 500, 100), "Chest is locked. You need to have a key!");
			}
		}
	}
}
