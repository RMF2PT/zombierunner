using UnityEngine;
using System.Collections;
 
public class MyThirdPersonController : MonoBehaviour {
 
		public AudioClip[] zombieSounds;

        private Animator animatorZ1;
        private AudioSource audioSource;
 
        float movingTurnSpeed = 360;
        float stationaryTurnSpeed = 180;
        float turnAmount;
        float forwardAmount;
 
        void Start () {
                animatorZ1 = GetComponent<Animator>();
                audioSource = GetComponent<AudioSource>();
        }

        void Update () {
        	PlaySounds ();
			if (Time.timeScale == 0) {
				audioSource.Pause();
			} else {
				audioSource.UnPause();
			}
        }
 
        public void Move(Vector3 move) {
                move = transform.InverseTransformDirection(move);
                turnAmount = Mathf.Atan2(move.x, move.z);
                forwardAmount = move.z;
				animatorZ1.SetFloat("Speed", move.z);
                ApplyExtraTurnRotation();
                turnAmount = Mathf.Atan2(move.x, move.z);
                UpdateAnimator(move);
        }
 
        void ApplyExtraTurnRotation() {
                float turnSpeed = Mathf.Lerp(stationaryTurnSpeed, movingTurnSpeed, forwardAmount);
                transform.Rotate(0, turnAmount * turnSpeed * Time.deltaTime, 0);
        }
 
        void UpdateAnimator(Vector3 move) {
                if (forwardAmount == 0) {
                	animatorZ1.SetBool ("isWalking", false);
                } else {
                	animatorZ1.SetBool ("isWalking", true);
                }
        }

		private void PlaySounds() {
            if (audioSource.isPlaying) {
                return;
            }

            // pick & play a random sound from the array,
            // excluding sound at index 0
            int n = Random.Range(1, zombieSounds.Length);
            audioSource.clip = zombieSounds[n];
            audioSource.PlayOneShot(audioSource.clip);
            // move picked sound to index 0 so it's not picked next time
            zombieSounds[n] = zombieSounds[0];
            zombieSounds[0] = audioSource.clip;
        }
}