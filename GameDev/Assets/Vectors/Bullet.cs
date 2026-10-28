using UnityEngine;

public class Bullet : MonoBehaviour
{
    //Components
    private Rigidbody rb;
    //Movement
    public float speed = 16;
    private Vector3 velocity;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Get components
        rb = GetComponent<Rigidbody>();

        //Destroy the bullet after 5 seconds
        //This will stop our game from creating too many objects and lagging out
        Destroy(gameObject, 5);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Move the bullet
        rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
    }

    public void SetVelocity(Vector3 direction)
    {
        velocity = direction * speed;
    }
}
