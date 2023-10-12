using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class FindClosest1 : MonoBehaviour {

	public GameObject[] waypoints;
	public GameObject workspace;
	public GameObject firstTree;
	public GameObject secondTree;
	public GameObject log1;
	public GameObject log4;
	Animator anim;
	public float rotSpeed = 0.8f;
	public float speed = 10.0f;
	float accuracyWP = 6.0f;
	int currentWP = 0;
	//List<Transform> path = new List<Transform>();
	bool goWorker = false;
	bool axe = false;
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
	public static bool worker1go = false;
	public static int a1 = 1;
	public GameObject finalb;
	public bool o = false;
	public float accuracyWP2 = 3.0f;

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
		if (a1 == 1) {
			if (CheckForChat2.entrance2 == true) {
				goWorker = true;
			}

			if (goWorker == true && eftase == false) {
				navmeshAgent.SetDestination (waypoints [currentWP].transform.position);
			}

			if (FinalPoint2.FP2entrance1 == false) {// && eftase == false) {
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
						a1 = 2;
					}
				}
			}
		}

		if (a1 == 2) {
			//Debug.Log ("1");
			if (FinalPoint2.FP2entrance1 == true) {
				
				TimeElapsed2 += Time.deltaTime;
				if (TimeElapsed2 > delayBeforeLoading2) {
					log1.SetActive (true);
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
						a1 = 3;
					}
				}
			}

		}

		if (a1 == 3 && FinalPoint2.FP2entrance1 == true) {
			TimeElapsed4 += Time.deltaTime;
			if (TimeElapsed4 > delayBeforeLoading4) {
				log4.SetActive (true);
			}
		}

		if (BuilderScript.final1 == true) {
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

		if (navmeshAgent.velocity != Vector3.zero) {
			worker1go = true;
		}

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