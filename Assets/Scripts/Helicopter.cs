using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityStandardAssets.ImageEffects;

public class Helicopter : MonoBehaviour {

	private Rigidbody rigiBody;
	private Scene activeScene;
	private bool inInitialMenu = false;
	private Vector3 initialPosition;
	private AudioSource audioSource;
	private VignetteAndChromaticAberration vignette;
	private Vector3 landingAreaPosition;
	private float speed = 1.0f;
    private float startTime;
    private float journeyLength;
	private bool hasStartedMovingToArea = false;
	private bool hasStartedDescent = false;
	private bool hasPlayerOnHelicopter = false;

	void Start () {
		rigiBody = GetComponent<Rigidbody>();
		audioSource = GetComponent<AudioSource>();
		activeScene = SceneManager.GetActiveScene();
		initialPosition = transform.position;
		vignette = GetComponentInChildren<VignetteAndChromaticAberration>();
	}

	void Update () {
		if (Time.timeScale == 0f) {
			audioSource.Pause();
		} else {
			audioSource.UnPause();
		}

		if (activeScene.buildIndex == 0) inInitialMenu = true;

		if (inInitialMenu) {
			if (transform.position.z > 1000f) {
				float randXPosition = Random.Range(0f, 250f);
				transform.position = new Vector3(randXPosition, initialPosition.y, initialPosition.z - 8000f);
			}
			rigiBody.velocity = new Vector3(0, 0, -50f);
			if (transform.position.z < -1000f) {
				transform.position = initialPosition;
			}
		}

		if (transform.position.z < 1000f && !inInitialMenu && !hasPlayerOnHelicopter) {
			if (!hasStartedMovingToArea) {
				rigiBody.velocity = new Vector3(0, 0, 0);
				hasStartedMovingToArea = true;
				startTime = Time.time;
       			journeyLength = Vector3.Distance(transform.position, landingAreaPosition);
       		}
       		MoveToLandingArea();
        }
	}

	void MoveToLandingArea () {
		float distCovered = (Time.time - startTime) * speed;
        float fracJourney = distCovered / journeyLength;
        transform.position = Vector3.Lerp(transform.position, landingAreaPosition, fracJourney);
		if (transform.position.z - 1f > landingAreaPosition.z) {
        	transform.position = new Vector3(transform.position.x, 150f, transform.position.z);
        } else if (!hasStartedDescent) {
        	hasStartedDescent = true;
			startTime = Time.time;
       		journeyLength = Vector3.Distance(transform.position, landingAreaPosition);
        }
	}

	IEnumerator FadeOut () {
		for (float intensity = 0f; intensity <= 1f; intensity += 0.005f) {
			vignette.intensity = intensity;
			vignette.blur = intensity;
			yield return null;
		}
	}

	void OnDispatchHelicopter (Vector3 position) {
		Debug.Log ("Helicopter called");
		transform.position = new Vector3(landingAreaPosition.x, 150f, transform.position.z);
		rigiBody.velocity = new Vector3(0, 0, -50f);
		landingAreaPosition = position;
	}

	void OnFlyOver () {
		hasPlayerOnHelicopter = true;
		rigiBody.velocity = new Vector3(0, 5f, 0);
		StartCoroutine("FadeOut");
		Invoke("GameOver", 10f);
	}

	void GameOver () {
		SceneManager.LoadScene(3);
	}
}
