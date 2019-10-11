using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class ItemPanel : MonoBehaviour
{


    Image[] images;


    public ItemSlot[] itemSlots;


    Dictionary<EquipmentType, ItemSlot> equipmentSlotDict = new Dictionary<EquipmentType, ItemSlot>();


    CharacterInventory inventory;

    bool isdirty = false;
    // Start is called before the first frame update


    
     // start awake functions not called on a disabled objectes could alter the function to check if images is set but the event listener wouldnt be enabled. 
   
    void Start()
    {
      

    }
 

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Initalize(CharacterInventory pinventory) {



        inventory = pinventory;
        Transform slots = transform.Find("ItemUiHolder");


        itemSlots = slots.GetComponentsInChildren<ItemSlot>();

      
        EventManager.Current.RegisterListener<ItemEquipped>(UpdateSlot);


        int counter = 0;
        foreach (EquipmentType item in EquipmentType.GetValues(typeof(EquipmentType)))
        {

            if (counter == itemSlots.Length)
            {
                Debug.Log("Inventory image slots is missing an equipment type!");
                break;
            }
      
            equipmentSlotDict.Add(item, itemSlots[counter]);

            counter++;
        }


    }

    public void OnEnable()
    {
        if (isdirty){
            foreach (EquipmentType item in EquipmentType.GetValues(typeof(EquipmentType)))
            {
                if (inventory.GetItemSlot(item) != null)
                {
                    equipmentSlotDict[item].EquipItem(inventory.GetItemSlot(item));
                }
            }

            isdirty = false;
        }
    }


    void UpdateSlot(ItemEquipped itemequip) {
        if (gameObject.activeSelf)
        {
            ItemSlot slot = equipmentSlotDict[itemequip.equipment.equipmentType];
            slot.EquipItem(itemequip.equipment);
        }
        else {
            isdirty = true;
        }
    }

}
