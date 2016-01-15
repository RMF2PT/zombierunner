using UnityEngine;
using System.Collections;
using UnityStandardAssets.ImageEffects;
using UnityStandardAssets.Characters.FirstPerson;

public class Player : MonoBehaviour {

	public Transform playerSpawnPoints; // parent of player spawn points
	public GameObject landingAreaPrefab;

	private Transform[] spawnPoints;
	private bool foundLandingArea = false;
	private VignetteAndChromaticAberration vignette;
//	private FirstPersonController fps;

	void Start () {
		try {
			spawnPoints = playerSpawnPoints.GetComponentsInChildren<Transform>();
		} catch {
			Debug.LogError ("Player Spawn Points not answering!");
		}

		vignette = GetComponentInChildren<VignetteAndChromaticAberration>();
		vignette.intensity = 1f;
		StartCoroutine("FadeIn");

//		fps = GetComponent<FirstPersonController>();
	}

	void Update () {
		if (Time.timeScale == 0) {
			
		}
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
		StartFadeIn ();
	}

	void StartFadeIn () {
		StartCoroutine ("FadeIn");
	}

	IEnumerator Death () {
		yield return StartCoroutine("FadeOut");
		Respawn();
	}

	void DropFlare () {
		Instantiate (landingAreaPrefab, transform.position, transform.rotation);
		// TODO Start spawning zombies
	}

	void OnTriggerEnter (Collider other) {
		if (other.tag == "LandingArea" && !foundLandingArea) {
			BroadcastMessage("OnFindClearArea");
			Invoke ("DropFlare", 3f);
			foundLandingArea = true;
		}

		if (other.tag == "Zombie") {
			StartCoroutine("Death");
		}
	}
}
