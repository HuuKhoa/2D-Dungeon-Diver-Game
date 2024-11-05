using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseIndicator : MonoBehaviour
{
    private Vector3 destinationPos;
    private Vector3 shadowRealm;
    private float timer = 0f;

    // Start is called before the first frame update
    void Start() {
        shadowRealm.x = 10000f;
        shadowRealm.y = 10000f;
    }

    // Update is called once per frame
    void Update() {
        // Puts an indicator at the location that the mouse is when right click is pressed
        if (Input.GetMouseButton(1)) {
            destinationPos = Input.mousePosition;
            destinationPos.z = -Camera.main.transform.position.z;
            destinationPos = Camera.main.ScreenToWorldPoint(destinationPos);
            this.transform.position = destinationPos;
            timer = 0f;
        }

        // Makes the indicator go away after a set time
        timer += Time.deltaTime;
        if (timer >= 0.5f) {
            this.transform.position = shadowRealm;
        }
    }
}
