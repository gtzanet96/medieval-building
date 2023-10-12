using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LakeScript : MonoBehaviour {

	AudioSource lakeWater;
	// Use this for initialization
	void Start () {
		lakeWater = GetComponent<AudioSource> ();
		lakeWater.Play ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
