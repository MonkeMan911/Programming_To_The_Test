using System.Collections;
using UnityEngine;

public class CS_Enemy_Shoot : MonoBehaviour
{
    [SerializeField] GameObject prefab;
    [SerializeField] CS_Player_Deal_Damage player_Damage;
    void Start()
    {
        StartCoroutine(ShootCoroutine());
    }

    void Update()
    {
       
    }
    IEnumerator ShootCoroutine()
    {
        if (player_Damage.timeFrozen == false)
        {
            yield return null;
            float currentTime = 0;
            float targetTime = 2;
            while (currentTime < targetTime)
            {
                currentTime += Time.deltaTime;
                yield return null;
            }
            Instantiate(prefab);
            StartCoroutine(ShootCoroutine());
            yield return null;
        }
    }
        
}
