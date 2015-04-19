﻿using UnityEngine;
using System.Collections;

public class enemy_movement : MonoBehaviour {
	public GameObject User;

	private Vector3 initialPosition;
	private float verticalSpeed, horizontalSpeed;

	// Use this for initialization
	void Start () 
	{
		initialPosition = transform.position;
		horizontalSpeed = -0.01f;
	}
	
	// Update is called once per frame
	void Update () 
	{
		float userY = User.transform.position.y;
		float shipY = transform.position.y;
		verticalSpeed = (userY - shipY) / 100;
		Accelerate ();
		MoveShip ();
	}

	void Accelerate()
	{
		if (initialPosition.x < -2) {
			horizontalSpeed -= 0.002f;
			verticalSpeed = 0;
		}
	}

	void MoveShip()
	{
		Vector3 newPosition;
		newPosition = new Vector3 (initialPosition.x + horizontalSpeed, initialPosition.y + verticalSpeed, initialPosition.z);
		transform.position = newPosition;
		initialPosition = transform.position;
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player" || other.gameObject.tag == "PlayerBullet") 
		{
			Destroy (other.gameObject);
			Destroy (gameObject);
		}
	}
}
