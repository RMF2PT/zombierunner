using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public Transform playerSpawnPoints; // parent of player spawn points
	public bool respawn = false;

	private Transform[] spawnPoints;
	private bool lastToggle = false;

	void Start () {
		spawnPoints = playerSpawnPoints.GetComponentsInChildren<Transform>();
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

}
