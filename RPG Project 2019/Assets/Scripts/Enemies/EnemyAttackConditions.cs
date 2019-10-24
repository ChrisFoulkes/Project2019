using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyAttackConditions : ScriptableObject
{
    public virtual bool CheckCondition(Transform self, Transform target)
    {
        return false;
    }
}


[CreateAssetMenu(fileName = "RangedCondition", menuName = "EnemyConditions/RangedAttack")]

public class RangedAttackCondition : EnemyAttackConditions
{
    public float range = 4f;

    public override bool CheckCondition(Transform self, Transform target) {

        if (Vector3.Distance(self.position, target.position) <= range)
        {
            return true;
        }
        else {
            return false; 
        }
    }
}