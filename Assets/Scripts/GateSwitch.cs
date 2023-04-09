using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateSwitch : MonoBehaviour {
    private BoxCollider2D boxCollider;
    private GateScript gate;
    private SpriteRenderer switchSprite;
    
    [SerializeField] private BoxCollider2D childCollider;

    private void Start() {
        boxCollider = GetComponent<BoxCollider2D>();
        gate = GetComponentInParent<GateScript>();
        switchSprite = GetComponentInChildren<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D collider) {
        boxCollider.enabled = false;
        switchSprite.color = Color.green;
        gate.OpenGate();
        childCollider.enabled = false;
    }
}
