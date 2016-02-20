using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;


public class StartupController : MonoBehaviour {

	void Update(){
	
		if (Input.GetKey (KeyCode.Escape))
			Exit ();

	}

	public void StartLevel(){
		SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex + 1);
	}

	public void Exit(){
		Application.Quit ();
	}

}
