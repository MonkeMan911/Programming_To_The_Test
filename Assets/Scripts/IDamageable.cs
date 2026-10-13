using UnityEngine;

interface IDamageable
{
    [SerializeField] int health {set;}
    public void Death() { }
    public void EnemyHealth(int hpAmount) { }
}
