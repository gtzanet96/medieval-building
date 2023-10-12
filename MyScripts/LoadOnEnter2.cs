using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadOnEnter2 : MonoBehaviour {

	public void LoadByIndex(int sceneIndex)
	{
		Time.timeScale = 1f;
		SceneManager.LoadScene (sceneIndex); 
	}
}
