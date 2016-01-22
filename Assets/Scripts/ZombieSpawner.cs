using UnityEngine;
using System.Collections;

public class ZombieSpawner : MonoBehaviour {

	public GameObject[] zombiePrefabs;

	[SerializeField]
	private Transform upperSpawnPosition, lowerSpawnPosition;
	private GameObject player;

	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
	}

	void OnSpawningZombie () {
		if (player.transform.position.z >= 300f) {
			// player is on upper zone of map
			int n = Random.Range(0, zombiePrefabs.Length);
			GameObject newZombie = Instantiate(zombiePrefabs[n], lowerSpawnPosition.transform.position, Quaternion.identity) as GameObject;
			newZombie.transform.SetParent(this.transform);
		} else {
			// player is on lower zone of map
			int n = Random.Range(0, zombiePrefabs.Length);
			GameObject newZombie = Instantiate(zombiePrefabs[n], upperSpawnPosition.transform.position, Quaternion.identity) as GameObject;
			newZombie.transform.SetParent(this.transform);
		}
	
	}
}
