using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour {

	private AudioSource audioSource;

	void Start () {
		audioSource = GetComponent<AudioSource>();
		audioSource.Play();
		Invoke("MainMenu", 5f);
	}

	void MainMenu () {
		SceneManager.LoadScene(0);
	}
}
