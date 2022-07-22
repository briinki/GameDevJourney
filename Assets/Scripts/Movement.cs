using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

	public float moveSpeed = 10f;
	public float jumpForce = 10f;

	private PlayerInput input;
	private Rigidbody rb;

	[SerializeField] bool currentlyJumping = false;

	private void Awake() {
		this.input = GetComponent<PlayerInput>();
		this.rb = GetComponent<Rigidbody>();
	}

	private void FixedUpdate() {
		Move();
	}

	private void Move() {
		Vector3 movement = new Vector3(input.GetInput().x, 0f, input.GetInput().y);
		rb.MovePosition(rb.position + movement * moveSpeed * Time.deltaTime);

		if (input.IsJumping() && !currentlyJumping) {
			currentlyJumping = true;
			Debug.Log("Jumping");
			rb.AddForce(Vector3.up * jumpForce);
		}
	}

	private void OnCollisionEnter(Collision other) {
		switch (other.collider.name) {
			case "Ground":
				currentlyJumping = false;
				break;

			default:
				Debug.Log("Collided with:" + other.collider.name);
				break;
		}
	}

}
