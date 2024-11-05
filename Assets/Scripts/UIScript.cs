using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIScript : MonoBehaviour {

    // For the UI Script
    public static UIScript UI;
    public RectTransform rect;
    private float imgWidth;

    // Start is called before the first frame update
    void Start() {
        rect.sizeDelta = new Vector2(imgWidth * LivesScript.instance.lives, rect.sizeDelta.y);
    }

    // Resize the UI to show that damage has been taken
    public void DamageUI() {
        rect.sizeDelta = new Vector2(imgWidth * LivesScript.instance.lives, rect.sizeDelta.y);
    }

    // Update is called once per frame
    void Update() {
        
    }
}
