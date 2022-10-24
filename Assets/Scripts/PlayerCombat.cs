using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Transform attackPoint;
    public float attackRange = 1.2f;
    public LayerMask enemyLayers;
    public int attackDamage = 10;

    public float attackRate = 2f; //attacks per second
    private float nextAttack = 0f;

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextAttack) {
            // Hit
            if (Input.GetKeyDown(KeyCode.K))
            {
                Attack();
                nextAttack = Time.time + 1 / attackRate;
            }
        }
    }

    private void Attack()
    {
        // Play Attack Animation
        GetComponent<Animator>().SetTrigger("attack");

        // Detect enemies in attack range
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        // Damage them
        foreach (Collider2D enemy in hitEnemies) {
            //Debug.Log("Hit enemy: " + enemy.name);
            enemy.GetComponent<MeleeEnemy>().TakeDamage(attackDamage);
        }
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null) return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
