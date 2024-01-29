using UnityEngine;

public class CheckPointController : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player") && !gameObject.GetComponentInParent<Animator>().GetBool("open")) {
            GameManager.instance.lastCheckPointPosition = transform.parent.transform.position;
            AudioManager.instance.PlaySFX("CheckPointSFX");
            gameObject.GetComponentInParent<Animator>().SetBool("open", true);
        }
    }
}
