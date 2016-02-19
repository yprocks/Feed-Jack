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
			gameController.AddHealth ();
			Destroy (other.gameObject);
		}

		if (other.gameObject.tag == "gem") {
			gameController.AddGems ();
			Destroy (other.gameObject);
		}

		if (other.gameObject.tag == "deadZone"){
			gameController.SetGameOver ();
			Destroy (this.gameObject);
		}

		if (other.gameObject.tag == "levelComplete"){
			gameController.LevelCompleteScreen ();
		}

	}
}
