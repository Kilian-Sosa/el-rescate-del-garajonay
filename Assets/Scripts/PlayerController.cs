using UnityEngine;

public class PlayerController : MonoBehaviour {
    [SerializeField] float lineLength, xOffset, yOffset;
    private Animator animator;

    void Start() {
        animator = GetComponent<Animator>();
    }

    void Update() {
        animator.SetBool("jump", IsInAir());
    }

    bool IsInAir() {
        Vector2 leftOrigin = new Vector2(transform.position.x - xOffset, transform.position.y - yOffset);
        Vector2 rightOrigin = new Vector2(transform.position.x + xOffset, transform.position.y - yOffset);

        Vector2 leftTarget = leftOrigin - new Vector2(0, lineLength);
        Vector2 rightTarget = rightOrigin - new Vector2(0, lineLength);

        Debug.DrawLine(leftOrigin, leftTarget, Color.black);
        Debug.DrawLine(rightOrigin, rightTarget, Color.black);

        RaycastHit2D leftRaycast = Physics2D.Raycast(leftOrigin, Vector2.down, lineLength);
        RaycastHit2D rightRaycast = Physics2D.Raycast(rightOrigin, Vector2.down, lineLength);

        //RaycastHit2D leftRaycast = Physics2D.Raycast(leftOrigin, Vector2.down, lineLength, 0);
        //RaycastHit2D rightRaycast = Physics2D.Raycast(rightOrigin, Vector2.down, lineLength, 0);

        //print(leftRaycast.collider);
        //print(rightRaycast.collider);

        //return leftRaycast.collider == null && rightRaycast.collider == null;

        // Check if the collider is on the desired layer
        bool leftHitOnCorrectLayer = leftRaycast.collider != null && leftRaycast.collider.gameObject.layer == 3;
        bool rightHitOnCorrectLayer = rightRaycast.collider != null && rightRaycast.collider.gameObject.layer == 3;

        return !leftHitOnCorrectLayer && !rightHitOnCorrectLayer;
    }
}
