using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateScript : MonoBehaviour {
    public void OpenGate() {
        Debug.Log("Gate open!");
        // Create gate open animation
        // Active the camera
        // Coroutine for 1.5 second (Duration of opening gate animation)
            // Inside coroutine play the gate open animation
            // Disable the collider
        // Deactive the camera
    }
}
