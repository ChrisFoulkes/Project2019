using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[System.Serializable]
public class BasicStatData{
    public float startingvalue;
    public StatName statName;
}

[System.Serializable]
[CreateAssetMenu(fileName = "StatListDataFile", menuName = "Stats Data")]
public class StartingStatData : ScriptableObject
{

    public List<BasicStatData> statList = new List<BasicStatData>();
}

