using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 3f;

    private Transform player;

    private void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    private void Update()
    {
        if (player == null)
        {
            return;
        }
        Vector3 direction = player.position - transform.position;
        direction.y = 0f;
        direction = direction.normalized;

        transform.position += direction * moveSpeed * Time.deltaTime;
    }
}