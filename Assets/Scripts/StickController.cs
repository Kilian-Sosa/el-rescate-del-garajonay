using UnityEngine;

public class StickController : MonoBehaviour {
    [SerializeField] float rotationTorque = 4000f;

    void Start() {
        
    }

    //void Update() {
    //    Rotate();
    //}

    private void FixedUpdate() {
        Rotate();
    }

    void Rotate() {
        GetComponent<Rigidbody2D>().freezeRotation = false;
        float rotationInput = -Input.GetAxis("Horizontal");

        float torqueForce = rotationInput * rotationTorque;

        GetComponent<Rigidbody2D>().AddTorque(torqueForce);
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision != null) {
            GetComponent<Rigidbody2D>().freezeRotation = true;
        }
    }
}
