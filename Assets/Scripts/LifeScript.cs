using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeScript : MonoBehaviour {
    public delegate void OnLifeConsume();
    public static event OnLifeConsume OnLifeConsumeEvent;

    private void OnTriggerEnter2D(Collider2D collider) {
        // Layer 3 is Player
        if (collider.gameObject.layer == 3) {
            OnLifeConsumeEvent?.Invoke();
            gameObject.SetActive(false);
        }
    }
}
