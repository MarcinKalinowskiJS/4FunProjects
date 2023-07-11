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

    public void addBuilding(Buildings building) {
        chunkMap[(int)building.posChunk.z][(int)building.posChunk.x].connectedBuildings.Add(building);

        drawBuilding(building);
    }

    private void drawBuilding(Buildings building) {
        //Should be only one class for drawing and all other stuff should be writeen in addBuilding/addChunk. To be continued....
        GameObject buildingGO = GameObject.CreatePrimitive(PrimitiveType.Cube);
        buildingGO.transform.position = (building.posChunk - building.sizeChunk/2)*chunkSize;
        buildingGO.transform.localScale = building.sizeChunk*chunkSize;
        Debug.Log(buildingGO.transform.position + " TUTAJ " + buildingGO.transform.localScale);
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
    /*
    public void generateMap() {
        Chunks c = null;
        chunkMap = new List<List<Chunks>>();
        for (int z = 0; z < mapChunksZ; z++) {
            chunkMap.Add(new List<Chunks>());
            for (int x = 0; x < mapChunksX; x++) {
                if (x <= 0) 
                {
                    chunkMap[z].Add(c=new Chunks(Chunks.ChunksTypes.Water));
                }
                else {
                    chunkMap[z].Add(c=new Chunks(Chunks.ChunksTypes.Empty));
                }
            }
        }
    }
    */
    public Chunks getChunk(int z, int x)
    {
        return chunkMap[(z - 1) / chunkSize + 1][(x - 1) / chunkSize + 1];
    }

    public void setChunk(int z, int x, Chunks type)
    {
        //(int)getChunk(y, x) = type;
    }
}
