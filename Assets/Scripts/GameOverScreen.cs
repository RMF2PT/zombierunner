using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour {

	private AudioSource audioSource;

	void Start () {
		audioSource = GetComponent<AudioSource>();
		audioSource.Play();
		if (SceneManager.GetActiveScene().buildIndex == 3) {
			StartCoroutine(FadeOutSound());
		}
		Invoke("MainMenu", 5f);
	}

	void MainMenu () {
		SceneManager.LoadScene(0);
	}

	IEnumerator FadeOutSound () {
		for (float intensity = 0.5f; intensity >= 0f; intensity -= 0.002f) {
			audioSource.volume = intensity;
			yield return null;
		}
	}
}
