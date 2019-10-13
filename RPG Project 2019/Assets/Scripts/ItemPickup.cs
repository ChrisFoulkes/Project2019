using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour, Iinteractable
{

    public ItemData item;
    // Start is called before the first frame update
    void Start()
    {
        if (item == null) {
            gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 0f, 0f);
        }
    }


    public void Interact(GameObject interacter)
    {
        CharacterInventory charinventory = interacter.GetComponent<CharacterInventory>();
        if (item != null) {

            item.equipment.itemBehaviours.Add(BonusBehaviour.CreateInstance<BonusBehaviour>());
            charinventory.EquipItem(item.equipment);

            
        }

    }
}
