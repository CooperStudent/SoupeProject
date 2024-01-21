using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public float speed = 2.0f;
    private Transform currentTarget;

    private void Start()
    {
        currentTarget = pointA;
    }

    private void Update()
    {
        MoveTowardsTarget();

        float distanceToPoint = Vector3.Distance(transform.position, currentTarget.position);
        if (distanceToPoint < 0.1f) 
        {
            ToggleTarget();
        }
    }

    private void MoveTowardsTarget()
    {
        transform.position = Vector3.MoveTowards(transform.position, currentTarget.position, speed * Time.deltaTime);
    }

    private void ToggleTarget()
    {
        currentTarget = currentTarget == pointA ? pointB : pointA;
    }
}
