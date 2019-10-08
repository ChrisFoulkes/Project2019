using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInventory : MonoBehaviour
{

    Dictionary<EquipmentType, Equipment> equipmentDict = new Dictionary<EquipmentType, Equipment>(); 
    // Start is called before the first frame update

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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

    public void EquipItem(EquipmentType slot, Equipment equipment) {
        equipmentDict.Add(slot, equipment);


        ItemEquipped itemEquipped = new ItemEquipped(equipment);
        EventManager.Current.TriggerEvent(itemEquipped);
        PopupText.Instance.GenerateText("Equipped Item: " + equipment.name);
        
    }
}
