using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private float attackRange = 2f;
    [SerializeField] private int damage = 20;
    [SerializeField] private float attackCooldown = 1f;

    private float lastAttackTime;
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
        if (IsPlayerInRange() && CanAttack())
        {
            Attack();
        }
    }

    private bool IsPlayerInRange()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        return distanceToPlayer <= attackRange;
    }

    private bool CanAttack()
    {
        return Time.time >= lastAttackTime + attackCooldown;
    }

    private void Attack()
    {
        IDamageable damageable = player.GetComponent<IDamageable>();

        if (damageable == null)
        {
            return;
        }

        damageable.TakeDamage(damage);
        Debug.Log($"Enemy attacks player for {damage} damage!");

        lastAttackTime = Time.time;
    }
}