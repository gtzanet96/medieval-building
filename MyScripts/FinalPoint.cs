using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalPoint : MonoBehaviour {


	public static bool FPentrance = false; //να ενεργοποιειται οταν ο παικτης ειναι μεσα στο range του NPC


	void Start () {

	}

	void Update () {

	}

	void OnTriggerEnter (Collider col)
	{
		if (col.gameObject.tag == "Boss")
		{
			FPentrance = true;
		} 

	}

	void OnTriggerExit (Collider col)
	{
		if (col.gameObject.tag == "Boss")
		{                      
			FPentrance = false;
		} 

	}

}
