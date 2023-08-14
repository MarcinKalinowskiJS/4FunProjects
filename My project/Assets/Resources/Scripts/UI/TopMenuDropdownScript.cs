using Assets.Resources.Scripts.Classes;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class TopMenuDropdownScript : MonoBehaviour
{
    public float distanceToBuildings = 10;
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
        //Clear options
        this.gameObject.GetComponent<TMP_Dropdown>().options.Clear();
        
        foreach(Buildings b in nearBuildings)
        {
            this.gameObject.GetComponent<TMP_Dropdown>().options.Add(new TMP_Dropdown.OptionData(b.posChunk.ToString()));
            this.gameObject.GetComponent<TMP_Dropdown>().RefreshShownValue();
        }

        if (nearBuildings.Count > 0 && this.gameObject.GetComponent<TMP_Dropdown>().IsExpanded == false)
        {//Show dropdown automatically
            this.gameObject.GetComponent<TMP_Dropdown>().SetValueWithoutNotify(-1);
            //this.gameObject.GetComponent<TMP_Dropdown>().Show();
        }
        else if (nearBuildings.Count <= 0 && this.gameObject.GetComponent<TMP_Dropdown>().IsExpanded == true)
        { //Hide dropdown automatically
            //this.gameObject.GetComponent<TMP_Dropdown>().Hide();
            
        }
        else if (nearBuildings.Count <= 0) {//Show empty dropdown
            this.gameObject.GetComponent<TMP_Dropdown>().RefreshShownValue();
        }
    }

}
