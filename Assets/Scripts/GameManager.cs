using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private GameObject pauseMenu;

    private bool gamePaused;

    private void Start() {
        gamePaused = false;
        Time.timeScale = 1;
        Player.OnGameOverEvent += HandleGameOverScreen;
        Player.OnGamePauseEvent += HandleGamePause;
    }

    private void OnDestroy() {
        Player.OnGameOverEvent -= HandleGameOverScreen;
        Player.OnGamePauseEvent -= HandleGamePause;
    }

    private void HandleGameOverScreen() {
        Time.timeScale = 0;
        gameOverScreen.SetActive(true);
    }

    public void RestartGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void HandleGamePause() {
        gamePaused = !gamePaused;
        Time.timeScale = gamePaused ? 0 : 1;
        pauseMenu.SetActive(gamePaused);
    }
}
