using UnityEngine;
using System.Collections;

public class RadioSystem : MonoBehaviour {

	public AudioClip initialHeliCall;
	public AudioClip initialCallReply;

	private AudioSource audioSource;

	void Start () {
		audioSource = GetComponent<AudioSource>();
	}

	void OnMakeInitialHeliCall () {
		audioSource.clip = initialHeliCall;
		audioSource.Play ();

		Invoke ("InitialCallReply", initialHeliCall.length + 1f);
	}

	void InitialCallReply () {
		audioSource.clip = initialCallReply;
		audioSource.Play ();
		BroadcastMessage("OnDispatchHelicopter");
	}
}
