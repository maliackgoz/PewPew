using UnityEngine;

public class ShipController : MonoBehaviour
{
    public Quaternion startQuaternion;
    public Quaternion currentQuaternion;

    private Rigidbody2D rb;

    public float movementSpeed = 1f;
    public float rotationSpeed = 0.7f;

    private Vector3 movementVector;

    void Start()
    {
        startQuaternion = transform.rotation;
        movementVector = startQuaternion.eulerAngles;
        rb = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        currentQuaternion = transform.rotation;
        movementVector = currentQuaternion.eulerAngles; // returns a Vector3 from a Quaternion
        movementVector = new Vector2(0, movementVector.z);
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.forward * rotationSpeed);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.back * rotationSpeed);
        }

        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(transform.up * movementSpeed);
        }
    }
}
