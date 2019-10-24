using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, ITakeDamage
{

    public EnemyData enemyData;

    public List<Stat> enemyStats = new List<Stat>();

    public float healthPoints;

    SpriteRenderer spriteRenderer;
    BoxCollider2D colliderBox;
    EnemyAttack enemyAttack;
    // Start is called before the first frame update
    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        colliderBox = GetComponent<BoxCollider2D>();

        enemyAttack = GetComponent <EnemyAttack>();

        LoadEnemyData();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadEnemyData() {
        foreach (EnemyStatData statData in enemyData.statList) {
            enemyStats.Add(new Stat(statData.startingvalue, statData.statName));
        }

        enemyAttack.enemyAbilities = enemyData.enemyAbilities;

        healthPoints = enemyData.healthPoints;

        spriteRenderer.sprite = Resources.Load<Sprite>(enemyData.SpritePath);
        colliderBox.size = spriteRenderer.size;
    }

    public void TakeDamage(float damage) {
        healthPoints -= damage;
    }




}
