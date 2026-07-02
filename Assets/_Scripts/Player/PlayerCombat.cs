
using System;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{

    [SerializeField]
    private GameObject bullet;
    [SerializeField]
    private Transform bulletPlaceHolder;
    [SerializeField]
    private float attackCooldown = 0.25f;
    private float lastShotTime;

    private CharacterController characterController;
    private PlayerControls playerControls;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        playerControls = new PlayerControls();
    }

    private void OnEnable()
    {
        playerControls.Player.Enable();
    }

    private void OnDisable()
    {
        playerControls.Player.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        if(AttackTriggered() && CanShoot()) { 
            Shoot();
        }
    }

    private void Shoot() 
    {

        Quaternion shotRotation = transform.rotation * Quaternion.Euler(0f, 90f, 0f);

        GameObject projectile = Instantiate(
            bullet,
            bulletPlaceHolder.position,
            shotRotation
        );

        Collider projectileCollider = projectile.GetComponent<Collider>();

        if (projectileCollider != null)
        {
            Physics.IgnoreCollision(projectileCollider, characterController);
        }

        lastShotTime = Time.time;

    }


    private bool CanShoot()
    {
        return Time.time - lastShotTime >= attackCooldown;
    }

    private bool AttackTriggered()
    {
        return playerControls.Player.Attack.triggered;
    }
}
