using UnityEngine;

public class StickController : MonoBehaviour {
    public float rotationTorque = 5f;

    void Start() {
        
    }

    void Update() {
        Rotate();
    }

    void Rotate() {
        float rotationInput = -Input.GetAxis("Horizontal");

        float torqueForce = rotationInput * rotationTorque;

        GetComponent<Rigidbody2D>().AddTorque(torqueForce);
    }
}
