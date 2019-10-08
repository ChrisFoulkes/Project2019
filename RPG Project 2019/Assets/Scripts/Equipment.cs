using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EquipmentType {
    Helm,
    Chest,
    Gloves
}



[System.Serializable]
public class Equipment 
{
    public string name;
    public EquipmentType equipmentType;

    [SerializeField]
    List<StatModifier> itemStats = new List<StatModifier>();

    List<Behaviour> itemBehaviours;

    CharacterInventory inventory;


    public Equipment(string pname, EquipmentType type) {
        name = pname;
        equipmentType = type;
    }

    public void AddItemStat(StatModifier mod) {
        itemStats.Add(mod);
    }

    public void Equip(GameObject Character) {
        inventory = Character.GetComponent<CharacterInventory>();

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
      //  foreach (StatModifier mod in itemStats) {
    //        characterStats.statDict[mod.targetStat].RemoveModifier(mod);
     //   }
    }
}

