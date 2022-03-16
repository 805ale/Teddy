using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterStats))]
public class CharacterCombat : MonoBehaviour
{
    CharacterStats myStats;
    CharacterStats EnemyStats;
    public float attackSpeed = 1f;
    public float attackCooldown = 0f;
    public float attackDelay = .6f;

    public event System.Action OnAttack; //special delegate

    // Start is called before the first frame update
    void Start()
    {
        myStats = GetComponent<CharacterStats>();
    }
    void Update()
    {
        attackCooldown -= Time.deltaTime;
    }

    // Update is called once per frame
    public void Attack(CharacterStats enemyStats)
    {
        if (attackCooldown <= 0f) 
        {
            StartCoroutine(DoDamage(enemyStats, attackDelay));
            if (OnAttack != null)
                OnAttack();

            attackCooldown = 1f / attackSpeed;
        }
    }

    IEnumerator DoDamage(CharacterStats stats, float delay)
    {
        myStats.currentStamina -= 10f;
        yield return new WaitForSeconds(delay);
        stats.TakeDamage(myStats.damage.GetValue());
    }
}
