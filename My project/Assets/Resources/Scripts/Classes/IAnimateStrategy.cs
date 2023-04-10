using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAnimateStrategy
{
    Vector2 baseMainTextureScale { get; set; }
    Vector2 baseMainTextureOffset { get; set; }
    Renderer renderer {get; set;}
    public void Animate();
}



//1 - Starting top right
    public class Animate0 : IAnimateStrategy
{
    public Vector2 baseMainTextureScale { get; set; }
    public Vector2 baseMainTextureOffset { get; set; }
    public Renderer renderer { get; set; }
    
    public void Animate()
    {
        renderer.material.mainTextureScale = baseMainTextureScale + new Vector2((Mathf.Sin(Time.fixedTime) + 1) / 2, (Mathf.Sin(Time.fixedTime) + 1) / 2);
    }
}

//1 - Starting down left - Not working correctly
public class Animate1 : IAnimateStrategy
{
    public Vector2 baseMainTextureScale { get; set; }
    public Vector2 baseMainTextureOffset { get; set; }
    public Renderer renderer { get; set; }

    public void Animate()
    {
        //renderer.material.mainTextureOffset = baseMainTextureOffset - new Vector2(Mathf.Sin(Time.fixedTime)+1, Mathf.Sin(Time.fixedTime)+1);
        renderer.material.mainTextureScale = baseMainTextureScale - new Vector2((Mathf.Sin(Time.fixedTime) + 1)/2, (Mathf.Sin(Time.fixedTime) + 1)/2);
    }
}
public class Animate2 : IAnimateStrategy
{
    public Vector2 baseMainTextureScale { get; set; }
    public Vector2 baseMainTextureOffset { get; set; }
    public Renderer renderer { get; set; }

    public void Animate()
    {
        renderer.material.mainTextureScale = new Vector2(Mathf.Cos(Time.time) * 0.5f + 1, Mathf.Sin(Time.time) * 0.5f + 1);
    }
}

//Funky animation
public class Animate3 : IAnimateStrategy
{
    public Vector2 baseMainTextureScale { get; set; }
    public Vector2 baseMainTextureOffset { get; set; }
    public Renderer renderer { get; set; }

    public void Animate()
    {
        renderer.material.mainTextureOffset = baseMainTextureOffset + new Vector2(Mathf.Sin(Time.fixedTime), Mathf.Sin(Time.fixedTime));
    }
}
//Move water diagonal
public class Animate4 : IAnimateStrategy
{
    public Vector2 baseMainTextureScale { get; set; }
    public Vector2 baseMainTextureOffset { get; set; }
    public Renderer renderer { get; set; }

    public void Animate()
    {
        renderer.material.mainTextureOffset = baseMainTextureOffset + new Vector2(Time.fixedTime % 1, Time.fixedTime % 1);
    }
}
//Normal | Move water towars increasing z
public class Animate5 : IAnimateStrategy
{
    public Vector2 baseMainTextureScale { get; set; }
    public Vector2 baseMainTextureOffset { get; set; }
    public Renderer renderer { get; set; }

    public void Animate()
    {
        renderer.material.mainTextureOffset = baseMainTextureOffset + new Vector2(0, Time.fixedTime % 1);
    }
}
//Weird - zooming in and out whole chunks
public class Animate6 : IAnimateStrategy
{
    public Vector2 baseMainTextureScale { get; set; }
    public Vector2 baseMainTextureOffset { get; set; }
    public Renderer renderer { get; set; }

    public void Animate()
    {
        //transform.localScale = new Vector3(Mathf.Sin(Time.fixedTime), 0, Mathf.Sin(Time.fixedTime));
    }
}

//https://www.dofactory.com/net/strategy-design-pattern


//https://answers.unity.com/questions/523409/strategy-pattern-with-monobehaviours.html