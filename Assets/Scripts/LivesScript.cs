using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LivesScript : MonoBehaviour {

    // Initialize variables for the lives script
    public GameObject heartPrefab;
    public static LivesScript instance;
    public int lives;
    public List<GameObject> heartList;

    // Awake is called before the scene is loaded
    private void Awake() {
        // Makes an instance that is saved throughout each scene
        if(instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start() {
        // Set starting lives
        lives = 3;
        for (int i = 0; i < lives; i++) {
            GameObject heart = Instantiate(heartPrefab, transform);  // Instantiate a new heart icon
            heart.transform.position += new Vector3(i * 1.0f, 0, 0);  // Offset each heart icon
            heartList.Add(heart);  // Add to the list
        }
    }

    // Method to damage the player when the player takes damage
    public void Damage() {
        lives -= 1;
        GameObject heartToRemove = heartList[heartList.Count - 1];
        heartList.RemoveAt(heartList.Count - 1);
        Destroy(heartToRemove);
        if (lives == 0) {
            GameOver();
        }
    }

    // Method to signify that the player has died / run out of lives
    void GameOver() {
        SceneManager.LoadScene(8);
        lives = 3;
        // Clear and reset hearts
        foreach (GameObject heart in heartList) {
            Destroy(heart);
        }
        heartList.Clear();

        // Reinitialize hearts
        for (int i = 0; i < lives; i++) {
            GameObject heart = Instantiate(heartPrefab, transform);
            heart.transform.position += new Vector3(i * 1.0f, 0, 0);
            heartList.Add(heart);
        }
    }
}
