using UnityEngine;
using System.Collections;

public class Zombie : MonoBehaviour {

	private Animator anim;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		anim.SetFloat ("Forward", Input.GetAxis("Vertical"));

		transform.Rotate (Vector3.up * Time.deltaTime * 100f * Input.GetAxis("Horizontal"));

		if (Input.GetButtonDown("Jump")) {
			anim.SetBool("ZombieDied", true);
			Invoke ("ZombieDies", 0.01f);
		}
	}

	void ZombieDies () {
		anim.SetBool("ZombieDied", false);
		Invoke ("DestroyZombie", 2.25f);
	}

	void DestroyZombie () {
		GameObject.Destroy(gameObject);
	}
}
