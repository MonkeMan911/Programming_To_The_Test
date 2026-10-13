using UnityEngine;

public class CS_Enemy_Health : MonoBehaviour, IDamageable
{
    public int health {get; set;}

    private void Start()
    {
        health = 100;
    }
    public void EnemyHealth(int hpAmount) 
    {
        health -= hpAmount;
        Debug.Log("Damage" + hpAmount);
        if (health <= 0) 
        {
            Death();
        }
    }
    public void Death() 
    {
       GameObject.Destroy(gameObject);
    }
}
