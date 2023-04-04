using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerLifeScript : MonoBehaviour {
    private TextMeshProUGUI lifeText;

    private void Start() {
        Player.OnLifeChange += ShowLife;

        lifeText = GetComponent<TextMeshProUGUI>();
    }

    private void OnDestroy() {
        Player.OnLifeChange -= ShowLife;
    }

    private void ShowLife(int life) {
        if (life == 0) {
            lifeText.color = Color.red;
        } else {
            lifeText.color = Color.white;
        }
        lifeText.text = life.ToString();

        
    }
}
