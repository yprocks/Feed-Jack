using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameController : MonoBehaviour {

	//public variables
	public GameObject gem;

	public Text scoreText;
	public Text gemText;
	public Text coinText;

	public Slider healthHUD;


	//private variables
	private int bananas;
	private int coins;
	private int gems;
	private int score;

	private bool isGameOver;


	// Use this for initialization
	void Start () {
		
		bananas = 10;
		coins = 0;
		gems = 0;

		scoreText.text = "Score : " + score;
		gemText.text = "" + gems;
		coinText.text = "" + coins;

		isGameOver = false;

		SpawnAGem ();
		StartCoroutine (PlayerHealth ());

	}

	void SpawnAGem(){

			Instantiate (
				gem, 
				new Vector3( Random.Range(1000, 5280), Random.Range(-40, 60), 0 ), 
				Quaternion.identity
				);

	}

	IEnumerator PlayerHealth(){
		yield return new WaitForSeconds (5F);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void AddCoins (){
		coins ++;
		coinText.text = "" + coins;
	}

	public void AddScore (int scoreValue){
		score += scoreValue;
		scoreText.text = "Score : " + score;
	}

	public void AddGems (){
		gems ++;
		gemText.text = "" + gems;
	}

	public void AddHealth (int addBananas) // Add health with 1 banana 
	{  
		bananas += addBananas;
	}

	public void SetGameStatus(bool status){
		isGameOver = status;
	}


	//private methods
	private int GetCoins(){
		return coins;
	}

	private int GetScore(){
		return score;
	}

	private int GetGems(){
		return gems;
	}

	private void RemoveHealth(int removeHealth) //Remove 1 within 5 seconds
	{

	}

	private bool GetGameStatus(){
		return isGameOver;
	}

	private void CheckGameOver(){
		
	}

}
