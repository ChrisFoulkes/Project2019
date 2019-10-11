using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{

    CharacterUIManager characterUI;

    CharacterInventory characterInventory;

    CharacterStats characterStats;
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
}
