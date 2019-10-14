using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemPopup : MonoBehaviour
{

    public static ItemPopup Instance { get; private set; }

    GameObject headerPanel;

    TextMeshProUGUI itemName;
    Image itemImage;

    GameObject textContainer;

    GameObject prefabText;
    GameObject prefabFooterPanel;

    public Equipment item;
    // Start is called before the first frame update

    private void Awake()
    {
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Debug.LogWarning("Multiple PopupText instances warning destorying self!!!");

                Destroy(gameObject);
            }
        }
    }
    void Start()
    {
        headerPanel = transform.Find("HeaderPanel").gameObject;
        textContainer = transform.Find("TextBoxContainer").gameObject;
       
        prefabText = (GameObject) Resources.Load("Prefabs/TextBackground");
        prefabFooterPanel = (GameObject)Resources.Load("Prefabs/FooterPanel");

        itemImage = headerPanel.transform.Find("ItemIcon").gameObject.GetComponent<Image>();
        itemName = headerPanel.transform.Find("ItemNameText").gameObject.GetComponent<TextMeshProUGUI>();
    }

 

    public void LoadItem(Equipment pequipment) {
        headerPanel.SetActive(true);

        itemName.text = pequipment.name;
        itemImage.sprite = Resources.Load<Sprite>(pequipment.icon);

        foreach (StatModifier mod in pequipment.GetStatModifiers()) {
            GameObject go = Instantiate(prefabText, textContainer.transform);
            TextMeshProUGUI textvalue = go.GetComponentInChildren<TextMeshProUGUI>();
            textvalue.text =  mod.target().ToString() + " : " + mod.GetValue().ToString();
        }

        Instantiate(prefabFooterPanel, textContainer.transform);
    }


    public void DisableItemPopup() {
        foreach (Transform child in textContainer.transform) {
            //this could probably be done better with object pooling
            GameObject.Destroy(child.gameObject);
        }

        headerPanel.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
