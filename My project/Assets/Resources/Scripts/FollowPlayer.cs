using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public enum Type { permanent, follow }

    public float speed = 1, distance = 10, height = 5;
    public bool adjHeight = false;
    public bool lookAt = false, rotation;
    Transform playerT, thisTransform;
    Vector3 oldPosition;
    public Type type;

    // Start is called before the first frame update
    void Start()
    {
        playerT = GameObject.Find("Player").transform;
        thisTransform = this.transform;
    }


    Vector3 changeY(Vector3 origin, float y) {
        return new Vector3(origin.x, y, origin.z);
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (type == Type.follow)
        {
            //Whole distance between this object and player
            float dist = Vector3.Distance(thisTransform.position, playerT.position);
            thisTransform.position = Vector3.Lerp(changeY(thisTransform.position, height), changeY(playerT.position, height), (dist - distance) * 0.1f); ;
        }
        

        if (lookAt) {
            transform.LookAt(playerT.position);
        }

        
    }

    private void LateUpdate()
    {
        if (type == Type.permanent)
        {
            thisTransform.position = playerT.position;
            if(rotation) {
                //Degree
                Vector3 actualVelocity = GameObject.Find("Player").GetComponent<Rigidbody>().velocity;
                Vector3 forward = playerT.forward;
                //thisTransform.rotation.SetLookRotation(actualVelocity);
                if(GameObject.Find("Player").GetComponent<Rigidbody>().drag>0)
                thisTransform.LookAt(playerT.position - actualVelocity + new Vector3(
                    0, 
                    GameObject.Find("Player").GetComponent<PlayerController>().speed/ (GameObject.Find("Player").GetComponent<Rigidbody>().drag*10),
                    0 )
                );
            }
            //Add rotation of flame based on speed to look like wind blowing when moving with greater speeds
        }

    }

}
