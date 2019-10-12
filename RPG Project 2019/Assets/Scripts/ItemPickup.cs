using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour, Iinteractable
{

    public Equipment equipment;

    
    // Start is called before the first frame update
    void Start()
    {
        if (equipment == null) {
            gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 0f, 0f);
        }
    }


    public void Interact(GameObject interacter)
    {
        CharacterInventory charinventory = interacter.GetComponent<CharacterInventory>();

        if (!charinventory.CheckEmptySlot(EquipmentType.Helm))
        {
                 charinventory.RemoveItem(EquipmentType.Helm);
        }
        else {
            PopupText.Instance.GenerateText("Grrrr no shiny for me to steal!");
        }

    }
}
