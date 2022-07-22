using UnityEngine;

public class PlayerInput : MonoBehaviour {

	private Vector2 movement;
	private bool isJumping;

	private void Update() {
		movement.x = Input.GetAxisRaw("Horizontal");
		movement.y = Input.GetAxisRaw("Vertical");

		isJumping = Input.GetKey(KeyCode.Space);

	}

	public Vector2 GetInput() { return movement; }

	public bool IsJumping() { return isJumping; }

}