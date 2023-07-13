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
    void LateUpdate()
    {
        mainGO = GameObject.Find("MainGameObject");
        mainGOS = mainGO.GetComponent<MainGameObjectScript>();
    }

    //Merchands - pick up by spending money, Factories - transport for money from factories, Warehouses - store items
    public void generateMap() {
        Chunks c = null;
            for (int z = 0; z < mainGOS.mapChunksZ; z++)
            {
                List<Chunks> chunksToAdd = new List<Chunks>();
                //mainGOS.chunkMap.Add(new List<Chunks>());
                for (int x = 0; x < mainGOS.mapChunksX; x++)
                {
                    if (x <= 0)
                    {
                    chunksToAdd.Add(c = new Chunks(Chunks.ChunksTypes.Water));
                        //mainGOS.chunkMap[z].Add(c = new Chunks(Chunks.ChunksTypes.Water));
                    }
                    else
                    {
                    chunksToAdd.Add(c = new Chunks(Chunks.ChunksTypes.Empty));
                        //mainGOS.chunkMap[z].Add(c = new Chunks(Chunks.ChunksTypes.Empty));
                    }
                    
                }
            mainGOS.LoadMapLine(MainGameObjectScript.mapLineType.zPlus, chunksToAdd);
            }
            

        Buildings b = new Buildings();
        mainGOS.addBuilding(b);

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
