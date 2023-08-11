using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinkingScript : MonoBehaviour
{
    // Start is called before the first frame update
    public MainGameObjectScript MGOS;
    public PlayerController PC;
    public TopMenuDropdownScript TMD;

    bool checkLinking;
    void Start()
    {
        checkLinking = true;
        GetLinks();
        SetLinks();
    }

    // Update is called once per frame
    void Update()
    {
        if (checkLinking == false) {
            checkLinking = true;
            GetLinks();
            SetLinks();
            Debug.Log("Check Linking!!!!!!!!!!!!!!!!!");
        }
    }

    private void GetLinks() {
        MGOS = GameObject.Find("MainGameObject").GetComponent<MainGameObjectScript>();
        PC = GameObject.Find("Player").GetComponent<PlayerController>();
        TMD = GameObject.Find("TopMenuDropdown").GetComponent<TopMenuDropdownScript>();

        if (MGOS == null || PC == null || TMD == null)
        {
            checkLinking = false;
        }
    }

    private void SetLinks() {
        MGOS.linkingScript = this;
        PC.linkingScript = this;
        TMD.linkingScript = this;

        if (MGOS.linkingScript == null || PC.linkingScript == null || TMD.linkingScript == null) {
            checkLinking = false;
        }
    }
}
