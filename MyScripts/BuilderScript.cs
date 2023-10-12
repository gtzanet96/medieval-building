using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BuilderScript : MonoBehaviour {

	NavMeshAgent navmeshAgent;
	Animator anim;
	public GameObject low1;
	public GameObject low2;
	public GameObject low3;
	public GameObject low4;
	public GameObject low5;
	public GameObject low6;
	public GameObject low7;
	public GameObject middle1;
	public GameObject middle2;
	public GameObject middle3;
	public GameObject high1;
	public GameObject high2;
	public GameObject high3;
	public GameObject high4;
	public GameObject high5;
	public GameObject high6;
	public GameObject high7;
	public GameObject high8;
	public GameObject ready1;
	public GameObject ready2;
	public GameObject ready3;
	public GameObject ready4;
	public GameObject ready5;
	public GameObject ready6;
	public GameObject ready7;
	public static bool final1 = false;
	public static bool final2 = false;
	public static bool final3 = false;
	public static bool final4 = false;
	public static bool final5 = false;
	public static bool final6 = false;
	public static bool final7 = false;
	public GameObject finalb;
	public bool o = false;
	public float accuracyWP = 3.0f;


	void Start () {
		anim = GetComponent<Animator> ();
		navmeshAgent = GetComponent<NavMeshAgent> ();
	}
	

	void Update () {

		if (FindClosest1.a1 == 4) {
			anim.SetBool ("isIdle", false);
			anim.SetBool ("buildLow", true);
			StartCoroutine(buildLow());
		}

		if (FindClosest1.a1 == 5)
		{
			anim.SetBool ("buildLow", false);
			anim.SetBool ("buildMiddle", true);
			StartCoroutine(buildMiddle ());
		}

		if (FindClosest1.a1 == 6)
		{
			anim.SetBool ("buildMiddle", false);
			anim.SetBool ("buildHigh", true);
			StartCoroutine(buildHigh ());
		}

		if (FindClosest1.a1 <= 3)
		{
			anim.SetBool ("buildHigh", false);
			anim.SetBool ("buildMiddle", false);
			anim.SetBool ("buildLow", false);
			anim.SetBool ("isIdle", true);
		}

		if (FindClosest1.a1 == 7 && final7 == false) {
			anim.SetBool ("buildHigh", false);
			anim.SetBool ("buildMiddle", false);
			anim.SetBool ("buildLow", false);
			anim.SetBool ("isIdle", true);
			StartCoroutine (endThis ());
		}

		if (final7 == true) {
			if (o == false) {
				navmeshAgent.SetDestination (finalb.transform.position);
				o = true;
			}
			Vector3 direction = finalb.transform.position - transform.position;
			if (direction.magnitude < accuracyWP) {
				anim.SetBool ("isIdle", true);
				anim.SetBool ("isWalking", false);
				anim.SetBool ("buildHigh", false);
				anim.SetBool ("buildMiddle", false);
				anim.SetBool ("buildLow", false);
				navmeshAgent.Stop (true);
			} else {
				anim.SetBool ("isIdle", false);
				anim.SetBool ("isWalking", true);
			}
		}

	}


	IEnumerator buildLow(){
		yield return new WaitForSeconds (6);
		if (low1 != null) {
			low1.SetActive (true);
		}
		yield return new WaitForSeconds (6);
		if (low2 != null) {
			low2.SetActive (true);
		}
		yield return new WaitForSeconds (6);
		if (low3 != null) {
			low3.SetActive (true);
			Destroy(ready1);
		}
		yield return new WaitForSeconds (6);
		if (low4 != null) {
			low4.SetActive (true);
		}
		yield return new WaitForSeconds (6);
		if (low5 != null) {
			low5.SetActive (true);
		}
		yield return new WaitForSeconds (6);	
		if (low6 != null) {
			low6.SetActive (true);
			Destroy(ready2);
		}
		yield return new WaitForSeconds (6);
		if (low7 != null) {
			low7.SetActive (true);
		}
		FindClosest1.a1 = 5;
	}

	IEnumerator buildMiddle(){
		yield return new WaitForSeconds(6);
		Destroy(low1);
		Destroy(low2);
		Destroy(low3);
		Destroy(low4);
		Destroy(low5);
		Destroy(low6);
		Destroy(low7);
		if (middle1 != null) {
			middle1.SetActive (true);
			Destroy(ready3);
		}
		yield return new WaitForSeconds(6);
		if (middle2 != null) {
			middle2.SetActive (true);
			Destroy(ready4);
		}
		yield return new WaitForSeconds(6);
		if (middle3 != null) {
			middle3.SetActive (true);
		}
		FindClosest1.a1 = 6;
	}

	IEnumerator buildHigh(){
		yield return new WaitForSeconds(6);
		if (high1 != null) {
			high1.SetActive (true);
			Destroy(ready5);
		}
		yield return new WaitForSeconds(6);
		Destroy(high1);
		Destroy(middle3);
		high2.SetActive (true);
		yield return new WaitForSeconds(6);
		high3.SetActive (true);
		Destroy(ready6);
		yield return new WaitForSeconds(6);
		high4.SetActive (true);
		yield return new WaitForSeconds(6);
		high5.SetActive (true);
		yield return new WaitForSeconds(6);
		high6.SetActive (true);
		yield return new WaitForSeconds(6);
		high7.SetActive (true);
		Destroy(middle1);
		Destroy(middle2);
		yield return new WaitForSeconds(6);
		Destroy(ready7);
		high8.SetActive (true);
		FindClosest1.a1 = 7;

	}

	IEnumerator endThis(){
		yield return new WaitForSeconds(3);
		final1 = true;
		final2 = true;
		final3 = true;
		final4 = true;
		final5 = true;
		final6 = true;
		//yield return new WaitForSeconds(2);
		final7 = true;
	}
		
}
