using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour
{
	float speed = 10f;
	float gravity = -9.81f;
	float jumpHeight = 3f;

	private float forward_backward_move;
	private float left_right_move;
    
	public CharacterController controller;

	

	public Transform groundCheck;
	public float groundDistance = 0.4f;
	public LayerMask groundMask;

	Vector3 velocity;
	bool isGrounded;

    // Update is called once per frame
	void Update() {
		isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

		if(isGrounded && velocity.y < 0)
		{
			velocity.y = 0f;
		}

		if(Input.GetButtonDown("Jump") && isGrounded)
		{
			Debug.Log("Hello");
			velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity ); //from equation 
		}
    	
		forward_backward_move = Input.GetAxisRaw("Vertical");
		left_right_move = Input.GetAxisRaw("Horizontal");

		Vector3 move = transform.right * forward_backward_move + transform.forward * -1 * left_right_move; 

		controller.Move(move * speed * Time.deltaTime);

		velocity.y += 2 * gravity * Time.deltaTime;
		Debug.Log(velocity.y);
		controller.Move(velocity * Time.deltaTime);
    }
}
