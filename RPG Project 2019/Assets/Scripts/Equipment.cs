using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EquipmentType {
    Helm,
    Chest,
    Gloves,
    Boots
}



[System.Serializable]
public class Equipment 
{
    public string name;
    public EquipmentType equipmentType;

    public string icon; 

    [SerializeField]
    List<StatModifier> itemStats = new List<StatModifier>();

    List<Behaviour> itemBehaviours;

    CharacterInventory inventory;

   


    public Equipment(string pname, EquipmentType type, string psprite = "UnsetIcon") {
        name = pname;
        equipmentType = type;
        icon = psprite;
    }

    public void AddItemStat(StatModifier mod) {
        itemStats.Add(mod);
    }

    public void Equip(GameObject character) {
        inventory = character.GetComponent<CharacterInventory>();

        if (inventory.CheckEmptySlot(equipmentType)){
            inventory.EquipItem(equipmentType, this);
        }
        else
        {
            PopupText.Instance.GenerateText("Item in slot: " + equipmentType + " already equipped!");
        }
        //foreach (StatModifier mod in itemStats) {
        //    characterStats.statDict[mod.targetStat].AddModifier(mod);
       // }
    }

    public void Unequip() {
        inventory.RemoveItem(equipmentType);

        //  foreach (StatModifier mod in itemStats) {
        //        characterStats.statDict[mod.targetStat].RemoveModifier(mod);
        //   }
    }
}

