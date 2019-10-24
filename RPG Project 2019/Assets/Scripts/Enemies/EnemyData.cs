using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemyStatData
{
    public float startingvalue;
    public StatName statName;
}

public enum EnemyType {
    Basic
}


[System.Serializable]
[CreateAssetMenu(fileName = "Enemies", menuName = "Enemy Data")]
public class EnemyData : ScriptableObject
{

    public string Name;

    public string SpritePath;

    public string animatorPath;

    public EnemyType enemyType;

    public float healthPoints; 
   
    public List<EnemyStatData> statList = new List<EnemyStatData>();

    public List<EnemyAbilities> enemyAbilities = new List<EnemyAbilities>();

}

