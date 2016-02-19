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
	public Text finalScore;

	public Slider healthHUD;

	public Button resetButton;
	public Button mainMenu;
	public Button loadLevelButton;


	public PlayerController playerController;

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
		finalScore.text = "";

		resetButton.gameObject.SetActive (false);
		mainMenu.gameObject.SetActive (false);
		loadLevelButton.gameObject.SetActive (false);

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

		while(true){
				yield return new WaitForSeconds (3F);
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
			playerController.SetAnimation (3);
			playerController.enabled = false;
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

	public void LevelCompleteScreen(){
		ClearUISystem ();
		gameMusic.Stop ();
		levelComplete.Play ();
		levelCompleteText.text = "Level " + GetLevel() + " Complete";
		resetButton.gameObject.SetActive (true);
		loadLevelButton.gameObject.SetActive (true);
		mainMenu.gameObject.SetActive (true);
	}

	public void MainMenu(){
		SceneManager.LoadScene ("Main");
	}

	public void Reset(){
		SceneManager.LoadScene (GetLevel());
	}

	public void LoadNewLevel(){
		SceneManager.LoadScene (GetLevel() + 1);
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

	private int GetLevel(){
		return SceneManager.GetActiveScene().buildIndex;
	}

	private void CheckGameOver(){

		if(GetGameOver ()){

			ClearUISystem ();

			gameOverText.text = "Game Over";
			finalScore.text = "Score : " + GetScore();

			mainMenu.gameObject.SetActive (true);
			resetButton.gameObject.SetActive (true);
		}

	}

	private void ClearUISystem(){
		GameObject[] clearUI = GameObject.FindGameObjectsWithTag ("ProgressUI");

		foreach(GameObject UI in clearUI){
			UI.SetActive (false);
		}

	}

}