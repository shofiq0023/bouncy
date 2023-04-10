using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateSwitch : MonoBehaviour {
    private const string SWITCH_ON_TRIGGER = "SwitchOn";

    private BoxCollider2D boxCollider;
    private GateScript gate;
    private SpriteRenderer switchSprite;
    private Animator switchAnimator;
    
    [SerializeField] private BoxCollider2D childCollider;

    private void Start() {
        boxCollider = GetComponent<BoxCollider2D>();
        gate = GetComponentInParent<GateScript>();
        switchSprite = GetComponentInChildren<SpriteRenderer>();
        switchAnimator = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collider) {
        switchAnimator.SetTrigger(SWITCH_ON_TRIGGER);
        boxCollider.enabled = false;
        switchSprite.color = Color.green;
        gate.OpenGate();
        childCollider.enabled = false;
    }
}
