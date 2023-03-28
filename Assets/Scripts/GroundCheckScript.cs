using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheckScript : MonoBehaviour {
    private Player player;

    private void Start() {
        player = GetComponentInParent<Player>();
    }

    private void OnTriggerEnter2D(Collider2D collider) {
        if (collider.gameObject.layer == 6) {
            player.ResetJump();
        }
    }
}
