using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

    private void Update() {
        if (SceneManager.GetActiveScene().name == "Menu") {
            if (Input.GetButtonDown("Submit")) Play();
            if (Input.GetButtonDown("Fire4")) Credits();
        }
        if (SceneManager.GetActiveScene().name == "Victory" && Input.GetButtonDown("Cancel")) OpenMenu();
        if (SceneManager.GetActiveScene().name == "GameScene") {
            if (Input.GetButtonDown("Cancel")) OpenMenu();
        }
    }

    public void Play() {
        SCManager.instance.LoadScene("GameScene");
    }

    public void Credits() {
        SCManager.instance.LoadScene("Victory");
    }

    public void Quit() {
        Application.Quit();
    }

    public void OpenMenu() {
        if (GameManager.instance.isPaused) GameManager.instance.TogglePause();
        GameManager.instance.lastCheckPointPosition = default(Vector2);
        SCManager.instance.LoadScene("Menu");
    }
}
