using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))] 
public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int maxHitPoints = 5;

    [Tooltip("Adds amoun to max hit points when enemy dies.")]
    [SerializeField] int difficultyRamp = 1;
    
    int currentHitpoints = 0;
    
    Enemy enemy;

    void OnEnable()
    {
        currentHitpoints = maxHitPoints;
    }

    void Start() 
    {
        enemy = GetComponent<Enemy>();
    }

    void OnParticleCollision(GameObject other) 
    {
        ProccessHit();
    }

    void ProccessHit()
    {
        currentHitpoints--;

        if (currentHitpoints <= 0)
        {
            KillEnemy();
            maxHitPoints += difficultyRamp;
            enemy.RewardGold();
        }
    }

    void KillEnemy()
    {
        gameObject.SetActive(false);
    }
}