using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float bulletSpeed = 1000f;
    public float maxLifeTime = 3f;

    private Rigidbody2D rb;

    private void Awake() // At first, it was a Start method. Than I changed it to Awake and it started to work.(?)
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Project(Vector2 direction)
    {
        rb.AddForce(direction * bulletSpeed);
        Destroy(this.gameObject, maxLifeTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(this.gameObject);
    }
}
