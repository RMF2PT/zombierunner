using UnityEngine;
using System.Collections;

public class RadioSystem : MonoBehaviour {

	public AudioClip initialHeliCall;
	public AudioClip initialCallReply;

	private AudioSource audioSource;

	void Start () {
		audioSource = GetComponent<AudioSource>();
	}

	void Update () {
		if (Time.timeScale == 0f) {
			audioSource.Pause();
		} else {
			audioSource.UnPause();
		}
	}

	void OnMakeInitialHeliCall (Vector3 position) {
		audioSource.clip = initialHeliCall;
		audioSource.Play ();
		StartCoroutine ("InitialCallReply", position);
	}

	IEnumerator InitialCallReply (Vector3 position) {
		yield return new WaitForSeconds (initialHeliCall.length + 1f);
		audioSource.clip = initialCallReply;
		audioSource.Play ();
		BroadcastMessage("OnDispatchHelicopter", position);
	}

	void OnEscaping () {
		BroadcastMessage("OnFlyOver");
	}
}
