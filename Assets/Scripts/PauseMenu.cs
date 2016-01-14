using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
 
public class PauseMenu : MonoBehaviour {

	public Canvas quitMenu;
	public Canvas pauseMenu;
	public Button continueText;
	public Button restartText;
	public Button exitText;

	private Player player;
	private CharacterController playerController;

 	void Start () {
		pauseMenu = pauseMenu.GetComponent<Canvas>();
 		quitMenu = quitMenu.GetComponent<Canvas>();
		continueText = continueText.GetComponent<Button>();
		restartText = restartText.GetComponent<Button>();
		exitText = exitText.GetComponent<Button>();



		pauseMenu.enabled = false;
		quitMenu.enabled = false;
 	}

 	void Update () {
		if (Input.GetButton("Pause")) {
			pauseMenu.enabled = true;
			Time.timeScale = 0f;
		}
 	}

 	public void ExitPress () {
 		quitMenu.enabled = true;
		continueText.enabled = false;
		restartText.enabled = false;
 		exitText.enabled = false;
 	}

	public void NoPress () {
		quitMenu.enabled = false;
		continueText.enabled = true;
		restartText.enabled = true;
 		exitText.enabled = true;
 	}

	public void Continue () {
		Time.timeScale = 1f;
		pauseMenu.enabled = false;
 	}

 	public void RestartLevel () {
 		SceneManager.LoadScene(1);
		Time.timeScale = 1f;
 	}

	public void ExitGame () {
 		Application.Quit();
 	}
}