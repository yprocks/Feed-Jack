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
	public Text gameOverText;
	public Text levelCompleteText;

	public Slider healthHUD;

	//private variables
	private AudioSource[] sounds;

	private AudioSource gameMusic;
	private AudioSource tickSound;
	private AudioSource coinPickup;
	private AudioSource bananaPickup;
	private AudioSource gemPickup;
	private AudioSource levelComplete;
	private AudioSource playerDeath;

	private int bananas;
	private int coins;
	private int gems;
	private int score;

	private bool isGameOver;

	// Use this for initialization
	void Start () {

		sounds = gameObject.GetComponents<AudioSource> ();

		gameMusic     = sounds [0];
		tickSound     = sounds [1];
		coinPickup    = sounds [2];
		bananaPickup  = sounds [3];
		gemPickup 	  = sounds [4];
		levelComplete = sounds [5];
		playerDeath   = sounds [6];

		bananas = 10;
		coins = 0;
		gems = 0;

		scoreText.text = "Score : " + score;
		gemText.text = "" + gems;
		coinText.text = "" + coins;

		gameOverText.text = "";
		levelCompleteText.text = "";

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
		yield return new WaitForSeconds (2F);

		while(true){
				yield return new WaitForSeconds (5F);
				bananas --;
				if (bananas < 10) {
					tickSound.Play ();
					RemoveHealth ();
				}
				

		}
	}
	
	// Update is called once per frame
	void Update () {

		if (healthHUD.value == 0) {
			SetGameOver ();
		}

		CheckGameOver ();
	}

	public void AddCoins (){
		coinPickup.Play ();
		coins ++;
		coinText.text = "" + coins;
	}

	public void AddScore (int scoreValue){
		score += scoreValue;
		scoreText.text = "Score : " + score;
	}

	public void AddGems (){
		gemPickup.Play ();
		gems ++;
		gemText.text = "" + gems;
	}

	public void AddHealth () // Add health with 1 banana 
	{  
		bananaPickup.Play ();
		bananas ++;
		healthHUD.value ++;
	}

	public void SetGameOver(){
		playerDeath.Play ();
		isGameOver = true;
	}

	public void LoadNewLevel(){
		levelComplete.Play ();
		levelCompleteText.text = "Level " + GetLevel () + 1 + " Complete";
		//SceneManager.LoadScene (level);
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

	private void RemoveHealth() //Remove 1 within 5 seconds
	{
		healthHUD.value --;
	}

	private bool GetGameOver(){
		return isGameOver;
	}

	public int GetLevel(){
		return SceneManager.GetActiveScene().buildIndex;
	}

	private void CheckGameOver(){

		if(GetGameOver ()){
			gameOverText.text = "Game Over";
			
		}

	}

}
