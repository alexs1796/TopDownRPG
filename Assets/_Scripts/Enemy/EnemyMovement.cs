using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 3f;

    private Transform player;

    private EnemyAttack enemyAttack;

    private void Awake()
    {
        enemyAttack = GetComponent<EnemyAttack>();
    }
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

        if (enemyAttack.IsPlayerInAttackRange())
        {
            return;
        }

        Vector3 direction = player.position - transform.position;
        direction.y = 0f;
        direction = direction.normalized;

        if (direction != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(direction) * Quaternion.Euler(0f, -90f, 0f);
        }

        transform.position += direction * moveSpeed * Time.deltaTime;
    }
}