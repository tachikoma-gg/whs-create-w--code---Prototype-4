using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;

    [SerializeField] private float moveForce = 10f;
    [SerializeField] private float jumpForce = 100f;
    [SerializeField] private Transform cameraTransform;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Physics.gravity *= 9.8f;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && transform.position.y < 0.4f)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    void FixedUpdate()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");

        Vector3 forceVector = new (inputX, 0, inputY);

        rb.AddForce(cameraTransform.rotation * forceVector * moveForce);
    }
}
