using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

    private void Update() {
        if (SceneManager.GetActiveScene().name == "Menu") {
            if (Input.GetButtonDown("Jump")) Play();
            if (Input.GetButtonDown("Fire3")) Credits();
        }
        if (SceneManager.GetActiveScene().name == "Victory" && Input.GetButtonDown("Cancel")) OpenMenu();
        if (SceneManager.GetActiveScene().name == "GameScene") {
            if (Input.GetButtonDown("Submit")) Unpause();
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
        SCManager.instance.LoadScene("Menu");
    }
    public void Unpause() {
        Time.timeScale = 1f;
        GameObject.Find("CanvasCam").transform.Find("Pause").gameObject.SetActive(false);
    }
}
