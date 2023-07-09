using Assets.Resources.Scripts.Classes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chunks
{   
    public enum ChunksTypes { Empty, Water };
    public ChunksTypes chunkType;
    public List<Buildings> connectedBuildings;

    public Chunks(ChunksTypes chunkTypeC) {//Chunk Type Constructor
        chunkType = chunkTypeC;
    }


}
