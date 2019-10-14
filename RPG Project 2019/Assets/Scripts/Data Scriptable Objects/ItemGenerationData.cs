
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class StatRange {
    public StatName statName;
    public int minValue = 1;
    public int maxValue = 1;

    public float GenerateStatValue() {
        return Random.Range(minValue, maxValue+1);
    }
}

[CreateAssetMenu(fileName = "itemGenerator", menuName = "Item Generation Data")]
public class ItemGenerationData : ScriptableObject
{
    //this needs to be replaced with a system to get a text file filled with names to pick from
    public string itemName;

    //Could be replaced with a system to get item Icons from text file less necessary
    public string itemIcon;

    public EquipmentType baseItemType;

    public List<StatRange> statRanges;


    

    //could be converted to Ranges or a system of great level etc
    public int statNo = 0;

    public List<ItemBehaviour> behaviours;

    //could be converted to Ranges same as stats 
    public int behaviourNo = 0;

    public Equipment GenerateItem() {
        if (statNo > statRanges.Count) {
            Debug.LogWarning(this.name + " has a greater number of required Stats than possible stat Ranges");
        }
        if (behaviourNo > behaviours.Count)
        {
            Debug.LogWarning(this.name + " has a greater number of required beahviours than possible behaviours");
        }

        Equipment equipment = new Equipment(itemName, baseItemType, itemIcon);

        if (statNo > 0)
        {
            equipment.AddItemStatSet(GenerateStatSet());
        }

        if (behaviourNo > 0) {
            equipment.AddItemBehaviourSet(GenerateBehaviourSet());
        }

        return equipment;
    }

    public List<StatModifier> GenerateStatSet() {
        List<StatModifier> statModifiers = new List<StatModifier>();

        List<StatRange> cloneRanges =  statRanges.GetRange(0, statRanges.Count); 

        for (int i = 0; i < statNo; i++) {
            int selection = Random.Range(0, cloneRanges.Count);
            StatRange stat = cloneRanges[selection];

            statModifiers.Add(new StatModifier(stat.GenerateStatValue(), stat.statName));
            cloneRanges.RemoveAt(selection);
        }

        return statModifiers;
    }


    public List<ItemBehaviour> GenerateBehaviourSet()
    {
        List<ItemBehaviour> itemBehaviours = new List<ItemBehaviour>();

        List<ItemBehaviour> possibleBehaviours = behaviours.GetRange(0, behaviours.Count);
        for (int i = 0; i < behaviourNo; i++)
        {
            int selection = Random.Range(0, possibleBehaviours.Count);
            ItemBehaviour behaviour = possibleBehaviours[selection];
            itemBehaviours.Add(behaviour);
            possibleBehaviours.RemoveAt(selection);
        }

        return itemBehaviours;
    }
}

