using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckForChat : MonoBehaviour {


	public static bool entrance = false; //να ενεργοποιειται οταν ο παικτης ειναι μεσα στο range του NPC
	public GameObject light;

	void Start () {
		
	}

	void Update () {
		
	}

	void OnTriggerEnter (Collider col)
	{
		if (col.gameObject.tag == "Player")
		{
			entrance = true;
			light.SetActive (true);
		} 

	}

	void OnTriggerExit (Collider col)
	{
		if (col.gameObject.tag == "Player")
		{                      
			entrance = false;
			light.SetActive (false);
		} 

	}

}
