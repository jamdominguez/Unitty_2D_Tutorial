using UnityEngine;

public class MeleeEnemy : MonoBehaviour
{
    private int hp = 10;    

    public void TakeDamage(int damage) {        
        hp -= damage;
        if (hp < 0) hp = 0; // no negative hp
        Debug.Log("damage:" + damage + " hp:" + hp);
        // Verify if is dead
        if (hp == 0) Die();
    }

    public void Die() {
        Debug.Log("Die! " + name);
        // Animation Die        
        GetComponent<Animator>().SetBool("isDead", true);
    }

    public void DestroyMeleeEnemy()
    {
        Destroy(gameObject);
    }
}