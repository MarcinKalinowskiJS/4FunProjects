using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Assets.Resources.Scripts.Classes;

public class MainGameObjectScript : MonoBehaviour
{
    public enum mapLineType{xPlus, xMinus, zPlus, zMinus};
    public int chunkSize = 10;
    public float chunkSizeMiddle;
    public int visibleArea = 3;
    public int mapChunksZToLoad = 16;
    public int mapChunksXToLoad = 16;
    public int mapChunksZ = 0;
    public int mapChunksX = 0;
    private List<List<Chunks>> chunkMap;
    public LinkingScript linkingScript;
        // Start is called before the first frame update
    void Start()
    {
        chunkSizeMiddle = (float)chunkSize / 2;
        int startY = 0, startX = 0;
        //startGame(startY, startX);
        startMap(); //Needs this for initialization of first chunk
        this.GetComponent<TWG>().StartTestGame();
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
        //buildingGO.transform.position = (building.posChunk - building.sizeChunk/2)*chunkSize;
        buildingGO.transform.position = building.posChunk * chunkSize + new Vector3(building.sizeChunk.x * chunkSize, building.sizeChunk.y * chunkSize/2, building.sizeChunk.z * chunkSize);
        buildingGO.transform.localScale = building.sizeChunk * chunkSize;
        //Debug.Log(buildingGO.transform.position + " TUTAJ " + buildingGO.transform.localScale);
    }

    public void startMap() {
        chunkMap = new List<List<Chunks>>();
        Chunks c = new Chunks(Chunks.ChunksTypes.Empty);
        
        //chunkMap.Add(new List<Chunks>());
        //chunkMap[0].Add(c);
        //string chunkName = chunkMap[0][0].chunkType.ToString();

        //drawChunk(0, 0, 0, chunkSize, chunkName, chunkName);
        //Debug.Log("chunkMap.count:" + chunkMap.Count);
        //mapChunksX++;
        //mapChunksZ++;
    }

    public void LoadMapLine(mapLineType type, List<Chunks> chunksToAdd) {
        /*
        //DEBUG
        string XOY = "";
        switch (type) {
            case mapLineType.zMinus:
            case mapLineType.zPlus: { XOY = "Z"; break; }

            case mapLineType.xMinus:
            case mapLineType.xPlus: { XOY = "X"; break; }
        }
        //DEBUG

        Debug.Log(XOY + ": Chunks.count=" + chunksToAdd.Count + " Z|X " + mapChunksZ + "|" + mapChunksX);*/
        if (type == mapLineType.zMinus)
        {

                chunkMap.Insert(0, chunksToAdd);
                foreach (Chunks c in chunksToAdd) {
                    drawChunk(c);
                }
                mapChunksZ++;
        }
        else if (type == mapLineType.zPlus)
        {
                chunkMap.Add(chunksToAdd);
                foreach (Chunks c in chunksToAdd)
                {
                    drawChunk(c);
                }
                mapChunksZ++;
        }
        else if (type == mapLineType.xMinus)
        {

                for (int i = 0; i < mapChunksZ; i++)
                {
                    chunkMap[i].Insert(0, chunksToAdd[i]);
                    drawChunk(chunkMap[i][0]);
                }
                mapChunksX++;
        }
        else if (type == mapLineType.xPlus) {

                for (int i = 0; i < mapChunksZ; i++)
                {
                    chunkMap[i].Add(chunksToAdd[i]);
                    drawChunk(chunkMap[i][mapChunksX]); 
                }
                mapChunksX++;
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
        GameObject chunkGO = instantiatePrefab((int)chunk.pos.x * chunkSize + chunkSize/2, (int)chunk.pos.y * chunkSize, (int)chunk.pos.z * chunkSize + chunkSize/2, chunkName, chunkName);
        //Y needs to be bigger than zero because there are problems with black chunks when it is set to zero
        chunkGO.transform.localScale = new Vector3((float)chunkSize / 10, 0.00001f, (float)chunkSize / 10);
    }

    public void drawChunk(int x, int y, int z, float chunkSize, string prefabName, string inGameName) {
        GameObject chunk = instantiatePrefab((int)(x*chunkSize + chunkSize/2), (int)(y), (int)(z*chunkSize + chunkSize/2), prefabName, inGameName);
        //Y needs to be bigger than zero because there are problems with black chunks when it is set to zero
        chunk.transform.localScale = new Vector3((float)chunkSize/10, 0.00001f, (float)chunkSize/10);
    }

    public string convertXYZToString(int x, int y, int z) {
        return "(" + x + ", " + y + ", " + z + ")";
    }

    public GameObject instantiatePrefab(int x, int y, int z, string prefabName, string goName) {
        GameObject go = (GameObject)Instantiate(LoadPrefabFromFile("Prefabs/Chunks/" + prefabName), new Vector3(x, y, z), Quaternion.identity);
        go.name = convertXYZToString(x, y, z) + goName;
        return go;
    }
    public Chunks getChunk(int z, int x)
    {
        //Debug.Log(z + " " + x + "test" + chunkMap[z][x].connectedBuildings[0]);
        return chunkMap[z][x];
    }

    public void setChunk(int z, int x, Chunks type)
    {
        //(int)getChunk(y, x) = type;
    }

    public List<Buildings> GetBuildingsInVicinity(Vector3 position, int distance) {
        List<Buildings> vicinityBuildings = new List<Buildings>();
        Vector3 chunkPos = CalculatePosToChunk(position);
        Chunks chunk = null;

        



        List<List<Chunks>> mapInVicinity = GetPartOfMap((int)chunkPos.z - distance / 2, (int)chunkPos.x - distance / 2, distance, distance);
        for (int z = 0; z < mapInVicinity.Count; z++) {
            for (int x = 0; x < mapInVicinity[z].Count; x++) {
                Debug.Log("BInLoop: " + mapInVicinity[z][x].connectedBuildings.Count);
                vicinityBuildings.AddRange(mapInVicinity[z][x].connectedBuildings);
            }
        }
        return vicinityBuildings;
    }

    public Vector3 CalculatePosToChunk(Vector3 position) {
        
        return position / chunkSize;
    }

    private List<List<Chunks>> GetPartOfMap(int z, int x, int zElements, int xElements) {
        List<List<Chunks>> outputList;
        //Chunk constraint to get in map range
        if (z < 0)
        {
            z = 0;
        }
        if (z + zElements > mapChunksZToLoad)
        {
            zElements = mapChunksZToLoad - z;
        }
        if (x < 0)
        {
            x = 0;
        }
        if (x + xElements > mapChunksXToLoad)
        {
            xElements = mapChunksXToLoad - x;
        }

        outputList = chunkMap.GetRange(z, zElements);
        for (int zIt = 0; zIt < zElements; zIt++) {
            outputList[zIt] = outputList[zIt].GetRange(x, xElements);
        }
        return outputList;
    }
}
