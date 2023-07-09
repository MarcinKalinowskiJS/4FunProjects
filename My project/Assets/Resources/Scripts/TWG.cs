using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Test World Generator
public class TWG : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject mainGO;
    MainGameObjectScript mainGOS;
    void Start()
    {
        mainGO = GameObject.Find("MainGameObject");
        mainGOS = mainGO.GetComponent<MainGameObjectScript>();
    }

    //Merchands - pick up by spending money, Factories - transport for money from factories, Warehouses - store items
    public void generateTemporaryBuildings() {
        //mainGOS;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
