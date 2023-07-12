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
        generateMap();
    }

    //Merchands - pick up by spending money, Factories - transport for money from factories, Warehouses - store items
    public void generateMap() {
            Chunks c = null;
            mainGOS.chunkMap = new List<List<Chunks>>();
            for (int z = 0; z < mainGOS.mapChunksZ; z++)
            {
                mainGOS.chunkMap.Add(new List<Chunks>());
                for (int x = 0; x < mainGOS.mapChunksX; x++)
                {
                    if (x <= 0)
                    {
                        mainGOS.chunkMap[z].Add(c = new Chunks(Chunks.ChunksTypes.Water));
                    }
                    else
                    {
                        mainGOS.chunkMap[z].Add(c = new Chunks(Chunks.ChunksTypes.Empty));
                    }
                }
            }


        Buildings b = new Buildings();
        mainGOS.addBuilding(b);

        //for(int x = (int)building.posChunk.x; x < building.posChunk.x + building.sizeChunk.x; x++) {
            //for (int z = (int)building.posChunk.y; z < building.posChunk.y + building.sizeChunk.z; z++)
            
            }

    // Update is called once per frame
    void Update()
    {
        
    }
}
