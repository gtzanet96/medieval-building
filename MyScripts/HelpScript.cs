using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpScript : MonoBehaviour {

	public GameObject helpCanvas;
	private bool helpActive;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("h")) {
			if (helpActive)
				Resume ();
			else
				Open ();
		}
	}

	public void Open()
	{
		helpCanvas.SetActive (true);
		helpActive = true;
	}

	public void Resume()
	{
		helpCanvas.SetActive (false);
		helpActive = false;
	}
}
