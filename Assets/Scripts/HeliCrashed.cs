using UnityEngine;
using System.Collections;

public class HeliCrashed : MonoBehaviour {

	public GameObject explosion;

	private AudioSource audioSource;
	private bool hasExploded = false;

	void Start () {
		audioSource = GetComponent<AudioSource>();
	}

	void Update () {
		if (Time.timeScale == 0) {
			audioSource.Pause();
		} else {
			audioSource.UnPause();
		}
	}
	
	void OnTriggerEnter (Collider other) {
		if (other.tag == "Player" && !hasExploded) {
			Vector3 explosionPosition = new Vector3 (208.83f, 53.27f, 430.23f);
			Instantiate (explosion, explosionPosition, transform.rotation);
			audioSource.Play();
			hasExploded = true;
		}
	}
}
