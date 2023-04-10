using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class GateScript : MonoBehaviour {
    private const string GATE_OPEN_TRIGGER = "GateOpenTrigger";

    private CinemachineVirtualCamera cinemachineVCam;

    [SerializeField] private Collider2D gateCollider;
    [SerializeField] private Animator gateAnimator;

    private void Start() {
        cinemachineVCam = GetComponentInChildren<CinemachineVirtualCamera>();
    }

    public void OpenGate() {
        StartCoroutine(IOpenGame());
    }

    IEnumerator IOpenGame() {
        // Puase the game
        Time.timeScale = 0;

        // Active the virtual camera
        cinemachineVCam.enabled = true;
        yield return new WaitForSecondsRealtime(1.8f);

        // Play the gate opening animation
        gateAnimator.SetTrigger(GATE_OPEN_TRIGGER);
        yield return new WaitForSecondsRealtime(0.3f);

        // Disable the gate collider and disable the virtual camera
        gateCollider.enabled = false;
        cinemachineVCam.enabled = false;
        yield return new WaitForSecondsRealtime(1.8f);

        // Resume the game
        Time.timeScale = 1;
    }
}
