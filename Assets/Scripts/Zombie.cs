using UnityEngine;
using System.Collections;

public class Zombie : MonoBehaviour {

	public bool isDead = false;

	[SerializeField]
	private int initialHealth = 200;
	private float health = 200;
	private NavMeshAgent agent;
	private Animator anim;
	private Vector3 spawnPosition;
	private Quaternion initialRotation;

	void Start () {
		anim = GetComponent<Animator>();
		agent = GetComponent<NavMeshAgent>();
		spawnPosition = transform.position;
		initialRotation = transform.rotation;
		health = initialHealth;
	}

	void DestroyZombie () {
		Instantiate(this, spawnPosition, initialRotation);
		health = initialHealth;
		isDead = false;
		health = 200;
		Destroy(this.gameObject, 10f);
		agent.speed = 0.6f;
	}

	void ApplyDammage (int damage) {
		health -= damage;
		if (health <= 0) {
			Die ();
		}
	}

	void Die () {
		isDead = true;
		agent.speed = 0;
		int random = Random.Range (1, 3);
		if (random < 2) {
			anim.SetTrigger ("ZombieDead");
		}
		else {
			anim.SetTrigger ("ZombieDead2");
		}
		DestroyZombie();
		Destroy(this); // don't kill the player
	}
}
