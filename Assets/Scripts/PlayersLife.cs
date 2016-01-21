using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayersLife : MonoBehaviour {

	public Sprite[] heartImages;

	private RawImage image;
	private Player player;
	private float initialHealth;

	void Start () {
		image = GetComponent<RawImage>();
		player = FindObjectOfType<Player>();
		initialHealth = player.initialHealth;
	}

	void Update () {
		if (player.health == initialHealth) {
			image.texture = heartImages[0].texture;
		} else if (player.health > initialHealth * 0.75f) {
			image.texture = heartImages[1].texture;
		} else if (player.health > initialHealth * 0.50f) {
			image.texture = heartImages[2].texture;
		} else if (player.health > initialHealth * 0.25f) {
			image.texture = heartImages[3].texture;
		} else if (player.health <= 0f) {
			image.texture = heartImages[4].texture;
		}
	}
}
