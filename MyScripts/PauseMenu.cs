using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour {

	public GameObject PauseUI;
	public static bool GameisPaused;

	void Start () {

	}

	void Update () 
	{
		if (Input.GetKeyDown (KeyCode.Escape)) 
		{
			if (GameisPaused)
				Resume ();
			else
				Pause ();
		} 
	}

	public void Pause()
	{
		PauseUI.SetActive (true);
		Time.timeScale = 0f;
		GameisPaused = true;
	}

	public void Resume()
	{
		PauseUI.SetActive (false);
		Time.timeScale = 1f;
		GameisPaused = false;
	}
}
