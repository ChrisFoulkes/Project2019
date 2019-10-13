using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour, Iinteractable
{
    public Equipment equipment;
    public ItemGenerationData generationData;
    // Start is called before the first frame update
    void Start()
    {
        if (generationData == null)
        {
            Debug.LogWarning(this.name + " Missing item Generation Data!");
        }
        else
        {
            equipment = generationData.GenerateItem();
        }


    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Interact(GameObject interacter)
    {


        if (!interacter.GetComponent<CharacterInventory>().CheckEmptySlot(equipment.equipmentType)){
            equipment = generationData.GenerateItem();
   
        }
        else {
            if (equipment != null)
            {
                interacter.GetComponent<CharacterInventory>().EquipItem(equipment);
            }
        }

    }
}
