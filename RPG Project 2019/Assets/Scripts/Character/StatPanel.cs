using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StatPanel : MonoBehaviour
{

    CharacterStats characterStats;

    EventManager eventManager;

    TextMeshProUGUI strValue;

    TextMeshProUGUI agiValue;

    // Start is called before the first frame update

    Dictionary<Stat, TextMeshProUGUI> statTextValues = new Dictionary<Stat, TextMeshProUGUI>();

    void Start()
    {
        characterStats = FindObjectOfType<CharacterStats>();

        eventManager = FindObjectOfType<EventManager>();

        strValue = transform.Find("StrengthValue").GetComponent<TextMeshProUGUI>();
        strValue.text = characterStats.statDict[StatName.Strength].Value.ToString();

        agiValue = transform.Find("AgilityValue").GetComponent<TextMeshProUGUI>();
        agiValue.text = characterStats.statDict[StatName.Agility].Value.ToString();


        EventManager.Current.RegisterListener<StatChange>(StatChange);

        statTextValues.Add(characterStats.statDict[StatName.Strength], strValue);
        statTextValues.Add(characterStats.statDict[StatName.Agility], agiValue);
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
