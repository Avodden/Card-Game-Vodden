using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public float moveSpeed = 5f;
	public float turnSpeed = 1000f;
	public float mouseSensitivity = 1000f;
	public float bobbingSpeed = 0.18f;
	public float bobbingAmount = 0.05f;

	private float defaultYPos = 0;
	private float bobbingTimer = 0;

	private void Start()
	{
		defaultYPos = transform.localPosition.y;
	}

	private void Update()
	{
		// Handle movement
		float moveDirection = 0f;
		if (Input.GetKey(KeyCode.W))
		{
			moveDirection += 1f;
		}
		if (Input.GetKey(KeyCode.S))
		{
			moveDirection -= 1f;
		}

		// Handle strafing
		float strafeDirection = 0f;
		if (Input.GetKey(KeyCode.A))
		{
			strafeDirection -= 1f;
		}
		if (Input.GetKey(KeyCode.D))
		{
			strafeDirection += 1f;
		}

		// Apply movement
		Vector3 move = transform.forward * moveDirection * moveSpeed * Time.deltaTime;
		Vector3 strafe = transform.right * strafeDirection * moveSpeed * Time.deltaTime;
		transform.position += move + strafe;

		// Apply rotation with mouse input
		float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
		transform.Rotate(0, mouseX, 0);

		// Apply bobbing effect
		if (moveDirection != 0 || strafeDirection != 0)
		{
			bobbingTimer += bobbingSpeed;
			float newY = defaultYPos + Mathf.Sin(bobbingTimer) * bobbingAmount;
			transform.localPosition = new Vector3(transform.localPosition.x, newY, transform.localPosition.z);
		}
		else
		{
			bobbingTimer = 0;
			transform.localPosition = new Vector3(transform.localPosition.x, defaultYPos, transform.localPosition.z);
		}
	}
}