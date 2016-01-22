using UnityEngine;
using System.Collections;

public class Zombie : MonoBehaviour {

	public bool isDead = false;

	[SerializeField]
	private int initialHealth = 200;
	private float health = 200;
	private NavMeshAgent agent;
	private Animator anim;

	void Start () {
		anim = GetComponent<Animator>();
		agent = GetComponent<NavMeshAgent>();
		health = initialHealth;
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
		SendMessageUpwards("OnSpawningZombie");
		Destroy(this); // don't kill the player
	}
}
