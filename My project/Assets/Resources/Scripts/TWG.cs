using Assets.Resources.Scripts.Classes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Test World Generator
public class TWG : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject mainGO;
    MainGameObjectScript mainGOS;
    public void StartTestGame()
    {
        mainGO = GameObject.Find("MainGameObject");
        mainGOS = mainGO.GetComponent<MainGameObjectScript>();

        //Debug.Log("CHUNKS1?: " + mainGOS.mapChunksZ);
        //mainGOS.LoadMapLine(MainGameObjectScript.mapLineType.xPlus, new List<Chunks>(new Chunks[] { new Chunks(Chunks.ChunksTypes.Water) }));
        //Debug.Log("CHUNKS2?: " + mainGOS.mapChunksZ);
        generateMap();
    }

    //Merchands - pick up by spending money, Factories - transport for money from factories, Warehouses - store items
    public void generateMap()
    {
        Chunks c = null;

        for (int z = 0; z < mainGOS.mapChunksZToLoad; z++)
        {
            List<Chunks> chunksToAdd = new List<Chunks>();
            //mainGOS.chunkMap.Add(new List<Chunks>());
            for (int x = 0; x < mainGOS.mapChunksXToLoad; x++)
            {
                if (x <= 0)
                {
                    c = new Chunks(Chunks.ChunksTypes.Water);
                    //mainGOS.chunkMap[z].Add(c = new Chunks(Chunks.ChunksTypes.Water));
                }
                else
                {
                    c = new Chunks(Chunks.ChunksTypes.Empty);
                    //mainGOS.chunkMap[z].Add(c = new Chunks(Chunks.ChunksTypes.Empty));
                }
                c.pos = new Vector3(x, 0, z);
                chunksToAdd.Add(c);
            }

            mainGOS.LoadMapLine(MainGameObjectScript.mapLineType.zPlus, chunksToAdd);
        }


        Buildings b = new Buildings();
        //b.posChunk = new Vector3(0, 0, 0);
        mainGOS.addBuilding(b);

        //for(int x = (int)building.posChunk.x; x < building.posChunk.x + building.sizeChunk.x; x++) {
        //for (int z = (int)building.posChunk.y; z < building.posChunk.y + building.sizeChunk.z; z++)

    }

    public void generateMapOld() {
        Chunks c = null;
            for (int z = 0; z < mainGOS.mapChunksZToLoad; z++)
            {
                List<Chunks> chunksToAdd = new List<Chunks>();
                //mainGOS.chunkMap.Add(new List<Chunks>());
                for (int x = 0; x < mainGOS.mapChunksXToLoad; x++)
                {
                    if (x <= 0)
                    {
                    c = new Chunks(Chunks.ChunksTypes.Water);
                        //mainGOS.chunkMap[z].Add(c = new Chunks(Chunks.ChunksTypes.Water));
                    }
                    else
                    {
                    c = new Chunks(Chunks.ChunksTypes.Empty);
                        //mainGOS.chunkMap[z].Add(c = new Chunks(Chunks.ChunksTypes.Empty));
                    }
                c.pos = new Vector3(x, 0, z);
                chunksToAdd.Add(c);
            }
                
            mainGOS.LoadMapLine(MainGameObjectScript.mapLineType.zPlus, chunksToAdd);
            }
            

        Buildings b = new Buildings();
        //mainGOS.addBuilding(b);

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
