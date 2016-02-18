using UnityEngine;
using System.Collections;

public class PlayerCollider : MonoBehaviour {

	public GameController gameController;

	// Use this for initialization
	void Start () {
	
	}
	
	void OnCollisionEnter2D(Collision2D other){

		if (other.gameObject.tag == "pickups") {
			gameController.AddCoins ();
			gameController.AddScore (10);
			Destroy (other.gameObject);
		} 

		if (other.gameObject.tag == "banana") {
			Destroy (other.gameObject);
		}

		if (other.gameObject.tag == "gem") {
			gameController.AddGems ();
			Destroy (other.gameObject);
		}

	}
}
