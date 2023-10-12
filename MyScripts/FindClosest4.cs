using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Animations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Animations;

public class FindClosest4 : MonoBehaviour {

	public GameObject[] waypoints;
	public GameObject workspace;
	public GameObject firstRock;
	public GameObject secondRock;
	public GameObject rock1;
	//public GameObject log6;
	Animator anim;
	public float rotSpeed = 0.8f;
	public float speed = 10.0f;
	float accuracyWP = 6.0f;
	int currentWP = 0;
	//List<Transform> path = new List<Transform>();
	bool goWorker = false;
	bool axe = false;
	bool o3 = false;
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
	public static bool worker3go = false;
	public static int a3 = 1;
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




	void Update ()
	{
		
		if (a3 == 1) {
			if (FinalPoint.FPentrance == true) {
				goWorker = true;
			}

			if (goWorker == true && eftase == false) {
				navmeshAgent.SetDestination (waypoints [currentWP].transform.position);
			}

			if (FinalPoint2.FP2entrance4 == false) {// && eftase == false) {
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
						firstRock.SetActive (false);
						//eftase = false;
						currentWP = FindClosestWP ();
						a3 = 2;
					}
				}
			}
		}

		if (FinalPoint2.FP2entrance4 == true && o3 == false) {
			rock1.SetActive (true);
			o3 = true;
		}


		/*if (navmeshAgent.velocity != Vector3.zero) {
			worker3go = true;
		}*/

		if (BuilderScript.final4 == true) {
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