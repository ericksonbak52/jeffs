using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartController : MonoBehaviour
{
    public GameObject Player;
    public GameObject CartRef;
    public GameObject CartDetector;
    public float value;

    public Rigidbody rb;

    public float speed;
    public float maxSpeed = 10;

    public float playerRotation;

    public void Update()
    {
        if (CartDetector.GetComponent<ShoppingCartDetector>().cartActive)
        {
            Player.transform.position = new Vector3(CartRef.transform.position.x, 1.4f, CartRef.transform.position.z);

            if (Input.GetKey(KeyCode.W))
            {
                rb.AddForce(transform.right * speed);
            }

            playerRotation = Player.transform.eulerAngles.y;

            value = (playerRotation - transform.eulerAngles.y) - 90;

            transform.RotateAround(Player.transform.position, Vector3.up, value);

            if (rb.velocity.x > maxSpeed)
            {
                rb.velocity = new Vector3(maxSpeed, rb.velocity.y, rb.velocity.z);
            }
            else if (rb.velocity.x < -maxSpeed)
            {
                rb.velocity = new Vector3(-maxSpeed, rb.velocity.y, rb.velocity.z);
            }

            if (rb.velocity.z > maxSpeed)
            {
                rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, maxSpeed);
            }
            else if (rb.velocity.z < -maxSpeed)
            {
                rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, -maxSpeed);
            }
        }
    }
}
