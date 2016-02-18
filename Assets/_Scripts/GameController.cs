using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	//public variables
	public GameObject gem;

	//private variables


	// Use this for initialization
	void Start () {

		SpawnAGem ();
	}

	void SpawnAGem(){

			Instantiate (
				gem, 
				new Vector3( Random.Range(1000, 5280), Random.Range(-40, 60), 0 ), 
				Quaternion.identity
				);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
