using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Target : MonoBehaviour {

	private Camera myCamera;
	private RectTransform rectTransform;
	private Vector2 initialSize;
	private Image image;

	void Start () {
		myCamera = GetComponentInParent<Camera>();
		rectTransform = GetComponent<RectTransform>();
		image = GetComponent<Image>();
		initialSize = rectTransform.sizeDelta;
	}

	void Update () {
		if (myCamera.fieldOfView < 60f) {
			rectTransform.sizeDelta = new Vector2(150f, 150f);
		} else {
			rectTransform.sizeDelta = initialSize;
		}

		Color color = image.color;
		if (Time.timeScale == 0f) {
			color.a = 0f;
			image.color = color;
		} else {
			color.a = 255f;
			image.color = color;
		}
	}
}
