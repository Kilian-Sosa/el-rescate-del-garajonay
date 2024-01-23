using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public float patrolSpeed = 1f;
    public Transform pointA;
    public Transform pointB;

    private bool movingTowardsA = true;
    private float epsilon = 0.5f; // Tolerancia para la comparación de posiciones

    void Update()
    {
        if (movingTowardsA)
        {
            MoveTowardsPoint(pointA);
        }
        else
        {
            MoveTowardsPoint(pointB);
        }
    }

    void MoveTowardsPoint(Transform targetPoint)
    {
        Vector2 direction = (targetPoint.position - transform.position).normalized;
        GetComponent<Rigidbody2D>().velocity = new Vector2(patrolSpeed * direction.x, patrolSpeed * direction.y);

        if (direction.x > 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else if (direction.x < 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }

        // Utiliza la tolerancia para la comparación de posiciones
        if (Mathf.Abs(transform.position.x - targetPoint.position.x) < epsilon &&
            Mathf.Abs(transform.position.y - targetPoint.position.y) < epsilon)
        {
            movingTowardsA = !movingTowardsA;
        }
    }
}
