using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;

    public GameObject Cam;
    public GameObject CartDetector;

    private float moveX = 0f;
    private float moveZ = 0f;

    public float xSpeed = 1500f;
    public float zSpeed = 1500f;

    public float topSpeed = 4.5f;

    public float mouseSensitivity = 10f;

    public float cameraPitch;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        Cursor.lockState = CursorLockMode.Locked;

        Cursor.visible = false;
    }

    void Update()
    {
        if (!CartDetector.GetComponent<ShoppingCartDetector>().cartActive)
        {
            //check z inputs
            if (Input.GetKey(KeyCode.W))
            {
                moveZ = 1f;
            }
            else if (Input.GetKey(KeyCode.S))
            {
                moveZ = -1f;
            }
            else
            {
                moveZ = 0f;
            }

            //check x inputs
            if (Input.GetKey(KeyCode.A))
            {
                moveX = -1f;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                moveX = 1f;
            }
            else
            {
                moveX = 0f;
            }
        }

        //rotate cam horizontally
        transform.Rotate(Input.GetAxis("Mouse X") * mouseSensitivity * Vector3.up);

        //rotate cam vertically
        cameraPitch -= Input.GetAxis("Mouse Y") * mouseSensitivity;

        cameraPitch = Mathf.Clamp(cameraPitch, -90.0f, 90.0f);

        Cam.transform.localEulerAngles = Vector3.right * cameraPitch;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!CartDetector.GetComponent<ShoppingCartDetector>().cartActive)
        {
            if (rb.velocity.x < topSpeed && rb.velocity.x > -topSpeed)
            {
                rb.AddForce(moveX * Time.deltaTime * xSpeed * transform.right);
            }

            if (rb.velocity.z < topSpeed && rb.velocity.z > -topSpeed)
            {
                rb.AddForce(moveZ * Time.deltaTime * zSpeed * transform.forward);
            }

            if (rb.velocity.x > topSpeed)
            {
                rb.velocity = new Vector3(topSpeed, rb.velocity.y, rb.velocity.z);
            }

            if (rb.velocity.x < -topSpeed)
            {
                rb.velocity = new Vector3(-topSpeed, rb.velocity.y, rb.velocity.z);
            }

            if (rb.velocity.z > topSpeed)
            {
                rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, topSpeed);
            }

            if (rb.velocity.z < -topSpeed)
            {
                rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, -topSpeed);
            }
        }
    }
}
