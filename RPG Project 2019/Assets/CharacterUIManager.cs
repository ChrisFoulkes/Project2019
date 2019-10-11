using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterUIManager : MonoBehaviour
{


    GameObject statPanel;
    GameObject inventoryPanel;

    StatPanel stats;
    ItemPanel inventory;

    


    void Awake()
    {

     
    }


    public void LoadUi(CharacterInventory pinventory, CharacterStats pstats) {
        statPanel = transform.Find("CharacterStatPanel").gameObject;
        inventoryPanel = transform.Find("CharacterInventoryPanel").gameObject;

        stats = statPanel.GetComponent<StatPanel>();
        inventory = inventoryPanel.GetComponent<ItemPanel>();

        inventory.Initalize(pinventory);
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
            if (statPanel.activeSelf)
            {
                statPanel.SetActive(false);
            }
            else
            {
                statPanel.SetActive(true);
            }
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            if (inventoryPanel.activeSelf)
            {
                inventoryPanel.SetActive(false);
            }
            else
            {
                inventoryPanel.SetActive(true);
            }
        }

    }
}
