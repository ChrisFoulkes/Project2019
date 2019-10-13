using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveCube : MonoBehaviour, Iinteractable
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Interact(GameObject interacter)
    {
        CharacterInventory inventory = interacter.GetComponent<CharacterInventory>();

        if (!inventory.CheckEmptySlot(EquipmentType.Helm)) {
            inventory.SaveItem(EquipmentType.Helm);
        }
        
    }

}