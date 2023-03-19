using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float speed = 10;
    
    private Rigidbody rb;

    private float movementX;
    private float movementZ;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnMove(InputValue movementValue)
    {
        //TODO: Movement should be realized according to movement of camera to avoid confusion
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementZ = movementVector.y;
    }

    private void FixedUpdate()
    {
        bool movementWorld = false;

        if (movementWorld == true)
        {
            Vector3 movement = new Vector3(movementX, 0.0f, movementZ);
        }

        Vector3 movForward = Camera.main.transform.forward.normalized * movementZ;
        Vector3 movRight = Camera.main.transform.right.normalized * movementX;

        //https://www.youtube.com/watch?v=7kGCrq1cJew


        rb.AddForce((movForward + movRight) * speed);
    }

}
