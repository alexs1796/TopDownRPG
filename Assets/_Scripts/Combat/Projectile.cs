using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private float lifetime = 5f;
    [SerializeField] private int damage = 35;

    private void Start()
    {
        Destroy(gameObject, lifetime);
    }

    private void Update()
    {
        //Debug.Log(transform.forward);
        //Debug.DrawRay(transform.position, transform.forward * 2f, Color.blue);
        transform.position += transform.forward * speed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        EnemyHealth enemyHealth = other.GetComponent<EnemyHealth>();

        if (enemyHealth == null)
        {
            return;
        }

        enemyHealth.TakeDamage(damage);
        Destroy(gameObject);
    }
}