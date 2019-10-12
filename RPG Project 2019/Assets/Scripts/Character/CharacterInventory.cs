using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInventory : MonoBehaviour
{

    Dictionary<EquipmentType, Equipment> equipmentDict = new Dictionary<EquipmentType, Equipment>();

    // ?---
    ItemPanel inventoryUi;
   
    //----


    // Start is called before the first frame update

    void Start()
    {

        // ?---
        inventoryUi = GetComponent<CharacterManager>().GetInventoryUi();
        //----


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Equipment GetItemSlot(EquipmentType slot) {
        if (!CheckEmptySlot(slot)){
            return equipmentDict[slot];
        }
        else {
            return null;
        }
    }

    public bool CheckEmptySlot(EquipmentType slot) {
        if (equipmentDict.ContainsKey(slot))
        {
            return false;
        }
        else {
            return true;
        }
    }

    public void RemoveItem(EquipmentType slot) {
        if (!CheckEmptySlot(slot))
        {
           
           

            ItemUnequipped itemUnequipped = new ItemUnequipped(equipmentDict[slot]);

            EventManager.Current.TriggerEvent(itemUnequipped);

            PopupText.Instance.GenerateText(equipmentDict[slot].name + " Destroyed!");


            equipmentDict[slot].Unequip();

            equipmentDict.Remove(slot);

          

        }

    }

    public void EquipItem(Equipment equipment) {
        //check if slot empty 
        if (CheckEmptySlot(equipment.equipmentType))
        {
            equipmentDict.Add(equipment.equipmentType, equipment);
            equipment.Equip(gameObject);

            ItemEquipped itemEquipped = new ItemEquipped(equipment);
            EventManager.Current.TriggerEvent(itemEquipped);

            PopupText.Instance.GenerateText("Equipped Item: " + equipment.name);

        }
        else
        {
      

            PopupText.Instance.GenerateText("Item in slot: " + equipment.equipmentType + " already equipped!");
        }
        
    }
}
