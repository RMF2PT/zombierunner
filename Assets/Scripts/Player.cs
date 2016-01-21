using UnityEngine;
using System.Collections;
using UnityStandardAssets.ImageEffects;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

	public Transform playerSpawnPoints; // parent of player spawn points
	public GameObject landingAreaPrefab;
	public float initialHealth = 200f;
	public float health;
	public int lives = 3;

	private GameObject helicopter;
	private Transform[] spawnPoints;
	private bool foundLandingArea = false;
	private VignetteAndChromaticAberration vignette;

	void Start () {
		try {
			spawnPoints = playerSpawnPoints.GetComponentsInChildren<Transform>();
		} catch {
			Debug.LogError ("Player Spawn Points not answering!");
		}

		try {
			helicopter = GameObject.FindGameObjectWithTag("Helicopter");
		} catch {
			Debug.LogError ("Can't find the helicopter!");
		}

		vignette = GetComponentInChildren<VignetteAndChromaticAberration>();
		vignette.intensity = 1f;
		StartCoroutine("FadeIn");
		health = initialHealth;
	}

	IEnumerator FadeIn () {
		for (float intensity = 1f; intensity >= 0f; intensity -= 0.005f) {
			vignette.intensity = intensity;
			vignette.blur = intensity;
			yield return null;
		}
	}

	IEnumerator FadeOut () {
		for (float intensity = 0.5f; intensity <= 1f; intensity += 0.005f) {
			vignette.intensity = intensity;
			vignette.blur = intensity;
			yield return null;
		}
	}

	IEnumerator Respawn () {
		while (vignette.intensity <= 0.95f) {
			yield return null;
		}
		lives--;
		if (lives > 0) {
			health = initialHealth;
			int i = Random.Range (1, spawnPoints.Length);
			transform.localPosition = spawnPoints [i].transform.position;
		} else {
			SceneManager.LoadScene(2);
		}
		StartCoroutine(FadeIn());
	}

	void Death () {
		StartCoroutine("FadeOut");
		StartCoroutine ("Respawn");
	}

	void DropFlare () {
		Instantiate (landingAreaPrefab, transform.position, transform.rotation);
	}

	void OnTriggerEnter (Collider other) {
		if (other.tag == "LandingArea" && !foundLandingArea) {
			BroadcastMessage("OnFindClearArea", other.transform.position);
			Invoke ("DropFlare", 3f);
			foundLandingArea = true;
		}

		if (other.GetComponent<Helicopter>()) {
			Camera heliCam = helicopter.GetComponentInChildren<Camera>();
			heliCam.enabled = true;
			heliCam.Render();
//			this.enabled = false;
			SendMessageUpwards("OnEscaping");
		}

		if (other.tag == "Water" && health > 0f) {
			health = 0f;
			Death();
		}
	}

	void OnTriggerStay (Collider other) {
		if (other.GetComponent<Zombie> () && health > 0f) {
			health -= 50f * Time.deltaTime;
			if (health <= 0f) {
				health = 0f;
				Death();
			}
		}
	}
}
