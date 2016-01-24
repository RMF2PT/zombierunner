using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UpDateAmmo : MonoBehaviour {

	private Player player;
	private Text ammoNumber;

	void Start () {
		player = FindObjectOfType<Player>();
		ammoNumber = GetComponent<Text>();
	}

	void Update () {
		ammoNumber.text = player.ammo.ToString();
	}
}
