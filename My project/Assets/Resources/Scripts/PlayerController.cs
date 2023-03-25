using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float speed = 10;
    public float slow = 10;


    private Rigidbody rb;

    private float movementX;
    private float movementZ;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Vector3 pos = this.transform.position;
        pos.y = 0.5f;
        GetComponent<Transform>().position = pos;
        rb.constraints = RigidbodyConstraints.FreezePositionY;
        rb.drag = slow;
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

    public static explicit operator PlayerController(GameObject v)
    {
        throw new NotImplementedException();
    }
}
