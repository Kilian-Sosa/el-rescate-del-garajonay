using UnityEngine;

public class Menu : MonoBehaviour {

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
