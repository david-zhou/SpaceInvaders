using UnityEngine;
using System.Collections;

public class PlayerLaserCollider : MonoBehaviour {
	void OnTriggerEnter(Collider collider)
	{
		Debug.Log ("hit with Crane");
		Destroy(collider.gameObject);
		Destroy(gameObject);

	}
}
