using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShoppingCartDetector : MonoBehaviour
{
    public GameObject Player;
    public GameObject Cart;

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("cart"))
        {
            if (Input.GetKey(KeyCode.E))
            {
                Player.transform.SetPositionAndRotation(new Vector3(Cart.transform.position.x, 1.4f, Cart.transform.position.z), new Quaternion(Cart.transform.rotation.x, Cart.transform.rotation.y + 90, Cart.transform.rotation.z, 90));
            }
        }
    }
}
