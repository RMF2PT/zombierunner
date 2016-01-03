using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public Transform playerSpawnPoints; // parent of player spawn points

	private bool respawn = false;
	private Transform[] spawnPoints;
	private bool lastRespawnToggle = false;

	void Start () {
		spawnPoints = playerSpawnPoints.GetComponentsInChildren<Transform>();
	}

	void Update () {
		if (Input.GetButton("CheckArea")) {
			BroadcastMessage("OnCheckClearArea");
		}

		if (lastRespawnToggle != respawn) {
			Respawn();
			respawn = false;
		} else {
			lastRespawnToggle = respawn;
		}
	}

	private void Respawn () {
		int i = Random.Range(1, spawnPoints.Length);
		transform.position = spawnPoints[i].transform.position;
	}

	void OnFindClearArea () {
		Invoke ("DropFlare", 3f);
	}

	void DropFlare () {
		// Deploy a flare
		// Start spawning zombies
	}
}
