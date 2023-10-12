using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckForChat4 : MonoBehaviour {

	public static bool entrance4 = false; //να ενεργοποιειται οταν ο παικτης ειναι μεσα στο range του NPC
	public GameObject light;

	void Start () {

	}

	void Update () {

	}

	void OnTriggerEnter (Collider col)
	{
		if (col.gameObject.tag == "Boss")
		{
			entrance4 = true;
			light.SetActive (true);
		} 

	}

	void OnTriggerExit (Collider col)
	{
		if (col.gameObject.tag == "Boss")
		{                      
			entrance4 = false;
			light.SetActive (false);
		} 

	}

}
