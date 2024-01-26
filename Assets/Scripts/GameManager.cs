using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public Vector2 lastCheckPointPosition;
    public static GameManager instance;

    void Start() {
        if (instance == null) instance = this;
        lastCheckPointPosition = default(Vector2);
        AudioManager.instance.PlayMusic("mainTheme");
    }

    void Update() {
        if (SceneManager.GetActiveScene().name != "GameScene") return;
        if ((Input.GetKey(KeyCode.R) || Input.GetButton("Fire2"))) Respawn();
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
}
