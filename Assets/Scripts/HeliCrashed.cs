using UnityEngine;
using System.Collections;

public class HeliCrashed : MonoBehaviour {

	public GameObject explosion;

	private AudioSource audioSource;
	private bool hasExploded = false;

	void Start () {
		audioSource = GetComponent<AudioSource>();
	}
	
	void OnTriggerEnter (Collider other) {
		if (other.tag == "Player" && !hasExploded) {
			Vector3 explosionPosition = new Vector3 (208.83f, 53.27f, 430.23f);
			Instantiate (explosion, explosionPosition, transform.rotation);
			//explosion.transform.parent = gameObject.transform;
			audioSource.Play();
			hasExploded = true;
		}
	}
}
