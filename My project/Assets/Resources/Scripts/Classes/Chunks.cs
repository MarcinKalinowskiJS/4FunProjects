using Assets.Resources.Scripts.Classes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chunks
{   
    public enum ChunksTypes { Empty, Water };
    public ChunksTypes chunkType;
    public Vector3 pos;
    public List<Buildings> connectedBuildings = new List<Buildings>();

    public Chunks(ChunksTypes chunkTypeC) {//Chunk Type Constructor
        chunkType = chunkTypeC;
    }


}
