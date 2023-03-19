using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public enum Type { permanent, follow }

    public float speed = 1, distance = 10, height = 5;
    public bool adjHeight = false;
    public bool lookAt = false;
    private Vector3 velocity = Vector3.one;
    Transform playerT, thisTransform;
    Vector3 oldPosition;
    public Type type;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        rb.detectCollisions = false;
        playerT = GameObject.Find("Player").transform;
        thisTransform = this.transform;
        //offset = thisTransform.position - playerT.position;
    }


    Vector3 changeY(Vector3 origin, float y) {
        return new Vector3(origin.x, y, origin.z);
    }

    // Update is called once per frame
    void FixedUpdate()
    {


        float dist = Vector3.Distance(thisTransform.position, playerT.position);

        thisTransform.position = Vector3.Lerp(changeY(thisTransform.position, height), changeY(playerT.position, height), (dist-10)*0.1f);

        transform.LookAt(playerT.position);

        if (type == Type.permanent) {
            ;
        };
            
    }


    
    /*private void FixedUpdate()
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
    }*/
}
