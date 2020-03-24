using System.Collections;
using System.Collections.Generic;
using UnityEngine;


enum ItemType {
    Resource, 
    Equippable, 
    Consumable
}

[System.Serializable]
[CreateAssetMenu(fileName = "ResourceItem", menuName = "ItemData/Resource Item")]
public class ResourceItemData : ScriptableObject
{
    private readonly ItemType itemType = ItemType.Resource;


}
