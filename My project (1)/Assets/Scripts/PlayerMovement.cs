using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed =  6f;

    private Rigidbody rb;
    private Vector3 movementInput;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Só permite movimento durante Playing
        if (GameManager.Instance.machine.CurrentState != GameManager.Instance.playingState)
        {
            movementInput = Vector3.zero;
            return;
        }

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        movementInput = new Vector3(horizontal, 0f, vertical).normalized;
    }

    void FixedUpdate()
    {
        Vector3 velocity = rb.linearVelocity;

        velocity.x = movementInput.x * moveSpeed;
        velocity.z = movementInput.z * moveSpeed;

        rb.linearVelocity = velocity;
    }
}