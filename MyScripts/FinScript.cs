using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinScript : MonoBehaviour {


	public static bool FinEntrance = false; //να ενεργοποιειται οταν ο παικτης ειναι μεσα στο range του NPC


	void Start () {

	}

	void Update () {

	}

	void OnTriggerEnter (Collider col)
	{
		if (col.gameObject.tag == "Player")
		{
			FinEntrance = true;
		} 

	}

	void OnTriggerExit (Collider col)
	{
		if (col.gameObject.tag == "Player")
		{                      
			FinEntrance = false;
		} 

	}

}
