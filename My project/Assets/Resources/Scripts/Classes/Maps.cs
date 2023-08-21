using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using UnityEngine;
using static MainGameObjectScript;

namespace Assets.Resources.Scripts.Classes


{
    public class Maps
    {
        public enum mapLineType { xPlus, xMinus, zPlus, zMinus };
        //chunkMap[z][x]
        private List<List<Chunks>> chunkMap;

        public int chunkSize = 10;
        public int visibleArea = 3;
        public int mapChunksZToLoad = 16;
        public int mapChunksXToLoad = 16;
        public int mapChunksZ = 0;
        public int mapChunksX = 0;

        //TODO: saving and loading map from the save

        //Starting map
        public void startMap()
        {
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

        public void addBuilding(Buildings building)
        {
            chunkMap[(int)building.posChunk.z][(int)building.posChunk.x].connectedBuildings.Add(building);
        }

        public void SetDimAndSize(Buildings building) {
            building.GameObjectInstance.transform.position = building.posChunk * chunkSize + new Vector3(building.sizeChunk.x * chunkSize, building.sizeChunk.y * chunkSize / 2, building.sizeChunk.z * chunkSize);
            building.GameObjectInstance.transform.localScale = building.sizeChunk * chunkSize;
            building.GameObjectInstance.name = building.GameObjectInstance.transform.position.ToString() + building.GameObjectInstance.name;
        }

        public void SetDimAndSize(Chunks chunk) {
            chunk.GameObjectInstance.transform.position = new Vector3((int)chunk.pos.x * chunkSize + chunkSize / 2, (int)chunk.pos.y * chunkSize, (int)chunk.pos.z * chunkSize + chunkSize / 2);
            chunk.GameObjectInstance.transform.localScale = new Vector3((float)chunkSize / 10, 0.00001f, (float)chunkSize / 10);
            chunk.GameObjectInstance.name = chunk.GameObjectInstance.transform.position.ToString() + chunk.GameObjectInstance.name;
        }
        /*
         Get chunks to draw
         */
        public List<Chunks> GetChunks(mapLineType axis, int axisDim, int from, int to)
        {
            int tmp;
            List<Chunks> outputList = null;

            if (from > to)
            {
                tmp = from;
                from = to;
                to = tmp;
            }
            tmp = to - from;

            if (axis == mapLineType.zMinus || axis == mapLineType.zPlus)
            {
                outputList = chunkMap[axisDim].GetRange(from, tmp);
            }
            else if (axis == mapLineType.xMinus || axis == mapLineType.xPlus)
            {
                outputList = new List<Chunks>();
                foreach (List<Chunks> chunkTmpList in chunkMap.GetRange(from, tmp)) {
                    outputList.Add(chunkTmpList[axisDim]);
                }
            }

            return outputList;
        }
        /*
        public List<List<<Chunks>> GetChunksOld(mapLineType axis, int axisDim, int from, int to)
        {
            int tmp;
            List<List<Chunks>> outputList = null;

            if (from > to)
            {
                tmp = from;
                from = to;
                to = tmp;
            }
            tmp = to - from;

            if (axis == mapLineType.zMinus || axis == mapLineType.zPlus)
            {
                outputList = new List<List<Chunks>>();
                outputList[0] = new List<Chunks>();
                outputList[0] = chunkMap[axisDim].GetRange(from, tmp);
            }
            else if (axis == mapLineType.xMinus || axis == mapLineType.xPlus)
            {
                chunkMap.GetRange(from, tmp);
                for (int zIt = 0; zIt < tmp; zIt++)
                {
                    outputList[zIt] = outputList[zIt].GetRange(axisDim, 1);
                }
            }
            */
              
            /*outputList = chunkMap.GetRange(z, zElements);
            for (int zIt = 0; zIt < zElements; zIt++)
            {
                outputList[zIt] = outputList[zIt].GetRange(x, xElements);
            }
            return outputList;
           */
           // return outputList;
        //}

        //Loading lines
        public void LoadLine(mapLineType type, List<Chunks> chunksToAdd) {
            if (type == mapLineType.zMinus)
            {

                chunkMap.Insert(0, chunksToAdd);
                mapChunksZ++;
            }
            else if (type == mapLineType.zPlus)
            {
                chunkMap.Add(chunksToAdd);
                mapChunksZ++;
            }
            else if (type == mapLineType.xMinus)
            {

                for (int i = 0; i < mapChunksZ; i++)
                {
                    chunkMap[i].Insert(0, chunksToAdd[i]);
                }
                mapChunksX++;
            }
            else if (type == mapLineType.xPlus)
            {

                for (int i = 0; i < mapChunksZ; i++)
                {
                    chunkMap[i].Add(chunksToAdd[i]);
                }
                mapChunksX++;
            }

        }
        

        private List<List<Chunks>> GetPartOfMap(int z, int x, int zElements, int xElements)
        {
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
            for (int zIt = 0; zIt < zElements; zIt++)
            {
                outputList[zIt] = outputList[zIt].GetRange(x, xElements);
            }
            return outputList;
        }

        public List<Buildings> GetBuildingsInVicinity(Vector3 position, int distance)
        {
            List<Buildings> vicinityBuildings = new List<Buildings>();
            Vector3 chunkPos = CalculatePosToChunk(position);
            Chunks chunk = null;





            List<List<Chunks>> mapInVicinity = GetPartOfMap((int)chunkPos.z - distance / 2, (int)chunkPos.x - distance / 2, distance, distance);
            for (int z = 0; z < mapInVicinity.Count; z++)
            {
                for (int x = 0; x < mapInVicinity[z].Count; x++)
                {
                    Debug.Log("BInLoop: " + mapInVicinity[z][x].connectedBuildings.Count);
                    vicinityBuildings.AddRange(mapInVicinity[z][x].connectedBuildings);
                }
            }
            return vicinityBuildings;
        }
        public Chunks GetChunk(int z, int x)
        {
            //Debug.Log(z + " " + x + "test" + chunkMap[z][x].connectedBuildings[0]);
            return chunkMap[z][x];
        }
        public string convertXYZToString(int x, int y, int z)
        {
            return "(" + x + ", " + y + ", " + z + ")";
        }

        public Vector3 CalculatePosToChunk(Vector3 position)
        {
            return position / chunkSize;
        }
    }
}
