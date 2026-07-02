using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerLook : MonoBehaviour
{
    [SerializeField] private LayerMask groundLayer;

    private Camera mainCamera;

    private void Awake()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        Ray ray = mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue());

        if (Physics.Raycast(ray, out RaycastHit hitInfo, 100f, groundLayer))
        {
            Debug.DrawLine(transform.position, hitInfo.point, Color.red);
            Debug.DrawRay(hitInfo.point, Vector3.up * 2f, Color.green);

            Vector3 lookDirection = hitInfo.point - transform.position;
            lookDirection.y = 0f;
            transform.rotation = Quaternion.LookRotation(lookDirection) * Quaternion.Euler(0f, -90f, 0f);
        }
    }
}