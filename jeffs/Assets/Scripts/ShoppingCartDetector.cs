using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShoppingCartDetector : MonoBehaviour
{
    public GameObject Player;
    public GameObject CartRef;
    public GameObject Cart;

    public bool cartActive = false;

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("cart"))
        {
            if (Input.GetKey(KeyCode.E) && !cartActive)
            {
                Player.transform.position = new Vector3(CartRef.transform.position.x, 1.4f, CartRef.transform.position.z);
                //Player.transform.rotation = Cart.transform.rotation;
                Player.transform.Rotate(0f, 90f, 0f, Space.Self);

                cartActive = true;
            }

            if (Input.GetKey(KeyCode.R))
            {
                cartActive = false;
            }
        }
    }

    public void Update()
    {
        if (cartActive)
        {
            Player.transform.position = CartRef.transform.position;
        }
    }
}
