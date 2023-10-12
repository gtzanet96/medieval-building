using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckForChat3 : MonoBehaviour {

	public static bool entrance3 = false; //να ενεργοποιειται οταν ο παικτης ειναι μεσα στο range του NPC
	public GameObject light;

	void Start () {

	}

	void Update () {

	}

	void OnTriggerEnter (Collider col)
	{
		if (col.gameObject.tag == "Boss")
		{
			entrance3 = true;
			light.SetActive (true);
		} 

	}

	void OnTriggerExit (Collider col)
	{
		if (col.gameObject.tag == "Boss")
		{                      
			entrance3 = false;
			light.SetActive (false);
		} 
	}
}
