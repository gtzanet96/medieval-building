using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevelPick : MonoBehaviour {

	public string sceneNameToLoad;
	public void LoadbyName(){
		SceneManager.LoadScene (sceneNameToLoad);
	}
}