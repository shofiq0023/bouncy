using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {
    public delegate void OnDamage(int damage);
    public static event OnDamage OnDamageEvent;

    private void OnCollisionEnter2D(Collision2D collider) {
        // Layer 3 is 'Player' layer
        if (collider.gameObject.layer == 3) {
            if (OnDamageEvent != null) {
                OnDamageEvent.Invoke(1);
            }
        }
    }
}
