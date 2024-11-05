using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterBehavior : MonoBehaviour {
    // Initialize variables for the character
    private Vector3 destinationPos;
    public float moveSpeed = 5f;
    public Vector3 resetPos;
    public int lootCounter;

    // Calls the sound manager script to use in this script
    SoundManager soundManager;

    // Awake is called before the scene is loaded
    private void Awake() {
        // Load in the sound manager game object
        soundManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<SoundManager>();
    }

    // Start is called before the first frame update
    void Start() {
        // soundManager.PlaySFX(soundManager.dungeonAmbiance); was too loud so I cut it from the game
        // Set initial destiniation position
        destinationPos = this.transform.position;
    }

    // Update is called once per frame
    void Update() {
        // Get the position of the mouse when right click button is pressed
        if (Input.GetMouseButton(1)) {
            destinationPos = Input.mousePosition;
            destinationPos.z = -Camera.main.transform.position.z;
            destinationPos = Camera.main.ScreenToWorldPoint(destinationPos); 
        }

    }

    void FixedUpdate() {
        // Move the Character towards where right click was pressed
        if (Vector3.Distance(this.transform.position, destinationPos) > 0.1f) {
            this.transform.position = Vector3.MoveTowards(this.transform.position, destinationPos, moveSpeed * Time.deltaTime);
        }
    }

    void OnCollisionEnter(Collision coll) {
        // Sets the index for the scene the character is on
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        
        // If the character collides with the walls or the doors reset their position and take damage
        if (coll.gameObject.CompareTag("Wall") || coll.gameObject.CompareTag("Door")) {
            TakesDamage();
        }

        // When the character collides with a loot object destroy the loot object 
        if (coll.gameObject.CompareTag("Loot")) {
            Destroy(coll.gameObject);
            soundManager.PlaySFX(soundManager.gemPickUp);
            // Decrement loot counter once all the loot is finished open the door
            lootCounter--;
            if (lootCounter == 0) {
                // Specific case where the player is on the last level
                if (SceneManager.GetActiveScene().buildIndex == 6) {
                    SceneManager.LoadScene(++sceneIndex);
                }
                // Find all the objects with the tag door and get rid of them
                soundManager.PlaySFX(soundManager.doorOpen);
                GameObject[] doorArray = GameObject.FindGameObjectsWithTag("Door");
                foreach (GameObject tempGO in doorArray) {
                    Destroy(tempGO);
                }
            }
        } 
        
        // When character touches the finish zone for each level move on to the next
        if (coll.gameObject.CompareTag("Finish")) {
            SceneManager.LoadScene(++sceneIndex);
        }

        // If the character touches anything that does damage calls the takes damage method
        if (coll.gameObject.CompareTag("DamageSource")) {
            TakesDamage();
        }


    }

    // Method to damage the character
    void TakesDamage() {
        soundManager.PlaySFX(soundManager.damage);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        LivesScript.instance.Damage();
    }
    
}
