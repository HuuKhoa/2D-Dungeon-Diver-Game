using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapScript : MonoBehaviour {

    // Initialize variables for the trap script
    public GameObject tripwire;
    public GameObject arrow;
    public GameObject arrow2;
    public string arrowDir;
    public string arrowDir2;
    private bool triggered = false;
    private Vector3 currentPos;
    private Vector3 currentPos2;
    private Vector3 shadowRealm;
    public float arrowSpeed = 0.05f;
    SoundManager soundManager;

    // Awake is called before the scene is loaded
    private void Awake() {
        soundManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<SoundManager>();
    }

    // Start is called before the first frame update
    void Start() {
        currentPos = arrow.transform.position;
        currentPos2 = arrow2.transform.position;
        shadowRealm.x = 10000f;
        shadowRealm.y = 10000f;
    }

    // Fixed update updates at a set rate
    void FixedUpdate() {
        if (triggered == true) {
            ShootArrow();
        }
    }

    void OnCollisionEnter(Collision coll) {
        // Arrow is fired if the player hits a trap
        if (coll.gameObject.CompareTag("Homie")) {
            soundManager.PlaySFX(soundManager.arrow);
            tripwire.transform.position = shadowRealm;
            triggered = true;
        }
    }

    void ShootArrow() {
        // Used to decide what direction the arrow is fired
        switch (arrowDir) {
            case "Left":
                currentPos.x -= arrowSpeed;
                arrow.transform.position = currentPos;
                break;
            case "Right":
                currentPos.x += arrowSpeed;
                arrow.transform.position = currentPos;
                break;
            case "Down":
                currentPos.y -= arrowSpeed;
                arrow.transform.position = currentPos;
                break;
            case "Up":
                currentPos.y += arrowSpeed;
                arrow.transform.position = currentPos;
                break;
        }

        // Used to decide what direction the 2nd arrow is fired
        switch (arrowDir2) {
            case "Left":
                currentPos2.x -= arrowSpeed;
                arrow2.transform.position = currentPos2;
                break;
            case "Right":
                currentPos2.x += arrowSpeed;
                arrow2.transform.position = currentPos2;
                break;
            case "Down":
                currentPos2.y -= arrowSpeed;
                arrow2.transform.position = currentPos2;
                break;
            case "Up":
                currentPos2.y += arrowSpeed;
                arrow2.transform.position = currentPos2;
                break;
        }
    }

}
