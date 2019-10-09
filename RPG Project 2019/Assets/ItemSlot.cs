using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



[System.Serializable]
public class ItemSlot : MonoBehaviour
{
    [SerializeField]
    Equipment equipped;

    bool empty = true;

    Image itemImage;
    // Start is called before the first frame update
    void Start()
    {
        itemImage = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EquipItem(Equipment equipment) {
        empty = false;
        equipped = equipment;
        itemImage.sprite = Resources.Load<Sprite>(equipped.icon);
    }

    public void RemoveItem() {

        //need to add a confirmation box window system 

        if (empty == false)
        {
            PopupText.Instance.GenerateText("Item DELETED! + " + equipped.name);
            equipped = null;
            empty = true;
            itemImage.sprite = null;
        }
    }

    public void OnMouseDown()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0)){
 
            RemoveItem();
           
        }
       
    }
}
