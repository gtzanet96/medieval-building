using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ProcessorScript : MonoBehaviour {

	public GameObject log1;
	public GameObject log2;
	public GameObject log3;
	public GameObject log4;
	public GameObject log5;
	public GameObject boardPile1;
	public GameObject boardPile2;
	public GameObject boardPile3;
	public GameObject boardPile4;
	public GameObject boardPile5;
	public GameObject rock1;
	public GameObject rock2;
	public GameObject stonePile1;
	public GameObject stonePile2;
	public GameObject finalb;
	public bool o = false;
	public float accuracyWP = 3.0f;
	NavMeshAgent navmeshAgent;
	Animator anim;
	private float delayBeforeLoading = 10f;
	private float TimeElapsed;
	private float delayBeforeLoading2 = 10f;
	private float TimeElapsed2;
	private float delayBeforeLoading3 = 10f;
	private float TimeElapsed3;
	private float delayBeforeLoading4 = 10f;
	private float TimeElapsed4;
	private float delayBeforeLoading5 = 9f;
	private float TimeElapsed5;
	private float delayBeforeLoading6 = 9f;
	private float TimeElapsed6;
	private float delayBeforeLoading7 = 9f;
	private float TimeElapsed7;


	void Start () {
		anim = GetComponent<Animator> ();
		navmeshAgent = GetComponent<NavMeshAgent> ();
	}



	void Update () {
		
		if (FindClosest1.a1 == 3 && FindClosest2.a2 == 3) {
			anim.SetBool ("isIdle", false);
			anim.SetBool ("isProcessing", true);
			TimeElapsed += Time.deltaTime;				
			if (TimeElapsed > delayBeforeLoading){
				log1.SetActive (false);
				StartCoroutine(plzWait ());
				boardPile1.SetActive (true);
				TimeElapsed2 += Time.deltaTime;
				if (TimeElapsed2 > delayBeforeLoading2) {
					log2.SetActive (false);
					StartCoroutine(plzWait ());
					boardPile2.SetActive (true);
					TimeElapsed3 += Time.deltaTime;
					if (TimeElapsed3 > delayBeforeLoading3) {
						log3.SetActive (false);				
						StartCoroutine(plzWait ());
						boardPile3.SetActive (true);
						TimeElapsed4 += Time.deltaTime;
						if (TimeElapsed4 > delayBeforeLoading4) {
							log4.SetActive (false);
							StartCoroutine(plzWait ());
							boardPile4.SetActive (true);
							TimeElapsed5 += Time.deltaTime;
							if (TimeElapsed5 > delayBeforeLoading5) {
								rock1.SetActive (false);
								StartCoroutine(plzWait ());
								stonePile1.SetActive (true);
								TimeElapsed6 += Time.deltaTime;
								if (TimeElapsed6 > delayBeforeLoading6) {
									rock2.SetActive (false);
									StartCoroutine (plzWait ());
									stonePile2.SetActive (true);
									TimeElapsed7 += Time.deltaTime;
									if (TimeElapsed7 > delayBeforeLoading7) {
										log5.SetActive (false);
										StartCoroutine(plzWait ());
										boardPile5.SetActive (true);
										FindClosest1.a1 = 4;
									}
								}
							}

						}
					}
				}
			}
		} 
		else
		{
			if (BuilderScript.final6 == true) {
				if (o == false) {
					navmeshAgent.SetDestination (finalb.transform.position);
					o = true;
				}
				Vector3 direction = finalb.transform.position - transform.position;
				if (direction.magnitude < accuracyWP) {
					anim.SetBool ("isIdle", true);
					anim.SetBool ("isWalking", false);
					navmeshAgent.Stop (true);
				} else {
					anim.SetBool ("isIdle", false);
					anim.SetBool ("isWalking", true);
				}
			} else {
				anim.SetBool ("isIdle", true);
				anim.SetBool ("isProcessing", false);
			}
		}
			
	}

	IEnumerator plzWait(){
		yield return new WaitForSeconds(0.5f);
	}
}

