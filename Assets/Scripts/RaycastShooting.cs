using UnityEngine;
using System.Collections;

public class RaycastShooting : MonoBehaviour {

	public GameObject Effect;

	[SerializeField]
	private float damage = 50f;
	[SerializeField]
	private float maxDistance = 100f;
	private RaycastHit hit;
	private Ray ray;

	void Update () {
		if (Input.GetButtonDown("Fire1") && Time.timeScale != 0f) {
			FireShot ();
		}
	}

	void FireShot () {
		ray = Camera.main.ScreenPointToRay (new Vector3 (Screen.width * 0.5f, Screen.height * 0.5f, 0));
		if (Physics.Raycast (ray, out hit, maxDistance)) {
			Collider target = hit.collider;
			if (target.GetComponent<Zombie>()) {
				GameObject particleClone = Instantiate (Effect, hit.point, Quaternion.LookRotation (hit.normal)) as GameObject;
				Destroy (particleClone, 2f);
				hit.transform.SendMessage ("ApplyDammage", damage, SendMessageOptions.DontRequireReceiver);
			}
		}
	}
}
