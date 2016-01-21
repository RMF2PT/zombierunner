using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayersLife : MonoBehaviour {

	public Sprite[] heartSprites;
	public RawImage[] heartImages;

	private Player player;
	private float initialHealth;
	private float healthDif = 0f;
	private float healthLastFrame = 0f;

	void Start () {
		player = FindObjectOfType<Player>();
		initialHealth = player.initialHealth;
	}

	void Update () {
		healthDif = healthLastFrame - player.health;

		if (healthDif != 0) {
			healthLastFrame = player.health;
			UpdateHealthImage ();
		}
	}

	void UpdateHealthImage () {
		int i = player.lives - 1; // array starts at 0

		if (player.health >= (initialHealth * 0.95f)) {
			heartImages [i].texture = heartSprites [0].texture;
		} else if (player.health > initialHealth * 0.75f) {
			heartImages [i].texture = heartSprites [1].texture;
		} else if (player.health > initialHealth * 0.50f) {
			heartImages [i].texture = heartSprites [2].texture;
		} else if (player.health > initialHealth * 0.25f) {
			heartImages [i].texture = heartSprites [3].texture;
		} else if (player.health <= 0f) {
			heartImages [i].texture = heartSprites [4].texture;
		}
	}
}
