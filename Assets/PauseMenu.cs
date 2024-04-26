using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnitySceneManager = UnityEngine.SceneManagement.SceneManager;

public class PauseMenu : MonoBehaviour
{
    public static bool gamePaused = false;
	public GameObject pauseMenuUI;
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)){
			if (gamePaused){
				Resume();
			}
			else{
				Pause();
			}
		}
    }
	
	public void Resume(){
		pauseMenuUI.SetActive(false);
		Time.timeScale = 1f;
		gamePaused = false;
	}
	void Pause(){
		pauseMenuUI.SetActive(true);
		Time.timeScale = 0f;
		gamePaused = true;
	}

	public void LoadMenu(){
		Time.timeScale = 1f;
		UnityEngine.SceneManagement.SceneManager.LoadScene("MainScreen");
	}
	
	public void quitGame(){
		Debug.Log("you just quit the game");
		Application.Quit();
	}
}
