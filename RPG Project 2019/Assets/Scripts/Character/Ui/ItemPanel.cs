using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ItemPanel : MonoBehaviour
{


    Image[] images;


    public ItemSlot[] itemSlots;


    Dictionary<EquipmentType, ItemSlot> equipmentSlotDict = new Dictionary<EquipmentType, ItemSlot>();

    // Start is called before the first frame update



     // start awake functions not called on a disabled objectes could alter the function to check if images is set but the event listener wouldnt be enabled. 
   
    void Start()
    {
        Transform slots = transform.Find("ItemUiHolder");


        itemSlots = slots.GetComponentsInChildren<ItemSlot>();
      


        int counter = 0;
        foreach (EquipmentType item in EquipmentType.GetValues(typeof(EquipmentType)))
        {

            if (counter > itemSlots.Length) {
                break;
            }

            equipmentSlotDict.Add(item, itemSlots[counter]);

            counter++;
        }

    

        EventManager.Current.RegisterListener<ItemEquipped>(UpdateSlot);

        gameObject.SetActive(false);

    }
 

    // Update is called once per frame
    void Update()
    {
        
    }

    void UpdateSlot(ItemEquipped itemequip) {
        ItemSlot slot = equipmentSlotDict[itemequip.equipment.equipmentType];
        slot.EquipItem(itemequip.equipment);
    }

}
