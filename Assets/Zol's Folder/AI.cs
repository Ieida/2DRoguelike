using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    private Animator animator;

    public int moveSpeeed;

    public float checkRadius;
    public float attackRange;

    public LayerMask playerMask;

    public int damage;
    public float timeBtwAttacks;
    private float curTimeBtwAttacks;

    private void Start()
    {
        curTimeBtwAttacks = timeBtwAttacks;
    }

    void Update()
    {
        Collider2D detect = Physics2D.OverlapCircle(transform.position, checkRadius, playerMask);
        Collider2D attackCheck = Physics2D.OverlapCircle(transform.position, attackRange, playerMask);

        if (detect != null)
            ChasePlayer(detect.transform);

        if (attackCheck != null)
            AttackPlayer(attackCheck.gameObject.GetComponent<PlayerStats>());
    }

    public void ChasePlayer(Transform player)
    {
        transform.position = Vector3.MoveTowards(transform.position, player.position, moveSpeeed * Time.deltaTime);
    }

    public void AttackPlayer(PlayerStats player)
    {
        if (curTimeBtwAttacks <= 0)
        {
            player.TakeDamage(damage);
            curTimeBtwAttacks = timeBtwAttacks;
        }
        else
            curTimeBtwAttacks -= Time.deltaTime;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, checkRadius);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
