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


    public void Action()
    {
        Debug.Log("Opening Chest");
        spriteRenderer.sprite = openedSprite;
        opened = false;

    }


}
