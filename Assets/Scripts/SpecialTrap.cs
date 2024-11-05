using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialTrap : MonoBehaviour {

    // Initialize variables for the special trap
    public GameObject tripwire;
    public GameObject boulder;
    public GameObject arrow;
    private Vector3 currentPos;
    private Vector3 currentPos2;
    private Vector3 shadowRealm;
    public float boulderSpeed = 0.05f;
    private bool triggered = false;
    private float timer;
    SoundManager soundManager;

    // Awake is called before the scene is loaded in
    private void Awake() {
        soundManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<SoundManager>();
    }


    // Start is called before the first frame update
    void Start() {
        // Set initial values for the boulder
        currentPos = boulder.transform.position;
        currentPos2 = arrow.transform.position;
        shadowRealm.x = 10000f;
        shadowRealm.y = 10000f;
        timer = 0f;
    }

    // Fixed update updates at a set rate
    void FixedUpdate() {
        // When the trap is triggered, start a timer and move the boulder 
        if (triggered == true) {
            timer += Time.deltaTime;
            currentPos.x += boulderSpeed;
            if (timer >= 5.3f) {
                triggered = false;
            }
            currentPos2.x -= boulderSpeed * 0.3f;
            boulder.transform.position = currentPos;
            arrow.transform.position = currentPos2;
        }
    }

    // On collision set the trigger to true so that the boulder can be moved
    void OnCollisionEnter(Collision coll) {
        if (coll.gameObject.CompareTag("Homie")) {
            soundManager.PlaySFX(soundManager.boulderRoll);
            tripwire.transform.position = shadowRealm;
            triggered = true;
        }
    }
}
