using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Assets.Resources.Scripts.Classes;

public class MainGameObjectScript : MonoBehaviour
{
    public enum mapLineType{xPlus, xMinus, zPlus, zMinus};
    public int chunkSize = 5;
    public int visibleArea = 3;
    public int mapChunksZ = 1;
    public int mapChunksX = 1;
    private List<List<Chunks>> chunkMap;
        // Start is called before the first frame update
    void Start()
    {
        //generateMap();
        int startY = 0, startX = 0;
        //startGame(startY, startX);
        startMap();
        TWG.
    }

    // Update is called once per frame
    void Update()
    {
        
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

    public void startMap() {
        chunkMap = new List<List<Chunks>>();
        chunkMap[0].Add(new Chunks(Chunks.ChunksTypes.Empty));
        string chunkName = chunkMap[0][0].chunkType.ToString();

        drawChunk(0, 0, 0, chunkSize, chunkName, chunkName);
    }

    public void LoadMapLine(mapLineType type, List<Chunks> chunksToAdd) {
        if (type == mapLineType.zMinus)
        {
            if (chunksToAdd.Count != mapChunksX)
            {
                Debug.Log("!!!!MAP ERROR: chunks to add count do not mach - size of X");
            }
            else
            {
                chunkMap.Insert(0, chunksToAdd);
                foreach (Chunks c in chunksToAdd) {
                    drawChunk(c);
                }
                mapChunksZ++;
            }
        }
        else if (type == mapLineType.zPlus)
        {
            if (chunksToAdd.Count != mapChunksX)
            {
                Debug.Log("!!!!MAP ERROR: chunks to add count do not mach - size of X");
            }
            else
            {
                chunkMap.Add(chunksToAdd);
                foreach (Chunks c in chunksToAdd)
                {
                    drawChunk(c);
                }
                mapChunksZ++;
            }
        }
        else if (type == mapLineType.xMinus)
        {
            if (chunksToAdd.Count != mapChunksZ) {
                Debug.Log("!!!!MAP ERROR: chunks to add count do not mach - size of Z");
            }
            else
            {
                for (int i = 0; i < mapChunksZ; i++)
                {
                    chunkMap[i].Insert(0, chunksToAdd[i]);
                    drawChunk(chunkMap[i][0]);
                }
                mapChunksX++;
            }
        }
        else if (type == mapLineType.xPlus) {
            if (chunksToAdd.Count != mapChunksZ)
            {
                Debug.Log("!!!!MAP ERROR: chunks to add count do not mach - size of X");
            }
            else
            {
                for (int i = 0; i < mapChunksZ; i++)
                {
                    chunkMap[i].Add(chunksToAdd[i]);
                    drawChunk(chunkMap[i][mapChunksX + 1]);
                }
                mapChunksX++;
            }

        }
        
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

    public void drawChunk(Chunks chunk) {
        string chunkName = chunk.chunkType.ToString();
        GameObject chunkGO = instantiatePrefab((int)chunk.pos.x * chunkSize, (int)chunk.pos.y * chunkSize, (int)chunk.pos.z * chunkSize, chunkName, chunkName);
        //Y needs to be bigger than zero because there are problems with black chunks when it is set to zero
        chunkGO.transform.localScale = new Vector3(chunkSize / 10, 0.00001f, chunkSize / 10);
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
