using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {

	public AudioClip[] audioclip;
	
	private Animator anim;
	private AudioSource audioSource;
	private Player player;

	void Start () {
		player = GetComponentInParent<Player>();
		anim = GetComponent<Animator>();
		audioSource = GetComponent<AudioSource>();
	}

	void Update () {
		if (Input.GetButtonDown("Fire1") && player.ammo > 0 && Time.timeScale != 0) {
			anim.SetTrigger("Shooting");
			audioSource.PlayOneShot(audioclip[0]);
			player.ammo--;
		} else if (Input.GetButtonDown("Fire1") && player.ammo <= 0 && Time.timeScale != 0) {
			audioSource.PlayOneShot(audioclip[1]);
		}

		if (Time.timeScale == 0) {
			audioSource.Pause();
		}
	}

	void OnFlyOver () {
		Destroy (this.gameObject);
	}
}
