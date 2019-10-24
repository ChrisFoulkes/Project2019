using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public Transform enemyTarget;

    public bool attacking = false;
    bool attackComplete = true;

    public List<EnemyAbilities> enemyAbilities = new List<EnemyAbilities>();


    IEnumerator attackDuration; 

    void Start()
    {
        GameObject targetgo = GameObject.FindGameObjectWithTag("Player");

        enemyTarget = targetgo.transform;
        if (enemyTarget == null)
        {
            Debug.Log("Target not Found!");

        }
    }


    void Update()
    {
        if (attacking) {
            if (attackComplete) {
                Debug.Log("Finish Attack");
                StopCoroutine(attackDuration);
                attacking = false;
            }
        }
    }
    public void TryAttack()
    {
        foreach (EnemyAbilities ability in enemyAbilities)
        {
            if (ability.ConditionCheck(transform, enemyTarget)) {
                Debug.Log("Start Attack");

                attacking = true;
                attackComplete = false;

                attackDuration = AttackDuration(ability.attackDuration);
                StartCoroutine(attackDuration);

                //start animation

                ability.Action(transform, enemyTarget);


                //the order in the list of abilities determines the priority
                break;
             
            }
        }
    }


    IEnumerator AttackDuration(float attackDuration) {
        yield return new WaitForSeconds(attackDuration);

        if (attacking) {
           
            attackComplete = true;
        }
    }
}
