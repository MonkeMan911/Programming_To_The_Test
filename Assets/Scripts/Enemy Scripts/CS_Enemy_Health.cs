using UnityEngine;

public class CS_Enemy_Health : MonoBehaviour, IDamageable
{
    public int health {get; set;}
    public CS_Player_Deal_Damage damage;

    private void Start()
    {
        health = 100;
    }
    public void EnemyHealth(int hpAmount) 
    {
        health -= hpAmount;
        Debug.Log("Damage" + hpAmount);
        if (health <= 0 && damage.timeFrozen == false) 
        {
            Death();
        }
    }
    public void Death() 
    {
       GameObject.Destroy(gameObject);
    }
}
