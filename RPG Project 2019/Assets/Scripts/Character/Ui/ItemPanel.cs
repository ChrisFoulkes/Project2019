using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ItemPanel : MonoBehaviour
{


    Image[] images;

    Dictionary<EquipmentType, Image> equipmentSlotDict = new Dictionary<EquipmentType, Image>();

    // Start is called before the first frame update
    void Start()
    {

        Transform itemslots = transform.Find("ItemSlots");
        images = itemslots.GetComponentsInChildren<Image>();


        int counter = 0;
        foreach (EquipmentType item in EquipmentType.GetValues(typeof(EquipmentType)))
        {
            equipmentSlotDict.Add(item, images[counter]);
        }


        EventManager.Current.RegisterListener<ItemEquipped>(AddIcon);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void AddIcon(ItemEquipped itemequip) {
        Debug.Log("Called!");
        Image image = equipmentSlotDict[itemequip.equipment.equipmentType];
        Sprite icon = Resources.Load<Sprite>(itemequip.equipment.icon);
        
        image.overrideSprite = icon;
    }

    void RemoveIcon() {
        //need to impliment 
    }
}
