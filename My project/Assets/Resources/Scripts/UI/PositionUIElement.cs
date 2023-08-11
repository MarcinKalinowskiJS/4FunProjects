using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class PositionUIElement : MonoBehaviour
{
    /*
     * TODO: check if all needed parameters were set to prevent program errors
     * Canvas scaler needs to be set to "Constant pixel size"
     * Rect transform Anchors and Pivot all set to "0"
     *(X,Y) 0,0 is lower left corner
     */
    public int widthPosPercent, heightPosPercent;
    public int widthPercent, heightPercent;
    
    private int widthMin, widthMax;
    private int heightMin, heightMax;
    private RectTransform thisElementRT;

    public void SetPositionPercentage(int widthPositionPercentageF, int heightPositionPercentageF) {
        this.widthPosPercent = widthPositionPercentageF;
        this.heightPosPercent = heightPositionPercentageF;
    }
    public void SetPosition(int widthF, int heightF)
    {
        widthPosPercent = widthF / Screen.width;
        heightPosPercent = heightF / Screen.height;
    }
    public void SetDimensions(int widthMinF, int widthMaxF, int widthPercentageF, int heightMinF, int heightMaxF, int heightPercentageF)
    {
        widthMin = widthMinF;
        widthMax = widthMaxF;
        widthPercent = widthPercentageF;

        heightMin = heightMinF;
        heightMax = heightMaxF;
        heightPercent = heightPercentageF;

    }
    
    private int GetOneDimensionSize(int maxScreenPixels, int min, int percents, int max)
    {
        

        int calculated = (int)((float)maxScreenPixels * percents / 100);

        //Debug.Log(maxScreenPixels + " <<<max Screen pixels|percents>>> " + percents + " " + calculated + "  <<<Calculated");

        if (calculated >= min && calculated <= max)
        {
            //Debug.Log("Calculated NORMAL");
            return calculated;
        }
        else if (calculated < min)
        {
            //Debug.Log("Calculated MIN");
            return min;

        }
        else if (calculated > max && max != 0) {
            //Debug.Log("Calculated MAX");
            return max;
        }
        ///Debug.Log("Calculated, NOT constrained. Default");
        //default
        return calculated;
    }

    public void AutoFit()//RectTransform rt)
    {
        thisElementRT.offsetMin = new Vector2(widthPosPercent*Screen.width/100, heightPosPercent*Screen.height/100);//Position
        thisElementRT.offsetMax = new Vector2(GetOneDimensionSize(Screen.width, widthMin, widthPosPercent+widthPercent, widthMax),
            GetOneDimensionSize(Screen.height, heightMin, heightPosPercent+heightPercent, heightMax));//Dimension
        /*
        Debug.Log((widthPosPercent * Screen.width) + " WA:HA " + (heightPosPercent * Screen.height));
        Debug.Log(GetOneDimensionSize(Screen.width, widthMin, widthPercent, widthMax) + " :width height: "
            + GetOneDimensionSize(Screen.height, heightMin, heightPercent, heightMax));
        */
    }

    public void ClearLog() //you can copy/paste this code to the bottom of your script
    {
        var assembly = Assembly.GetAssembly(typeof(UnityEditor.Editor));
        var type = assembly.GetType("UnityEditor.LogEntries");
        var method = type.GetMethod("Clear");
        method.Invoke(new object(), null);
    }

    private RectTransform GetFirstRectTransform()
    {
        return this.GetComponent<RectTransform>();
    }

    public void Start()
    {
        thisElementRT = GetFirstRectTransform();
        
    }
    public void Update()
    {
        AutoFit();
        /*
        RunAutoFit++;
        //Run
        if (RunAutoFit / 10 > 1)
        {*/
        //RunAutoFit = 0;

        //}
    }

    override public string ToString() {
        return this.name + "<PositionUIElement>";
    }
}
/*
 *     public int widthPosPercent, heightPosPercent;
    public int widthPercent, heightPercent;
    
    private int widthMin, widthMax;
    private int heightMin, heightMax;
    private RectTransform thisElementRT;
*/


/*Calculating anchors - not sure if it is the right way
        ClearLog();
        Vector2 min = rt.anchorMin;
        min.x *= Screen.width;
        min.y *= Screen.height;

        min += rt.offsetMin;

        Vector2 max = rt.anchorMax;
        max.x *= Screen.width;
        max.y *= Screen.height;

        max += rt.offsetMax;
        */
//Debug.Log(min + " MIN|MAX " + max);