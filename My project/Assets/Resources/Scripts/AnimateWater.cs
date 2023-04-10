using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateWater : MonoBehaviour
{
    public IAnimateStrategy myAnimate;


    // Start is called before the first frame update
    void Start()
    {
        myAnimate = new Animate5();
        myAnimate.baseMainTextureScale = this.GetComponent<Renderer>().material.mainTextureScale;
        myAnimate.baseMainTextureOffset = this.GetComponent<Renderer>().material.mainTextureOffset;
        myAnimate.renderer = this.GetComponent<Renderer>();

        //myTexture
    }

    void setAnimation()
    {

    }
    // Update is called once per frame
    void FixedUpdate()
    {
        myAnimate.Animate();
    }

    //<summary>
    //!IMPORTANT - When the values of scale are between -1 to 1 the texture will be mirrored probably horizontally and Vertically, when from 0 to 1 no mirroring
    //Shift: Vector2(1f, 1f) - move by the size of whole texture, Vector2(0.5f, 0.5f) - move by half the texture
    //</summary>
    public static void ScaleAroundTextureRelative(Material material, Vector2 newScale, Vector2 shift)
    {

        //target.transform.localPosition = pivot + pivotDelta;
        material.mainTextureOffset = -material.mainTextureScale / 2 + shift;

        //scale
        material.mainTextureScale = newScale;
    }

    //<summary>
    //!IMPORTANT - When the values of scale are between -1 to 1 the texture will be mirrored probably horizontally and Vertically, when from 0 to 1 no mirroring
    //</summary>
    public static void ScaleAroundTexture(Material material, Vector2 newScale)
    {

        //first making the texture scale around middle then moving texture to the middle
        material.mainTextureOffset = -material.mainTextureScale / 2 - new Vector2(0.5f, 0.5f);

        //scale
        material.mainTextureScale = newScale;
    }
}
