using UnityEngine;

public class CS_Player_Deal_Damage : MonoBehaviour
{
    [SerializeField] LayerMask layerMask;
    [SerializeField] float sphereRadius;
    [SerializeField] int damageAmount;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0)) 
        {
            Attack();
        }
    }
    void Attack() 
    {
        Collider[] hitEnemies = Physics.OverlapSphere(transform.position, sphereRadius, layerMask);
        foreach (Collider collider in hitEnemies)
        {
            IDamageable obj = collider.GetComponent<IDamageable>();
            if (obj != null) 
            {
                obj.EnemyHealth(damageAmount);
            }
        }
    }
}
