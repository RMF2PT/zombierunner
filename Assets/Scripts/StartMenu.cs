using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
 
public class StartMenu : MonoBehaviour {

	public Canvas quitMenu;
	public Canvas controlsMenu;
	public Button startText;
	public Button controlsText;
	public Button exitText;

 	void Start () {
 		quitMenu = quitMenu.GetComponent<Canvas>();
		startText = startText.GetComponent<Button>();
		controlsText = controlsText.GetComponent<Button>();
		exitText = exitText.GetComponent<Button>();
		quitMenu.enabled = false;
		controlsMenu.enabled = false;
		Cursor.visible = true;
		Cursor.lockState = CursorLockMode.None;
 	}

 	public void ExitPress () {
 		quitMenu.enabled = true;
 		startText.enabled = false;
 		exitText.enabled = false;
 		controlsText.enabled = false;
 	}

	public void ControlsPress () {
		controlsMenu.enabled = true;
 		startText.enabled = false;
 		exitText.enabled = false;
		controlsText.enabled = false;
 	}

	public void NoPress () {
 		quitMenu.enabled = false;
		controlsMenu.enabled = false;
 		startText.enabled = true;
 		exitText.enabled = true;
 		controlsText.enabled = true;
 	}

 	public void StartLevel () {
 		SceneManager.LoadScene(1);
 	}

	public void ExitGame () {
 		Application.Quit();
 	}
}