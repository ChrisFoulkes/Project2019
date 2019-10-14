using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterUIManager : MonoBehaviour
{


    GameObject statPanel;
    GameObject inventoryPanel;

    StatPanel stats;
    ItemPanel itemPanel;

    


    void Awake()
    {

     
    }


    public void LoadUi(CharacterInventory pinventory, CharacterStats pstats) {
        statPanel = transform.Find("CharacterStatPanel").gameObject;
        inventoryPanel = transform.Find("CharacterInventoryUi").gameObject;

        stats = statPanel.GetComponent<StatPanel>();
        itemPanel = inventoryPanel.GetComponent<ItemPanel>();

        itemPanel.Initalize(pinventory);
        stats.Initalize();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (stats.panelactive)
            {
                stats.DisablePanel();
            }
            else
            {
                stats.EnablePanel();
            }
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            if (itemPanel.panelactive)
            {

                itemPanel.DisablePanel();
                
            }
            else
            {
                itemPanel.EnablePanel();
            }
        }

    }
}
