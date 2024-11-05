using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {
    public Vector3 startLoc;
    private Vector3 destinationPos;
    public Vector3 location1;
    public Vector3 location2;
    public Vector3 location3;
    public Vector3 location4;
    public float moveSpeed;
    SoundManager soundManager;

    private void Awake() {
        soundManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<SoundManager>();
    }

    // Start is called before the first frame update
    void Start() {
        destinationPos = location1;
    }

    // Update is called once per frame
    void FixedUpdate() {
        // Constantly moves the character to each location
        this.transform.position = Vector3.MoveTowards(this.transform.position, destinationPos, moveSpeed * Time.deltaTime);
        if (this.transform.position == location1) {
            destinationPos = location2;
        } else if (this.transform.position == location2) {
            destinationPos = location3;
        } else if (this.transform.position == location3) {
            destinationPos = location4;
        } else if (this.transform.position == location4){
            destinationPos = location1;
        }
    }
}
