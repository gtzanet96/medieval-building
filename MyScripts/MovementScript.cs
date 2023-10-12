using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
	static Animator anim;
	public float speed = 8.0F;
	public float jumpSpeed = 10.0F;
	public float gravity = 20.0F;
	public float rotateSpeed = 80.0F;
	private Vector3 moveDirection = Vector3.zero;

	// Use this for initialization
	void Start()
	{
		anim = GetComponent<Animator> ();
	}
		
	void Update()
	{

		CharacterController controller = GetComponent<CharacterController>();
		if (controller.isGrounded)
		{
			moveDirection = new Vector3(0, 0, Input.GetAxis("Vertical"));
			moveDirection = transform.TransformDirection(moveDirection);
			moveDirection *= speed;
			if (Input.GetButton ("Jump")) {
				anim.SetTrigger ("isJumping");
				moveDirection.y = jumpSpeed;
			}

		}
		moveDirection.y -= gravity * Time.deltaTime;
		controller.Move(moveDirection * Time.deltaTime);

		//Rotate Player
		transform.Rotate(0, Input.GetAxis("Horizontal")*rotateSpeed, 0);

		if(Input.GetAxis("Vertical") * speed != 0)
		{
			anim.SetBool("isRunning",true);
			anim.SetBool("isIdle",false);
		}
		else
		{
			anim.SetBool("isRunning",false);
			anim.SetBool("isIdle",true);
		}
	}
}