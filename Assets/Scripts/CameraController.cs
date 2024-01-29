using UnityEngine;

public class CameraController : MonoBehaviour {
    [SerializeField] GameObject player;
    [SerializeField] float xMin, xMax, yMin, yMax;

    void Update() {
        transform.position = new Vector3(Mathf.Clamp(player.transform.position.x, xMin, xMax),
            Mathf.Clamp(player.transform.position.y, yMin, yMax), transform.position.z);
    }
}