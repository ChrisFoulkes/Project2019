using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum EnemyAbilityType {
    Hitbox, 
    Ranged 
}

[System.Serializable]
[CreateAssetMenu(fileName = "EAbility", menuName = "EnemyAbility")]

public class EnemyAbilities : ScriptableObject
{

    public string attackName;
    public string animation;
    public float attackDuration = 2f;

    public EnemyAbilityType abilityType;

    public List<EnemyAttackConditions> attackConditions = new List<EnemyAttackConditions>();

    public List<EnemyAbilityBehaviours> attackBehaviours = new List<EnemyAbilityBehaviours>();


    public bool ConditionCheck(Transform self, Transform target)
    {
        bool conditions = true;
        foreach (EnemyAttackConditions condition in attackConditions)
        {
            if (!condition.CheckCondition(self, target))
            {
                conditions = false;
                break;
            }
        }

        if (conditions)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    // need to replace this with an action scriptable object system loaded from the data
    public void Action(Transform self, Transform target)
    {
        foreach (EnemyAbilityBehaviours behaviour in attackBehaviours)
        {
            behaviour.Action(self);
        }
    }
}
