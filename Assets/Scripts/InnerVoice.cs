using UnityEngine;
using System.Collections;

public class InnerVoice : MonoBehaviour {

	public AudioClip whatHappened;
	public AudioClip goodLandingArea;
	public AudioClip NotAGoodLandingArea;

	private AudioSource audioSource;

	void Start () {
		audioSource = GetComponent<AudioSource>();
		audioSource.clip = whatHappened;
		audioSource.Play ();
	}

	void OnNotClearArea () {
		if (!audioSource.isPlaying) {
			audioSource.clip = NotAGoodLandingArea;
			audioSource.Play ();
		}
	}

	void OnFindClearArea () {
		if (!audioSource.isPlaying) {
			audioSource.clip = goodLandingArea;
			audioSource.Play ();
			Invoke ("CallHeli", goodLandingArea.length + 1f);
		}
	}

	void CallHeli () {
		SendMessageUpwards ("OnMakeInitialHeliCall");
	}
}
