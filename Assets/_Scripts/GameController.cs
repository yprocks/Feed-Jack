using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	//public variables
	public GameObject pickups;
	public GameObject banana;

	//private variables


	// Use this for initialization
	void Start () {

		CoinSpawn ();
	}

	void CoinSpawn(){

//		for(int i = 0; i < 10; i ++)
//			Instantiate (
//				pickups, 
//				new Vector3( Random.Range(-120, 5280), Random.Range(-40, 60), 0 ), 
//				Quaternion.identity
//				);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
