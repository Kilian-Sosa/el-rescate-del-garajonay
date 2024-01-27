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
        SCManager.instance.LoadScene("Menu");
    }
}
