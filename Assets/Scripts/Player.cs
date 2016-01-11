using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public Transform playerSpawnPoints; // parent of player spawn points
	public GameObject landingAreaPrefab;

//	public bool respawn = false;
	private Transform[] spawnPoints;
//	private bool lastRespawnToggle = false;
	private bool foundLandingArea = false;

	void Start () {
		try {
			spawnPoints = playerSpawnPoints.GetComponentsInChildren<Transform>();
		} catch {
			Debug.LogError ("Player Spawn Points not answering!");
		}
	}

//	void Update () {
//		if (lastRespawnToggle != respawn) {
//			Respawn();
//			respawn = false;
//		} else {
//			lastRespawnToggle = respawn;
//		}
//	}

	private void Respawn () {
		int i = Random.Range(1, spawnPoints.Length);
		transform.localPosition = spawnPoints[i].transform.position;
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
			Invoke ("Respawn", 3f);
		}
	}
}
