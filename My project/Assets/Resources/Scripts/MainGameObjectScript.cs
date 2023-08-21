using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Assets.Resources.Scripts.Classes;

public class MainGameObjectScript : MonoBehaviour
{
    Maps main = null;

    
    public LinkingScript linkingScript;
        // Start is called before the first frame update
    void Start()
    {
        main = new Maps();
        //startGame(startY, startX);
        main.startMap(); //Needs this for initialization of first chunk
        this.GetComponent<TWG>().StartTestGame(main);
    }


    // Update is called once per frame
    void Update()
    {
        //TODO: Load map around player
    }

    public void addBuilding(Buildings building) {
        main.addBuilding(building);
        drawBuilding(building);
    }

    private void drawBuilding(Buildings building) {
        //Should be only one class for drawing and all other stuff should be writeen in addBuilding/addChunk. To be continued....
        building.GameObjectInstance = GameObject.CreatePrimitive(PrimitiveType.Cube);
        //buildingGO.transform.position = (building.posChunk - building.sizeChunk/2)*chunkSize;
        main.SetDimAndSize(building);
        
        //Debug.Log(buildingGO.transform.position + " TUTAJ " + buildingGO.transform.localScale);
    }



    public void LoadMapLine(Maps.mapLineType type, List<Chunks> chunksToAdd) {
        string mapName = "1";
        main.LoadLine(type, chunksToAdd);
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
        chunk.GameObjectInstance = instantiatePrefab(-10,-10,-10, chunkName, chunkName);
        main.SetDimAndSize(chunk);   
    }

    public void drawChunk(int x, int y, int z, float chunkSize, string prefabName, string inGameName) {
        GameObject chunk = instantiatePrefab((int)(x*chunkSize + chunkSize/2), (int)(y), (int)(z*chunkSize + chunkSize/2), prefabName, inGameName);
        chunk.transform.localScale = new Vector3((float)chunkSize/10, 0.00001f, (float)chunkSize/10);
    }



    public GameObject instantiatePrefab(int x, int y, int z, string prefabName, string goName) {
        GameObject go = (GameObject)Instantiate(LoadPrefabFromFile("Prefabs/Chunks/" + prefabName), new Vector3(x, y, z), Quaternion.identity);
        return go;
    }
    public Chunks GetChunk(int z, int x)
    {
        //Debug.Log(z + " " + x + "test" + chunkMap[z][x].connectedBuildings[0]);
        return main.GetChunk(z, x);
    }

    public void setChunk(int z, int x, Chunks type)
    {
        //(int)GetChunk(y, x) = type;
    }

    

    
}
