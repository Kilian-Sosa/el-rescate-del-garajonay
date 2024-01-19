using UnityEngine;

public class PlayerController : MonoBehaviour {
    [SerializeField] float lineLength, offset;
    private Animator animator;

    void Start() {
        animator = GetComponent<Animator>();
    }

    void Update() {
        animator.SetBool("jump", IsInAir());
    }

    bool IsInAir() {
        Vector2 origin = new Vector2(transform.position.x, transform.position.y - offset);
        Vector2 target = origin - new Vector2(0, lineLength);
        Debug.DrawLine(origin, target, Color.black);

        RaycastHit2D raycast = Physics2D.Raycast(origin, Vector2.down, lineLength, 5);

        return raycast.collider == null;
    }
}
