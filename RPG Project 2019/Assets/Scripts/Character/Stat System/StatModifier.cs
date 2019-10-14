using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class StatModifier
{
    [SerializeField]
    float value;

    [SerializeField]
    StatName targetStat;

    public StatModifier(float pvalue,  StatName ptarget) {
        value = pvalue;
        targetStat = ptarget;
    }

    public StatName target() {
        return targetStat;
    }

    public float GetValue() {
        return Mathf.Round(value);
    }

    public float Apply() {
        return value;
    }
}
