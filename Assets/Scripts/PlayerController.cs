using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    [SerializeField] float lineLength, xOffset, yOffset;
    private Animator animator;
    float score = 0;

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

        bool leftHitOnCorrectLayer = leftRaycast.collider != null && leftRaycast.collider.gameObject.layer == 3;
        bool rightHitOnCorrectLayer = rightRaycast.collider != null && rightRaycast.collider.gameObject.layer == 3;

        return !leftHitOnCorrectLayer && !rightHitOnCorrectLayer;
    }

    void OnTriggerEnter2D(Collider2D collision) {
        if (collision != null) {
            if (collision.CompareTag("Shard")) {
                Destroy(collision.gameObject);
                GameObject.Find("Score").GetComponent<TextMeshProUGUI>().text = $"{++score}/10";
            }
            if (collision.CompareTag("Crystal") && score >= 10) {
                AudioManager.instance.PlaySFX("Whistle3SFX");
                SCManager.instance.LoadScene("Victory");
            }
        }
    }
}
