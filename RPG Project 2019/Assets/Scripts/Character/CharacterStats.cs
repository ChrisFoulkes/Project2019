using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CharacterStats : MonoBehaviour
{

    public Stat strength;

    public GameObject statPanel;

    public StatModifier increaseOne = new StatModifier();

    private void Awake()
    {
        strength = new Stat(3f);

        Debug.Log(strength.Value);
        statPanel = GameObject.Find("Canvas").transform.Find("tempStatPanel").gameObject;
    }
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C)) {
            if (statPanel.activeSelf)
            {
                statPanel.SetActive(false);
            }
            else
            {
                statPanel.SetActive(true);
            }
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            strength.AddModifier(increaseOne);
            PopupText.Instance.GenerateText("Added +1 Strength Modifier!");
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            if (strength.RemoveModifier(increaseOne))
            {
                PopupText.Instance.GenerateText("Removed a +1 Strength Modifier!");
            }
        }
    }
}
