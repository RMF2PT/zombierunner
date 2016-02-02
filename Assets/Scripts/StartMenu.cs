using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
 
public class StartMenu : MonoBehaviour {

	public Canvas quitMenu;
	public Canvas controlsMenu;
	public Canvas creditsMenu;
	public Canvas creditsMenu2;
	public Button startText;
	public Button controlsText;
	public Button creditsText;
	public Button exitText;

 	void Start () {
 		Screen.SetResolution(1024, 768, false);
 		quitMenu = quitMenu.GetComponent<Canvas>();
		startText = startText.GetComponent<Button>();
		controlsText = controlsText.GetComponent<Button>();
		exitText = exitText.GetComponent<Button>();
		quitMenu.enabled = false;
		controlsMenu.enabled = false;
		creditsMenu.enabled = false;
		creditsMenu2.enabled = false;
		Cursor.visible = true;
		Cursor.lockState = CursorLockMode.None;
 	}

 	public void ExitPress () {
 		quitMenu.enabled = true;
 		startText.enabled = false;
 		exitText.enabled = false;
 		controlsText.enabled = false;
		creditsText.enabled = false;
 	}

	public void ControlsPress () {
		controlsMenu.enabled = true;
 		startText.enabled = false;
 		exitText.enabled = false;
		controlsText.enabled = false;
		creditsText.enabled = false;
 	}

	public void CreditsPress () {
		creditsMenu.enabled = true;
		creditsMenu2.enabled = false;
 		startText.enabled = false;
 		exitText.enabled = false;
		controlsText.enabled = false;
		creditsText.enabled = false;
 	}

	public void Credits2Press () {
		creditsMenu2.enabled = true;
		creditsMenu.enabled = false;
 		startText.enabled = false;
 		exitText.enabled = false;
		controlsText.enabled = false;
		creditsText.enabled = false;
 	}

	public void NoPress () {
 		quitMenu.enabled = false;
		controlsMenu.enabled = false;
		creditsMenu.enabled = false;
		creditsMenu2.enabled = false;
 		startText.enabled = true;
 		exitText.enabled = true;
 		controlsText.enabled = true;
		creditsText.enabled = true;
 	}

 	public void StartLevel () {
 		SceneManager.LoadScene(1);
 	}

	public void ExitGame () {
 		Application.Quit();
 	}
}