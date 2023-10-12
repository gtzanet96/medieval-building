using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FindClosestWorkers : MonoBehaviour {

	public GameObject[] waypoints;
	public GameObject workspace;
	public GameObject final;
	bool finalp = false;
	Animator anim;
	public float rotSpeed = 0.8f;
	public float speed = 3.0f;
	float accuracyWP = 10.0f;
	float accuracyWsp = 3.0f;
	public static int currentWP = 0;
	bool goBoss = false;
	private float delayBeforeLoading = 1.5f;
	private float TimeElapsed;
	NavMeshAgent navmeshAgent;
	List<Transform> path = new List<Transform>();
	public bool o = false;
	public bool o2 = false;

	void Start () 
	{
		navmeshAgent = GetComponent<NavMeshAgent> ();
		anim = GetComponent<Animator> ();
		foreach (GameObject go in waypoints)
		{
			path.Add(go.transform);
		}
		currentWP = FindClosestWP ();
	}

	int FindClosestWP()
	{

		if (path.Count == 0) return -1;
		int closest = 0;
		float lastDist = Vector3.Distance (this.transform.position, path[0].position);
		for (int i = 1; i < path.Count; i++)
		{
			float thisDist = Vector3.Distance (this.transform.position, path[i].position);
			if (lastDist > thisDist && i != currentWP) 
			{
				closest = i;
			}
		}
		return closest;
	}
		

	void Update ()
	{

		if (FindClosest1.a1 == 7) {
			if (FinalPoint2.FP2entrance6 == false && o == false) {
				navmeshAgent.SetDestination (final.transform.position);
				o = true;
				NPCDialogue.mission = 3;
			}
		} else {
			
			if (NPCDialogue.goBoss == true && currentWP == 0) {
				navmeshAgent.SetDestination (waypoints [currentWP].transform.position);
				NPCDialogue.goBoss = false;
			}

			if (FinalPoint.FPentrance == false && currentWP < 3) {
				Vector3 direction = path [currentWP].position - transform.position;
				if (direction.magnitude < accuracyWP) {
					TimeElapsed += Time.deltaTime;
					path.Remove (path [currentWP]);
					if (currentWP <= 2) {
						currentWP = FindClosestWP ();
						navmeshAgent.SetDestination (path [currentWP].transform.position);
					}
				}
			}

		}
		if (navmeshAgent.velocity != Vector3.zero) {
			anim.SetBool ("isIdle", false);
			anim.SetBool ("isWalking", true);
		} 
		if (navmeshAgent.velocity == Vector3.zero) {
			anim.SetBool ("isWalking", false);
			anim.SetBool ("isIdle", true);
		}
			
	}
}
