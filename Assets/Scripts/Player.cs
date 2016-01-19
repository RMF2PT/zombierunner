using UnityEngine;
using System.Collections;
using UnityStandardAssets.ImageEffects;

public class Player : MonoBehaviour {

	public Transform playerSpawnPoints; // parent of player spawn points
	public GameObject landingAreaPrefab;

	private GameObject helicopter;
	private Transform[] spawnPoints;
	private bool foundLandingArea = false;
	private VignetteAndChromaticAberration vignette;
	private float health = 200f;

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
	}

	IEnumerator FadeIn () {
		for (float intensity = 1f; intensity >= 0.5f; intensity -= 0.005f) {
			vignette.intensity = intensity;
			vignette.blur = intensity;
			yield return null;
		}
	}

	IEnumerator FadeOut () {
		for (float intensity = 0.5f; intensity <= 1f; intensity += 0.01f) {
			vignette.intensity = intensity;
			vignette.blur = intensity;
			yield return null;
		}
	}

	void Respawn () {
		int i = Random.Range (1, spawnPoints.Length);
		transform.localPosition = spawnPoints [i].transform.position;
	}

	IEnumerator Death () {
		yield return StartCoroutine("FadeOut");
		Respawn();
		yield return StartCoroutine("FadeIn");
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
			this.enabled = false;
			SendMessageUpwards("OnEscaping");
		}

		if (other.tag == "Water") {
			StartCoroutine ("Death");
		}
	}

	void OnTriggerStay (Collider other) {
		if (other.GetComponent<Zombie> ()) {
			health -= 50f * Time.deltaTime;
			if (health <= 0f) {
				StartCoroutine ("Death");
			}
		}
	}
}
