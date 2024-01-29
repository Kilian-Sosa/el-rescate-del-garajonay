using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public Vector2 lastCheckPointPosition;
    public static GameManager instance;
    public bool isPaused = false;

    void Awake() {
        if (instance == null) instance = this;
        else { Destroy(gameObject); return; }
        DontDestroyOnLoad(gameObject);
        lastCheckPointPosition = default(Vector2);
        AudioManager.instance.PlayMusic("mainTheme");
    }

    void Update() {
        if (SceneManager.GetActiveScene().name != "GameScene") return;
        if (Input.GetButtonDown("Submit") || Input.GetKeyDown(KeyCode.Escape)) TogglePause();
        if (Input.GetButtonDown("Fire2") || Input.GetKeyDown(KeyCode.R)) Respawn();
    }

    void Respawn() {
        if (lastCheckPointPosition != default(Vector2)) {
            GameObject playerObj = GameObject.Find("Player");
            Transform playerTransform = playerObj.transform;

            Rigidbody2D playerRb = playerTransform.GetChild(0).GetComponent<Rigidbody2D>();
            Transform playerBody = playerTransform.GetChild(0);
            Transform playerStick = playerTransform.GetChild(1);

            playerRb.velocity = Vector2.zero;
            playerBody.position = playerTransform.position;
            playerStick.position = playerTransform.position;
            playerTransform.position = lastCheckPointPosition;
        }
    }

    public void TogglePause() {
        isPaused = !isPaused;
        Time.timeScale = isPaused ? 0f : 1f;
        GameObject.Find("CanvasCam").transform.Find("Pause").gameObject.SetActive(isPaused);
    }
}
