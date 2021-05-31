using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{
    public Animator animator;

    public Transform attackPoint1;
    public float attackRange = 0.2f;
    public LayerMask enemyLayers;
    GameObject finalCovidError;
    GameManager gameManager;
    public SFXScript sfx;
    private void Awake()
    {
        finalCovidError = GameObject.FindGameObjectWithTag("FinalCovidError");
        if (finalCovidError != null)
            finalCovidError.SetActive(false);
    }
    public void Attack()
    {
        animator.SetTrigger("Attack");
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint1.position, attackRange, enemyLayers);

        foreach (Collider2D enemy in hitEnemies)
        {
            if (enemy.tag == "FinalCovid")
            {
                if (GameObject.FindGameObjectsWithTag("Covid").Length > 0)
                {
                    ErrorMessageStart();
                }
                else if (GameObject.FindGameObjectsWithTag("Covid").Length == 0)
                {
                    enemy.GetComponent<CovidHealth>().TakeDamage(1);
                    sfx.SwordHitWallPlay();
                }
            }
            else if(enemy.tag == "Covid")
            {
                enemy.GetComponent<CovidHealth>().TakeDamage(1);
                sfx.SwordHitWallPlay();
            }
            else if(enemy.tag == "Bricks")
            {
                sfx.SwordHitWallPlay();
            }
            else
            {
                sfx.SwordSwingPlay();
            }
        }
    }
    private void ErrorMessageStart()
    {
        finalCovidError.SetActive(true);
        Invoke("ErrorMessageEnd", 2f);
    }
    private void ErrorMessageEnd()
    {
        finalCovidError.SetActive(false);
    }
}
