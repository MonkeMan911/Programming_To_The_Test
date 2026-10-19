using UnityEngine;
using System.Collections;

public class CS_Player_Deal_Damage : MonoBehaviour
{
    [SerializeField] LayerMask layerMask;
    [SerializeField] float sphereRadius;
    [SerializeField] int damageAmount;
    [SerializeField] int damageStacks = 1;
    [SerializeField] public bool timeFrozen;

    private void Start()
    {
        damageStacks = 1;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0)) 
        {
            Attack();
        }
        if (timeFrozen && Input.GetKeyDown(KeyCode.Mouse0)) 
        {
            damageStacks++;
        }
        if (damageStacks >= 2 && !timeFrozen) 
        {
            StartCoroutine(DamageStackApply());
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
                obj.EnemyHealth(damageAmount * damageStacks);
            }
        }
    }

    IEnumerator DamageStackApply() 
    {
        Attack();
        yield return new WaitForSeconds(1);
        damageStacks = 1;
    }
}
