using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackground : MonoBehaviour {
    [SerializeField] private Vector2 parallaxMultiplier;

    private Transform cameraTransform;
    private Vector3 lastCameraPosition;
    private float textureUnitSizeX;

    private void Start() {
        cameraTransform = Camera.main.transform;
        lastCameraPosition = cameraTransform.position;

        Sprite sprite = GetComponent<SpriteRenderer>().sprite;
        Texture2D spriteTexture = sprite.texture;
        textureUnitSizeX = spriteTexture.width / sprite.pixelsPerUnit;
    }

    private void LateUpdate() {
        Vector3 deltaCameraMovement = cameraTransform.position - lastCameraPosition;
        transform.position -= new Vector3(deltaCameraMovement.x * parallaxMultiplier.x, deltaCameraMovement.y * parallaxMultiplier.y);
        lastCameraPosition = cameraTransform.position;

        if (Mathf.Abs(cameraTransform.position.x - transform.position.x) >= textureUnitSizeX) {
            float offsetX = (cameraTransform.position.x - transform.position.x) % textureUnitSizeX;
            transform.position = new Vector3(cameraTransform.position.x + offsetX, transform.position.y);
        }
    }
}
