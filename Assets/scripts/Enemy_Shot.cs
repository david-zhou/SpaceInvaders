﻿using UnityEngine;
using System.Collections;

public class Enemy_Shot : MonoBehaviour {
	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;

	private float nextFire;
	private float horizontalSpeed;
	private Vector3 initialPosition;


	// Use this for initialization
	void Start () {
		initialPosition = transform.position;
		horizontalSpeed = -0.01f;
		nextFire = 0;
	}
	
	// Update is called once per frame
	void Update () {
		Move ();
		Shoot ();
	}

	void Move()
	{
		Vector3 newPosition;
		newPosition = new Vector3 (initialPosition.x + horizontalSpeed, initialPosition.y, initialPosition.z);
		transform.position = newPosition;
		initialPosition = transform.position;
	}

	void Shoot()
	{
		if (Time.time > nextFire) 
		{
			nextFire = Time.time + fireRate;
			Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
		}
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
