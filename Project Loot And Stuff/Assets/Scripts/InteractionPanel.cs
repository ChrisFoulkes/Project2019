using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionPanel : MonoBehaviour
{
    public static InteractionPanel Instance { get; private set; }


    public RectTransform rect;
      
    // Start is called before the first frame update



    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.LogWarning("Multiple InteractionPanels instances warning destorying self!!!");

            Destroy(gameObject);
        }

    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    public void SetPosition()
    {
        Debug.Log(rect.sizeDelta.y);
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x + rect.sizeDelta.x/2, Input.mousePosition.y - rect.sizeDelta.y / 2, 0f));
        transform.position = mousePos;
    }

    public void Enabled(bool value)
    {
        gameObject.SetActive(value);
    }
}
