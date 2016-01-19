using UnityEngine;
using System.Collections;

public class Zombie : MonoBehaviour {

	private float health = 200f;
	private NavMeshAgent agent;
	private Animator anim;

	void Start () {
		anim = GetComponent<Animator>();
		agent = GetComponent<NavMeshAgent>();
	}

	void ZombieDies () {
		anim.SetBool("ZombieDied", false);
		Invoke ("DestroyZombie", 2.25f);
	}

	void DestroyZombie () {
		GameObject.Destroy(gameObject);
	}

	void ApplyDammage (float damage) {
		health -= damage;
		if (health <= 0f) {
			Die ();
		}
	}

	void Die () {
		agent.speed = 0;
		int random = Random.Range (1, 3);
		if (random < 2) {
			anim.SetTrigger ("ZombieDead");
		}
		else {
			anim.SetTrigger ("ZombieDead2");
		}
		Destroy(this); // don't kill the player
	}
}
