﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatModifier
{
    float value;

    public StatName targetStat;
    public StatModifier(float pvalue,  StatName ptarget) {
        value = pvalue;
        targetStat = ptarget;
    }

    public StatName target() {
        return targetStat;
    }
  

    public float Apply() {
        return value;
    }
}
