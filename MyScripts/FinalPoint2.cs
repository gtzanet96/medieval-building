using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalPoint2 : MonoBehaviour {


	public static bool FP2entrance1 = false; //να ενεργοποιειται οταν ο εργατης ειναι μεσα στο range του NPC
	public static bool FP2entrance2 = false; 
	public static bool FP2entrance3 = false;
	public static bool FP2entrance4 = false;
	public static bool FP2entrance5 = false;
	public static bool FP2entrance6 = false;

	void Start () {

	}

	void Update () {

	}

	void OnTriggerEnter (Collider col)
	{
		if (col.gameObject.tag == "TreeWorker1")
		{
			FP2entrance1 = true;
		} 
		if (col.gameObject.tag == "TreeWorker2")
		{
			FP2entrance2 = true;
		} 
		if (col.gameObject.tag == "TreeWorker3")
		{
			FP2entrance3 = true;
		} 
		if (col.gameObject.tag == "StoneWorker1") {
			FP2entrance4 = true;
		}
		if (col.gameObject.tag == "StoneWorker2") {
			FP2entrance5 = true;
		}
		if (col.gameObject.tag == "Boss") {
			FP2entrance6 = true;
		}

	}

	void OnTriggerExit (Collider col)
	{

		if (col.gameObject.tag == "TreeWorker1")
		{
			FP2entrance1 = false;
		} 
		if (col.gameObject.tag == "TreeWorker2")
		{
			FP2entrance2 = false;
		} 
		if (col.gameObject.tag == "TreeWorker3")
		{
			FP2entrance3 = false;
		} 
		if (col.gameObject.tag == "StoneWorker1") {
			FP2entrance4 = false;
		}
		if (col.gameObject.tag == "StoneWorker2") {
			FP2entrance5 = false;
		}
		if (col.gameObject.tag == "Boss") {
			FP2entrance6 = false;
		}
	}

}
