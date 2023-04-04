using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    [SerializeField] private GameObject gameOverScreen;

    private void Start() {
        Time.timeScale = 1;
        Player.OnGameOverEvent += HandleGameOverScreen;
    }

    private void OnDestroy() {
        Player.OnGameOverEvent -= HandleGameOverScreen;
    }

    private void HandleGameOverScreen() {
        Time.timeScale = 0;
        gameOverScreen.SetActive(true);
    }

    public void RestartGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
