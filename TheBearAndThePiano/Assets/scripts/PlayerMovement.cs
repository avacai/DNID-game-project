using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour { 
	[SerializeField]private int speed = 5;
	private Vector2 movement;
	private Rigidbody2D rb;
	private bool canMove = true; 

	private void Awake(){
		rb = GetComponent<Rigidbody2D>();
	}

	public void OnMovement(InputValue value) {
		if (canMove) { // Check if movement is allowed
			movement = value.Get<Vector2>();
		}
	}

	private void FixedUpdate(){
		if (canMove) { // Check if movement is allowed
			// Move the player
			rb.AddForce(movement * speed);
		}
	}

	// Method to enable movement
	public void EnableMovement() {
		canMove = true;
	}

	// Method to disable movement
	public void DisableMovement() {
		canMove = false;
		movement = Vector2.zero; // Reset movement
		rb.velocity = Vector2.zero; // Stop the rigidbody's movement
	}
}
