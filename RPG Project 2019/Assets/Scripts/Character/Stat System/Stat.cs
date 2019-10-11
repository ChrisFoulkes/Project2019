using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StatName {
    Strength,
    Agility,
    Intelligence,
    Vitality

}


public class Stat
{

    // Can adjust base value getting to scale with character levels or some other method 
    // SET is currently their but will need to change at somepoint maybe removed all together.

    private float _baseValue;
    public float baseValue {
        get { return _baseValue; }
        set { _baseValue = value; }
    }

    public StatName statName;

    public int Value {
        get {
            if (isDirty) {
                _value = CalcuateFinalValue();
                isDirty = false;
            }
            return _value;
        }

    }

    List<StatModifier> statModifiers;



    public Stat(float basevalue, StatName pstatName) {
        baseValue = basevalue;
        statName = pstatName;
        statModifiers = new List<StatModifier>();
    }
    private bool isDirty = true;

    private int _value;

    public void AddModifier(StatModifier mod) {
        isDirty = true;
        statModifiers.Add(mod);
       
        StatChange statchange = new StatChange(this);
        EventManager.Current.TriggerEvent(statchange);

    }

    public bool RemoveModifier(StatModifier mod) {

        if (statModifiers.Remove(mod))
        {
            isDirty = true;
            StatChange statchange = new StatChange(this);
            EventManager.Current.TriggerEvent(statchange);

        }
        else {
            return false;
        }


        return true;
        

    }

    private int CalcuateFinalValue() {

        float finalvalue = baseValue;
        foreach (StatModifier mod in statModifiers) {
            finalvalue += mod.Apply();
        }

        return Mathf.RoundToInt(finalvalue);
    }
    
}

