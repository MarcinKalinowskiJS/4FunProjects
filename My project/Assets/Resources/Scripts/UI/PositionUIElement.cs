using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class PositionUIElement : MonoBehaviour
{
    public float test0 = 1;
    public RectTransform rt;
    public float test;
    
    /*
     * Canvas scaler needs to be set to "Constant pixel size"
     * Rect transform Anchros and Pivot all set to "0"
     */
    private int widthA, heightA;
    private int widthMin, widthMax, widthPercentage;
    private int heightMin, heightMax, heightPercentage;
    public void SetPosition(int widthF, int heightF) {
        widthA = widthF;
        heightA = heightF;
    }
    public void SetDimensions(int widthMinF, int widthMaxF, int widthPercentageF, int heightMinF, int heightMaxF, int heightPercentageF)
    {
        widthMin = widthMinF;
        widthMax = widthMaxF;
        widthPercentage = widthPercentageF;

        heightMin = heightMinF;
        heightMax = heightMaxF;
        heightPercentage = heightPercentageF;

    }
    
    private int GetOneDimensionSize(int maxScreenPixels, int percents, int min, int max)
    {
        int calculated = (int)(maxScreenPixels * percents / 100);

        if (calculated >= min && calculated <= max)
        {
            Debug.Log("Calculated NORMAL");
            return calculated;
        }
        else if (calculated < min)
        {
            Debug.Log("Calculated MIN");
            return min;

        }
        else if (calculated > max) {
            Debug.Log("Calculated MAX");
            return max;
        }
        Debug.Log("NOT Calculated. Default");
        //default
        return calculated;
    }

    public void AutoFit(RectTransform rt)//RectTransform rt)
    {

        rt.offsetMin = new Vector2(0, Screen.height-25);
        rt.offsetMax = new Vector2(Screen.width,Screen.height);
        


        
        //rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, ;
        Debug.Log("Screen width:" + Screen.width);
    }

    public void ClearLog() //you can copy/paste this code to the bottom of your script
    {
        var assembly = Assembly.GetAssembly(typeof(UnityEditor.Editor));
        var type = assembly.GetType("UnityEditor.LogEntries");
        var method = type.GetMethod("Clear");
        method.Invoke(new object(), null);
    }

    public void Start()
    {
        
    }
    public void Update()
    {
        AutoFit(rt);
    }
}



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