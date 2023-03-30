using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour {
    private Player player;

    private void Start() {
        player = GetComponentInParent<Player>();    
    }

    private void OnCollisionEnter2D(Collision2D collider) {
        // Layer 8 is the EnemyLayer
        if (collider.gameObject.layer == 8) {
            player.TakeDamage(1);
        }
    }
}
