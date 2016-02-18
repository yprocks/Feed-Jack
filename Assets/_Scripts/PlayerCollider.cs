using UnityEngine;
using System.Collections;

public class PlayerCollider : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	void OnCollisionEnter2D(Collision2D other){

		if (other.gameObject.tag == "pickups") {
			Destroy (other.gameObject);
		} 

		if (other.gameObject.tag == "banana") {
			Destroy (other.gameObject);
		}

	}
}
