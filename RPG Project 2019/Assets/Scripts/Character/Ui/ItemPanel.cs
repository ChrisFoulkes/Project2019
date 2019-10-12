using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using TMPro;
public class ItemPanel : MonoBehaviour
{

    public bool panelactive = false;
    Image[] images;


    ItemSlot[] itemSlots;

    
    Dictionary<EquipmentType, ItemSlot> equipmentSlotDict = new Dictionary<EquipmentType, ItemSlot>();


    CharacterInventory inventory;


    bool isdirty = false;


    Transform slotHolder;
    Transform textHolder;

    Image panel;
    Image[] slotImages;
    BoxCollider2D[] slotColliders;
    TextMeshProUGUI[] itemTexts;

     // start awake functions not called on a disabled objectes could alter the function to check if images is set but the event listener wouldnt be enabled. 
   
    void Start()
    {
   

        

    }


    // Update is called once per frame
    void Update()
    {
        
    }

    public void Initalize(CharacterInventory pinventory) {
        panel = transform.Find("InventoryPanel").GetComponent<Image>();
        slotHolder = transform.Find("InventoryPanel").transform.Find("ItemUiHolder");
        textHolder = transform.Find("InventoryPanel").transform.Find("ItemTextHolder");

        slotImages = slotHolder.GetComponentsInChildren<Image>();
        slotColliders = slotHolder.GetComponentsInChildren<BoxCollider2D>();

        itemTexts = textHolder.GetComponentsInChildren<TextMeshProUGUI>();


        inventory = pinventory;
        Transform slots = transform.Find("InventoryPanel").Find("ItemUiHolder");


        itemSlots = slots.GetComponentsInChildren<ItemSlot>();

        //listener for item equips 
        EventManager.Current.RegisterListener<ItemEquipped>(UpdateSlot);
        EventManager.Current.RegisterListener<ItemUnequipped>(ClearSlot);

        //creates a dictionary of equipment type to associated slots 
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

    public void EnablePanel()
    {
        panelactive = true;
        panel.enabled = true;

        foreach (Image img in slotImages)
        {
            img.enabled = true;
        }
        foreach (BoxCollider2D col in slotColliders)
        {
            col.enabled = true;
        
        }

        foreach (TextMeshProUGUI text in itemTexts)
        {
            text.enabled = true;
        
        }



        if (isdirty){
            foreach (EquipmentType item in EquipmentType.GetValues(typeof(EquipmentType)))
            {
                if (inventory.GetItemSlot(item) != null)
                {
                    equipmentSlotDict[item].SetItem(inventory.GetItemSlot(item));
                }
            }

            isdirty = false;
        }
    }


    void UpdateSlot(ItemEquipped itemequip) {
        if (gameObject.activeSelf)
        {
            ItemSlot slot = equipmentSlotDict[itemequip.equipment.equipmentType];
            slot.SetItem(itemequip.equipment);
        }
        else {
            isdirty = true;
        }
    }

    
     void ClearSlot(ItemUnequipped item) {
        ItemSlot slot = equipmentSlotDict[item.equipment.equipmentType];
        slot.SetDefault();
        // create a remove item event script 
    }

    public void DisablePanel()
    {
        panelactive = false;
        panel.enabled = false;
        foreach (Image img in slotImages) {
            img.enabled = false;
        }
        foreach (BoxCollider2D col in slotColliders)
        {
            col.enabled = false;
        }

        foreach (TextMeshProUGUI text in itemTexts)
        {
            text.enabled = false;
        }

    }

 

}
