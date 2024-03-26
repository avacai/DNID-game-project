using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour { 
	[SerializeField]private int speed = 5;
	private Vector2 movement;
	private Rigidbody2D rb;
	private bool canMove = true; 
	public Animator animator;

	private void Awake(){
		rb = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();
	}

	public void OnMovement(InputValue value) {
		if (canMove) { 
			movement = value.Get<Vector2>();
			animator.SetFloat("Speed", movement.sqrMagnitude);
		}
	}

	private void FixedUpdate(){
		if (canMove) { 
			// Move the player
			rb.AddForce(movement * speed);
		}
	}

	// Method to enable movement
	public void EnableMovement() {
		canMove = true;
	}

	
	public void DisableMovement() {
		canMove = false;
		movement = Vector2.zero; 
		rb.velocity = Vector2.zero; // Stop the rigidbody's movement
		animator.SetFloat("Speed", 0);
	}
}
