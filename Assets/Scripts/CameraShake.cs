using UnityEngine;

public class CameraShake : MonoBehaviour {
    [SerializeField] GameObject player;
    [SerializeField] float shakeDuration = 0.4f;
    [SerializeField] float shakeMagnitude = 0.2f;
    [SerializeField] float fallThreshold = -20f;
    [SerializeField] float lerpSpeed = 4f; // Min velocity
    [SerializeField] Vector2 cameraOffset = new Vector2(0, 0);

    float remainingShake = 0;
    Vector3 originalPosition;
    float maxVelocity = 0;
    bool isShaking = false;

    void Start() {
        originalPosition = transform.position;
    }

    void Update() {
        if ((remainingShake == shakeDuration) && (!isShaking)) {
            isShaking = true;
            originalPosition = transform.position;
        }

        if (remainingShake > 0 && isShaking) {
            // Random.insideUnitSpehere returns a Vector3 with random pos between 0 and 1 in all 3 coords
            transform.position = originalPosition + Random.insideUnitSphere * shakeMagnitude;
            remainingShake -= Time.deltaTime;
        } 
        
        if (((remainingShake == 0) || (remainingShake < 0)) && isShaking) {
            isShaking = false;
            remainingShake = 0f;
            transform.position = originalPosition;
            // Use Lerp to center the camera slowly
            Vector3 targetPosition = new Vector3(player.transform.position.x + cameraOffset.x, player.transform.position.y + cameraOffset.y, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, targetPosition, lerpSpeed * Time.deltaTime);
        }

        float velocity = player.GetComponent<Rigidbody2D>().velocity.y;
        print(velocity);

        if (velocity < maxVelocity) {
            maxVelocity = velocity;
            if (maxVelocity < fallThreshold) {
                StartShake();
                maxVelocity = 0;
            }
        }
    }

    void StartShake() {
        remainingShake = shakeDuration;
    }
}