using UnityEngine;
using System.Collections;

public class Magazine : MonoBehaviour {

	public AudioClip pickupSound;

	private Player player;
	private GameObject playerGameObject;

	void Start () {
		playerGameObject = GameObject.FindGameObjectWithTag("Player");
		player = playerGameObject.GetComponent<Player>();
	}

	void OnTriggerEnter (Collider other) {
		if (other.gameObject == playerGameObject) {
			AudioSource.PlayClipAtPoint(pickupSound, transform.position);			
			player.ammo += 30;
			Destroy(this.gameObject);
		}
	}
}
