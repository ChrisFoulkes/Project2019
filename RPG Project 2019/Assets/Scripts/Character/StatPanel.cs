using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StatPanel : MonoBehaviour
{

    CharacterStats characterStats;

    EventManager eventManager;

    TextMeshProUGUI strValue;


    // Start is called before the first frame update

    Dictionary<Stat, TextMeshProUGUI> statTextValues = new Dictionary<Stat, TextMeshProUGUI>();

    void Start()
    {
        characterStats = FindObjectOfType<CharacterStats>();

        eventManager = FindObjectOfType<EventManager>();

        strValue = transform.Find("StrengthValue").GetComponent<TextMeshProUGUI>();
        strValue.text = characterStats.strength.Value.ToString();

        EventManager.Current.RegisterListener<StatChange>(StatChange);

        statTextValues.Add(characterStats.strength, strValue);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void StatChange(StatChange statChange) {
        if (statTextValues[statChange.Stat] != null)
        {
            TextMeshProUGUI statText = statTextValues[statChange.Stat];
            statText.text = statChange.Stat.Value.ToString();
        }
    }
}
