using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour {
    // Initialize Audio sources to use related to playing sound for the game
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    // Initialize audio clips for each sound used throughout the game
    public AudioClip arrow;
    public AudioClip doorOpen;
    public AudioClip gemPickUp;
    public AudioClip damage;
    public AudioClip gameOverMusic;
    public AudioClip playerWalking;
    public AudioClip enemyWalking;
    public AudioClip boulderRoll;
    public AudioClip wallSlide;
    public AudioClip dungeonAmbiance;
    public AudioClip titleScreenMusic;
    public AudioClip endScreenMusic;


    private void Start() {
        // Switch cases that plays music for 
        switch (SceneManager.GetActiveScene().buildIndex) {
            case 0:
                // Title screen music
                musicSource.clip = titleScreenMusic;
                musicSource.Play();
                break;
            case 7:
                // End screen music
                musicSource.clip = endScreenMusic;
                musicSource.Play();
                break;
            case 8:
                // Game Over music
                musicSource.clip = gameOverMusic;
                musicSource.Play();
                break;
        }
    }

    // Method to play sounds from other scripts
    public void PlaySFX(AudioClip clip) {
        SFXSource.PlayOneShot(clip);
    }
}
