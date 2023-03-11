using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    public GameObject player;

    public bool canJump;
    public float jumpHeight;

    void OnTriggerEnter(Collider other)
    {
        canJump = true;
    }

    void OnTriggerExit(Collider other)
    {
        canJump = false;
    }

    public void Update()
    {
        if (canJump)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                player.GetComponent<Rigidbody>().AddForce(0, jumpHeight * Time.deltaTime, 0);
            }
        }
    }
}
