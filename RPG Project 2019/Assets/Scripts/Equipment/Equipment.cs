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

    public List<ItemBehaviour> itemBehaviours;

    [System.NonSerialized]
    public CharacterInventory inventory;
    public CharacterStats characterStats;
   


    public Equipment(string pname, EquipmentType type, string psprite = "UnsetIcon") {
        name = pname;
        equipmentType = type;
        icon = psprite;
    }

    public void AddItemStat(StatModifier mod) {
        itemStats.Add(mod);
    }

    public void AddItemStatSet(List<StatModifier> mods)
    {
        itemStats = mods;
    }

    public void AddItemBehaviourSet(List<ItemBehaviour> behaviours)
    {
        itemBehaviours = behaviours;
    }

    public List<StatModifier> GetStatModifiers() {
        return itemStats;
    }

    public void Equip(GameObject character) {

        inventory = character.GetComponent<CharacterInventory>();

        characterStats = character.GetComponent<CharacterStats>();

        if (itemStats.Count > 0)
        {
            foreach (StatModifier mod in itemStats)
            {
                characterStats.statDict[mod.target()].AddModifier(mod);
            }
        }
    }

    public void Unequip() {


        if (itemStats.Count > 0)
        {

            foreach (StatModifier mod in itemStats)
            {
                characterStats.statDict[mod.target()].RemoveModifier(mod);
            }
        }
    }
}

