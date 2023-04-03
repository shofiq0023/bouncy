using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerLifeScript : MonoBehaviour {
    private TextMeshProUGUI lifeText;

    private void Start() {
        Player.OnDecreaseLife += TakeDamage;

        lifeText = GetComponent<TextMeshProUGUI>();
    }

    private void TakeDamage(int life) {
        if (life == 0) {
            lifeText.color = Color.red;
        }
        lifeText.text = life.ToString();
    }
}
