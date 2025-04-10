using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PhysicsPlayerController : MonoBehaviour
{
    public float moveForce = 10f;
    public float jumpForce = 5f;
    public Transform respawnPoint;

    private Rigidbody rb;
    private bool isGrounded = true;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Jump
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }

        // Respawn
        if (Input.GetKeyDown(KeyCode.R))
        {
            rb.linearVelocity = Vector3.zero;
            transform.position = respawnPoint != null ? respawnPoint.position : Vector3.zero;
        }
    }

    void FixedUpdate()
    {
        // WASD Movement
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(h, 0, v);
        rb.AddForce(move * moveForce);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Reset jump on touching ground
        if (collision.contacts[0].normal.y > 0.5f)
        {
            isGrounded = true;
        }
    }
}
