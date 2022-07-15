using UnityEngine;

public class ShipController : MonoBehaviour
{
    //public Quaternion startQuaternion;
    public Quaternion currentQuaternion;

    private Rigidbody2D rb;

    public float movementSpeed = 380f;
    public float rotationSpeed = 120f;

    public BulletController bulletPrefab;

    //private Vector3 movementVector;

    void Start() // Awake or Start??
    {
        /*startQuaternion = transform.rotation;
        movementVector = startQuaternion.eulerAngles;*/
        rb = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        currentQuaternion = transform.rotation;
        // movementVector = currentQuaternion.eulerAngles; // returns a Vector3 from a Quaternion
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.back * rotationSpeed * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    private void FixedUpdate() // dealing with the physics and rigidbody
    {
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(transform.up * movementSpeed * Time.deltaTime);
        }
    }

    public void Shoot()
    {
        BulletController bullet = Instantiate(this.bulletPrefab, this.transform.position, this.transform.rotation);
        bullet.Project(transform.up);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Astreoid"))
        {
            Debug.Log("Game Over!");
            Destroy(gameObject);
        }
    }
}
