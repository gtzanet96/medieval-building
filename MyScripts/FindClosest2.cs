using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Animations;

public class FindClosest2 : MonoBehaviour {

	public GameObject[] waypoints;
	public GameObject workspace;
	public GameObject firstTree;
	public GameObject secondTree;
	public GameObject log2;
	public GameObject log5;
	bool o2 = false;
	Animator anim;
	public float rotSpeed = 0.8f;
	public float speed = 10.0f;
	float accuracyWP = 6.0f;
	int currentWP = 0;
	//List<Transform> path = new List<Transform>();
	bool goWorker = false;
	bool axe = false;
	public GameObject finalb;
	public bool o = false;
	public float accuracyWP2 = 3.0f;

	private float delayBeforeLoading = 12f;
	private float TimeElapsed;
	private float delayBeforeLoading2 = 5f;
	private float TimeElapsed2;
	private float delayBeforeLoading3 = 18f;
	private float TimeElapsed3;
	private float delayBeforeLoading4 = 3f;
	private float TimeElapsed4;
	NavMeshAgent navmeshAgent;
	bool eftase = false;
	public static bool worker2go = false;
	public static int a2 = 1;

	void Start () 
	{

		navmeshAgent = GetComponent<NavMeshAgent> ();

		anim = GetComponent<Animator> ();

		currentWP = FindClosestWP ();
	}

	int FindClosestWP()
	{
		if (waypoints.Length == 0) return -1;
		int closest = 0;
		float lastDist = Vector3.Distance (this.transform.position, waypoints [0].transform.position);
		for (int i = 1; i < waypoints.Length; i++)
		{
			float thisDist = Vector3.Distance (this.transform.position, waypoints [i].transform.position);
			if (lastDist > thisDist && i != currentWP) 
			{
				closest = i;
			}
		}
		return closest;
	}



	// Update is called once per frame
	void Update ()
	{
		//if (GameObject.Find(currentWP) != null)
		//{
		if (a2 == 1) {
			if (CheckForChat3.entrance3 == true) {
				goWorker = true;
			}

			if (goWorker == true && eftase == false) {
				navmeshAgent.SetDestination (waypoints [currentWP].transform.position);
			}

			if (FinalPoint2.FP2entrance2 == false) {// && eftase == false) {
				Vector3 direction = waypoints [currentWP].transform.position - transform.position;
				if (direction.magnitude < accuracyWP) {
					//currentWP = FindClosestWP ();
					TimeElapsed += Time.deltaTime;
					axe = true;
					eftase = true;
					navmeshAgent.Stop (true);

					if (TimeElapsed > delayBeforeLoading) {
						axe = false;
						navmeshAgent.Resume ();
						navmeshAgent.SetDestination (workspace.transform.position);
						firstTree.SetActive (false);
						//eftase = false;
						currentWP = FindClosestWP ();
						a2 = 2;
					}
				}
			}
		}

		if (a2 == 2) {
			//Debug.Log ("1");
			if (FinalPoint2.FP2entrance2 == true) {
				log2.SetActive (true);
				TimeElapsed2 += Time.deltaTime;
				if (TimeElapsed2 > delayBeforeLoading2) {
					navmeshAgent.SetDestination (waypoints [currentWP].transform.position);
				}
					
			} else {
				Vector3 direction2 = waypoints [currentWP].transform.position - transform.position;
				if (direction2.magnitude < accuracyWP) {
					TimeElapsed3 += Time.deltaTime;
					axe = true;
					navmeshAgent.Stop (true);
					if (TimeElapsed3 > delayBeforeLoading3) {
						axe = false;
						navmeshAgent.Resume ();
						navmeshAgent.SetDestination (workspace.transform.position);
						secondTree.SetActive (false);
						a2 = 3;
					}
				}
			}

		}		

		if (a2 == 3 && FinalPoint2.FP2entrance2 == true && o2 == false) {
			TimeElapsed4 += Time.deltaTime;
			if (TimeElapsed4 > delayBeforeLoading4) {
				log5.SetActive (true);
				o2 = true;
			}
		}

		if (BuilderScript.final2 == true) {
			if (o == false) {
				navmeshAgent.SetDestination (finalb.transform.position);
				o = true;
			}
			Vector3 directionf = finalb.transform.position - transform.position;
			if (directionf.magnitude < accuracyWP) {
				/*anim.SetBool ("isIdle", true);
				anim.SetBool ("isRunning", false);
				anim.SetBool ("isCutting", false);*/
				navmeshAgent.Stop (true);
			} //else {
			/*anim.SetBool ("isIdle", false);
				anim.SetBool ("isRunning", true);
				anim.SetBool ("isCutting", false);*/
			//	}
		}

		/*if (navmeshAgent.velocity != Vector3.zero) {
			worker2go = true;
		}*/

		if (axe == true) //&& navmeshAgent.velocity != Vector3.zero) 
		{
			anim.SetBool ("isCutting", true);
			anim.SetBool ("isRunning", false);
			anim.SetBool ("isIdle", false);

		} else if (axe == false && navmeshAgent.velocity == Vector3.zero) 
		{
			anim.SetBool ("isIdle", true);
			anim.SetBool ("isRunning", false);
			anim.SetBool ("isCutting", false);
		}
		else if  (axe == false && navmeshAgent.velocity != Vector3.zero)	
		{
			anim.SetBool ("isRunning", true);
			anim.SetBool ("isIdle", false);
			anim.SetBool ("isCutting", false);
		}

	}
}

