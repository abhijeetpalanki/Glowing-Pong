using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
{
	public float racketSpeed;
	private Rigidbody2D rb;
	private Vector2 racketDirection;

	private void Start()
	{
		rb = GetComponent<Rigidbody2D>();
	}

	private void Update()
	{
		float directionY = Input.GetAxisRaw("Vertical2");

		racketDirection = new Vector2(0, directionY).normalized;
	}

	private void FixedUpdate()
	{
		rb.velocity = racketDirection * racketSpeed;
	}
}
