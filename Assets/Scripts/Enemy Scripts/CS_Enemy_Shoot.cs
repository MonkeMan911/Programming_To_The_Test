using System.Collections;
using UnityEngine;

public class CS_Enemy_Shoot : MonoBehaviour
{
    [SerializeField] GameObject prefab;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator ShootCoroutine()
    {
        float currentTime = 0;
        float targetTime = 2;
        while (currentTime < targetTime)
        {
            currentTime += Time.deltaTime;
            yield return null;
        }
        Instantiate(prefab);
    }
        
}
