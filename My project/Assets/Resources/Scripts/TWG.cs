using Assets.Resources.Scripts.Classes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Test World Generator
public class TWG : MonoBehaviour
{
    public LinkingScript linkingScript;
    // Start is called before the first frame update
    private Maps testMap = null;
   // GameObject mainGO;
    public void StartTestGame(Maps testMap)
    {
        //mainGO = linkingScript.MGOS.GetComponent<MainGameObjectScript>();

        //Debug.Log("CHUNKS1?: " + testMap.mapChunksZ);
        //testMap.LoadMapLine(MainGameObjectScript.mapLineType.xPlus, new List<Chunks>(new Chunks[] { new Chunks(Chunks.ChunksTypes.Water) }));
        //Debug.Log("CHUNKS2?: " + testMap.mapChunksZ);
        generateMap();

        checkStock();
    }

    public void checkStock() {
        Debug.Log(testMap.GetChunk(1, 1).connectedBuildings[0].getAllStockToString());
    }

    //Merchands - pick up by spending money, Factories - transport for money from factories, Warehouses - store items
    public void generateMap()
    {
        Chunks c = null;

        for (int z = 0; z < testMap.mapChunksZToLoad; z++)
        {
            List<Chunks> chunksToAdd = new List<Chunks>();
            //testMap.chunkMap.Add(new List<Chunks>());
            for (int x = 0; x < testMap.mapChunksXToLoad; x++)
            {
                if (x <= 0)
                {
                    c = new Chunks(Chunks.ChunksTypes.Water);
                    //testMap.chunkMap[z].Add(c = new Chunks(Chunks.ChunksTypes.Water));
                }
                else
                {
                    c = new Chunks(Chunks.ChunksTypes.Empty);
                    //testMap.chunkMap[z].Add(c = new Chunks(Chunks.ChunksTypes.Empty));
                }
                c.pos = new Vector3(x, 0, z);
                chunksToAdd.Add(c);
            }

            testMap.LoadMapLine(MainGameObjectScript.mapLineType.zPlus, chunksToAdd);
        }


        Buildings b = new Buildings();
        //b.posChunk = new Vector3(0, 0, 0);
        testMap.addBuilding(b);

        b = new Buildings();
        b.posChunk = new Vector3(1, 0, 1);
        testMap.addBuilding(b);

        //for(int x = (int)building.posChunk.x; x < building.posChunk.x + building.sizeChunk.x; x++) {
        //for (int z = (int)building.posChunk.y; z < building.posChunk.y + building.sizeChunk.z; z++)

    }

    public void generateMapOld() {
        Chunks c = null;
            for (int z = 0; z < testMap.mapChunksZToLoad; z++)
            {
                List<Chunks> chunksToAdd = new List<Chunks>();
                //testMap.chunkMap.Add(new List<Chunks>());
                for (int x = 0; x < testMap.mapChunksXToLoad; x++)
                {
                    if (x <= 0)
                    {
                    c = new Chunks(Chunks.ChunksTypes.Water);
                        //testMap.chunkMap[z].Add(c = new Chunks(Chunks.ChunksTypes.Water));
                    }
                    else
                    {
                    c = new Chunks(Chunks.ChunksTypes.Empty);
                        //testMap.chunkMap[z].Add(c = new Chunks(Chunks.ChunksTypes.Empty));
                    }
                c.pos = new Vector3(x, 0, z);
                chunksToAdd.Add(c);
            }
                
            testMap.LoadMapLine(MainGameObjectScript.mapLineType.zPlus, chunksToAdd);
            }
            

        Buildings b = new Buildings();

        //testMap.addBuilding(b);

        //for(int x = (int)building.posChunk.x; x < building.posChunk.x + building.sizeChunk.x; x++) {
            //for (int z = (int)building.posChunk.y; z < building.posChunk.y + building.sizeChunk.z; z++)
            
    }
    /*
    public void startGame(int startY, int startX)
    {
        string chunkName = "Empty"; //Default
        //Add visible area
        for (int z = 0; z < mapChunksZ * chunkSize; z += chunkSize)
        {
            for (int x = 0; x < mapChunksX * chunkSize; x += chunkSize)
            {
                chunkName = chunkMap[z / chunkSize][x / chunkSize].chunkType.ToString();

                if (x <= 0)
                {
                    drawChunk(x, 0, z, chunkSize, chunkName, chunkName);
                }
                else
                {
                    drawChunk(x, 0, z, chunkSize, chunkName, chunkName);
                }
            }
        }

    }
    */
    // Update is called once per frame
    void Update()
    {
        
    }
}
