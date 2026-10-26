using UnityEngine;

public class CS_Projectile_Death_Timer : MonoBehaviour
{
    [SerializeField] float currentTime;
    [SerializeField] float maxTime;
    void Start()
    {
        currentTime = 0;
    }

    void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime >= maxTime) 
        {
            currentTime = 0;
            Destroy(gameObject);
        }
    }
}
