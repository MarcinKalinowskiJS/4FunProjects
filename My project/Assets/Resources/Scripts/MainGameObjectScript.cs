using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Assets.Resources.Scripts.Classes;

public class MainGameObjectScript : MonoBehaviour
{
    public int chunkSize = 5;
    public int visibleArea = 3;
    public int mapChunksZ = 15;
    public int mapChunksX = 15;
    private List<List<Chunks>> chunkMap;
        // Start is called before the first frame update
    void Start()
    {

        generateMap();
        int startY = 0, startX = 0;
        startGame(startY, startX);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startGame(int startY, int startX)
    {
        string chunkName = "Empty"; //Default
        //Add visible area
        for (int z = 0; z < mapChunksZ * chunkSize; z+=chunkSize) {
            for (int x = 0; x < mapChunksX * chunkSize; x+=chunkSize) {
                chunkName = chunkMap[z/chunkSize][x/chunkSize].chunkType.ToString();
                Debug.Log(z + " " + x + " chunkName:" + chunkName);
                if (x <= 0) {
                    drawChunk(x, 0, z, chunkSize, chunkName, chunkName);
                }
                else
                {
                    drawChunk(x, 0, z, chunkSize, chunkName, chunkName);
                }

            }
        }
        
    }

    public void addBuilding() {
        //buildingMap.Add(new Buildings());

    }

    private UnityEngine.Object LoadPrefabFromFile(string filename)
    {
        var loadedObject = Resources.Load(filename);
        if (loadedObject == null)
        {
            throw new FileNotFoundException("This file was not found.");
        }
        return loadedObject;
    }

    public void drawChunk(int x, int y, int z, float chunkSize, string prefabName, string inGameName) {
        GameObject chunk = instantiatePrefab(x, y, z, prefabName, inGameName);
        //Y needs to be bigger than zero because there are problems with black chunks when it is set to zero
        chunk.transform.localScale = new Vector3(chunkSize/10, 0.00001f, chunkSize/10);

    }

    public string convertXYZToString(int x, int y, int z) {
        return "(" + x + ", " + y + ", " + z + ")";
    }

    public GameObject instantiatePrefab(int x, int y, int z, string prefabName, string goName) {
        GameObject go = (GameObject)Instantiate(LoadPrefabFromFile("Prefabs/Chunks/" + prefabName), new Vector3(x, y, z), Quaternion.identity);
        go.name = goName + convertXYZToString(x, y, z);
        return go;
    }

    public void generateMap() {
        chunkMap = new List<List<Chunks>>();
        for (int z = 0; z < mapChunksZ; z++) {
            chunkMap.Add(new List<Chunks>());
            for (int x = 0; x < mapChunksX; x++) {
                if (x <= 0) 
                {
                    chunkMap[z].Add(new Chunks(Chunks.ChunksTypes.Water));
                }
                else {
                    chunkMap[z].Add(new Chunks(Chunks.ChunksTypes.Empty));
                }
            }
        }
    }

    public Chunks getChunk(int z, int x)
    {
        return chunkMap[(z - 1) / chunkSize + 1][(x - 1) / chunkSize + 1];
    }

    public void setChunk(int z, int x, Chunks type)
    {
        //(int)getChunk(y, x) = type;
    }
}
