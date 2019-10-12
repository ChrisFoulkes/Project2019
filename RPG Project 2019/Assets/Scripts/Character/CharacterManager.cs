using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{

    CharacterUIManager characterUI;

    CharacterInventory characterInventory;

    CharacterStats characterStats;


    public ItemPanel InventoryUi;
    // Start is called before the first frame update
    void Start()
    {
        characterUI = GameObject.Find("CharacterUiPanels").GetComponent<CharacterUIManager>();

        characterInventory = gameObject.GetComponentInChildren<CharacterInventory>();
        characterStats = gameObject.GetComponentInChildren<CharacterStats>();

        characterUI.LoadUi(characterInventory, characterStats);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public ItemPanel GetInventoryUi() {
        if (InventoryUi == null)
        {
            Debug.LogWarning("INVENTORY UI NOT SET FIX NOW!");
            return null;
        }
        else
        {
            return InventoryUi;
        }
    }
}
