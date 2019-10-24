using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class EnemyAbilityBehaviours : ScriptableObject
{
    public virtual void Action(Transform parent) { 
        
    }
}

[CreateAssetMenu(fileName = "AbilityBehaviour", menuName = "EnemyBehaviour/Basic Projectile")]
public class BasicProjectile : EnemyAbilityBehaviours {
    public GameObject projectile;

    public override void Action(Transform parent) {

        GameObject go = Instantiate(projectile);
        go.transform.position = parent.position;


    }
}

