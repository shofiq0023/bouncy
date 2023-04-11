using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPlatform : MonoBehaviour {
    [SerializeField] private float bounceStrength = 20f;

    private void OnCollisionEnter2D(Collision2D collider) {
        // Layer 3 is Player
        if (collider.gameObject.layer == 3) {
            collider.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * bounceStrength, ForceMode2D.Impulse);
        }
    }
}
