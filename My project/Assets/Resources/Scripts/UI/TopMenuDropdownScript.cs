using Assets.Resources.Scripts.Classes;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class TopMenuDropdownScript : MonoBehaviour
{
    public float distanceToBuildings = 1;
    public LinkingScript linkingScript;
    private List<Buildings> nearBuildings = null;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        nearBuildings = linkingScript.MGOS.GetBuildingsInVicinity(linkingScript.PC.transform.position, (int)distanceToBuildings);
        UpdateDropdown();
    }

    public void UpdateDropdown() {
        this.gameObject.GetComponent<TMP_Dropdown>().options.Clear();
        Debug.Log("NB: " + nearBuildings.Count);
        this.gameObject.GetComponent<TMP_Dropdown>().options.Add(new TMP_Dropdown.OptionData(nearBuildings[0].posChunk.ToString()));
        // nearBuildings[0].name
        /*
        this.gameObject.GetComponent<TMP_Dropdown>().options.Clear();

        TMP_Dropdown.OptionData od = new TMP_Dropdown.OptionData();
        od.text = "Pierogies";
        this.gameObject.GetComponent<TMP_Dropdown>().options.Add(od);

        od = new TMP_Dropdown.OptionData();
        od.text = "Ziemniakos";
        this.gameObject.GetComponent<TMP_Dropdown>().options.Add(od);
        */
    }

}
