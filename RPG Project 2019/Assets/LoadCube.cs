﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class LoadCube : MonoBehaviour, Iinteractable
{
   

    public void Interact(GameObject interacter)
    {
        CharacterInventory inventory = interacter.GetComponent<CharacterInventory>();

        Debug.Log("Interacted with!");

        if (inventory.CheckEmptySlot(EquipmentType.Helm))
        {
            Debug.Log("Loading Item!");
            EquipmentData itemdata = (EquipmentData)Resources.Load("Itemdata");

         
            inventory.EquipItem(itemdata.item1);
        }

    }
}
