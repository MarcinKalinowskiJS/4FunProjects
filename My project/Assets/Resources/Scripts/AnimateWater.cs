using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateWater : MonoBehaviour
{
    Vector2 baseMainTextureScale;
    Vector2 baseMainTextureOffset;
    // Start is called before the first frame update
    void Start()
    {
        baseMainTextureScale = this.GetComponent<Renderer>().material.mainTextureScale;
        baseMainTextureOffset = this.GetComponent<Renderer>().material.mainTextureOffset;
        this.GetComponent<Renderer>().material.mainTextureScale /= 2;
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        //https://forum.unity.com/threads/shader-graph-texture-scaling.1120375/
        ScaleAroundTexture(this.GetComponent<Renderer>().material, Vector2.one * (Mathf.Cos(Time.time)+2));

        // https://answers.unity.com/questions/1583303/how-to-scale-and-offset-uv-coordinates-from-the-ce.html
        Debug.Log("Scale: " + this.GetComponent<Renderer>().material.mainTextureScale + " | offset" + baseMainTextureOffset);
        

        //1 - Starting top right
        //this.GetComponent<Renderer>().material.mainTextureScale = baseMainTextureScale + new Vector2((Mathf.Sin(Time.fixedTime)+1)/2, (Mathf.Sin(Time.fixedTime)+1) / 2);

        //1 - Starting down left
        //this.GetComponent<Renderer>().material.mainTextureOffset = baseMainTextureOffset - new Vector2(Mathf.Sin(Time.fixedTime)+1, Mathf.Sin(Time.fixedTime)+1);

        //Funky animation
        //this.GetComponent<Renderer>().material.mainTextureScale = new Vector2(Mathf.Cos(Time.time) * 0.5f + 1, Mathf.Sin(Time.time) * 0.5f + 1);

        //Diagonal waves
        //this.GetComponent<Renderer>().material.mainTextureOffset = baseMainTextureOffset + new Vector2(Mathf.Sin(Time.fixedTime), Mathf.Sin(Time.fixedTime));

        //Move water diagonal
        //this.GetComponent<Renderer>().material.mainTextureOffset = baseMainTextureOffset + new Vector2(Time.fixedTime%1, Time.fixedTime%1);


        //Normal | Move water towars increasing z
        //this.GetComponent<Renderer>().material.mainTextureOffset = baseMainTextureOffset + new Vector2(0, Time.fixedTime % 1);

        //Weird
        //??? this.transform.localScale = new Vector3(Mathf.Sin(Time.fixedTime), 0, Mathf.Sin(Time.fixedTime));
    }

    /// <summary>
    /// Scales the target around an arbitrary point by scaleFactor.
    /// This is relative scaling, meaning using  scale Factor of Vector3.one
    /// will not change anything and new Vector3(0.5f,0.5f,0.5f) will reduce
    /// the object size by half.
    /// The pivot is assumed to be the position in the space of the target.
    /// Scaling is applied to localScale of target.
    /// </summary>
    /// <param name="target">The object to scale.</param>
    /// <param name="pivot">The point to scale around in space of target.</param>
    /// <param name="scaleFactor">The factor with which the current localScale of the target will be multiplied with.</param>
    public static void ScaleAroundRelative(GameObject target, Vector3 pivot, Vector3 scaleFactor)
    {
        // pivot
        var pivotDelta = target.transform.localPosition - pivot;
        pivotDelta.Scale(scaleFactor);
        target.transform.localPosition = pivot + pivotDelta;

        // scale
        var finalScale = target.transform.localScale;
        finalScale.Scale(scaleFactor);
        target.transform.localScale = finalScale;
    }

    /// <summary>
    /// Scales the target around an arbitrary pivot.
    /// This is absolute scaling, meaning using for example a scale factor of
    /// Vector3.one will set the localScale of target to x=1, y=1 and z=1.
    /// The pivot is assumed to be the position in the space of the target.
    /// Scaling is applied to localScale of target.
    /// </summary>
    /// <param name="target">The object to scale.</param>
    /// <param name="pivot">The point to scale around in the space of target.</param>
    /// <param name="scaleFactor">The new localScale the target object will have after scaling.</param>
    public static void ScaleAround(GameObject target, Vector3 pivot, Vector3 newScale)
    {
        // pivot
        Vector3 pivotDelta = target.transform.localPosition - pivot; // diff from object pivot to desired pivot/origin
        Vector3 scaleFactor = new Vector3(
            newScale.x / target.transform.localScale.x,
            newScale.y / target.transform.localScale.y,
            newScale.z / target.transform.localScale.z);
        pivotDelta.Scale(scaleFactor);
        target.transform.localPosition = pivot + pivotDelta;

        //scale
        target.transform.localScale = newScale;
    }

    public static void ScaleAroundTexture(Material material, Vector2 newScale)
    {

        //target.transform.localPosition = pivot + pivotDelta;
        material.mainTextureOffset = -material.mainTextureScale / 2;

        //scale
        material.mainTextureScale = newScale;
    }
}
