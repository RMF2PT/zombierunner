using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public Helicopter helicopter;
	public Transform playerSpawnPoints; // parent of player spawn points

	public AudioClip whatHappened;

	private bool respawn = false;
	private Transform[] spawnPoints;
	private bool lastToggle = false;

	void Start () {
		spawnPoints = playerSpawnPoints.GetComponentsInChildren<Transform>();
		helicopter = GameObject.FindObjectOfType<Helicopter>();
	}

	void Update () {
		if (lastToggle != respawn) {
			Respawn();
			respawn = false;
		} else {
			lastToggle = respawn;
		}
	}

	private void Respawn () {
		int i = Random.Range(1, spawnPoints.Length);
		transform.position = spawnPoints[i].transform.position;
	}

	void OnFindClearArea () {
		Debug.Log ("Found clear area in player");
		helicopter.Call();
		// Deploy flare
		// Start spawning zombies
	}
}
