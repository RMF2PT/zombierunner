using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Target : MonoBehaviour {

	public Camera myCamera;
	private RectTransform rectTransform;
	private Vector2 initialSize;
	private Image image;

	void Start () {
		
		rectTransform = GetComponent<RectTransform>();
		image = GetComponent<Image>();
		initialSize = rectTransform.sizeDelta;
	}

	void Update () {
		if (myCamera.fieldOfView < 60f) {
			rectTransform.sizeDelta = new Vector2(150f, 150f);
		} else if (myCamera.fieldOfView == 60f) {
			rectTransform.sizeDelta = initialSize;
		}

		if (Time.timeScale == 0f) {
			image.enabled = false;
		} else if (!image.enabled) {
			image.enabled = true;
		}
	}
}
