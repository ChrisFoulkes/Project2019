using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemContainer : MonoBehaviour, IInteractable
{

    public SpriteRenderer spriteRenderer;

    public Sprite closedSprite;
    public Sprite openedSprite;


    public bool opened = false;


    // list of items etc


    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer.sprite = closedSprite;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void SetActions()
    {
        if (opened) {
            InteractionPanel.Instance.SetAction("Close", Close);
        }
        else
        {
            InteractionPanel.Instance.SetAction("Open", Open);
        }


    }

    public void Open() {
        Debug.Log("Opening Chest");
        spriteRenderer.sprite = openedSprite;
        opened = true;
    }

    public void Close()
    {
        Debug.Log("Closing Chest");
        spriteRenderer.sprite = closedSprite;
        opened = false;
    }

}
