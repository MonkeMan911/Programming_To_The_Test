using UnityEngine;
using System.Collections;

public class Energy : MonoBehaviour 
{
    private int maxEnergy = 5;
    [SerializeField] private int currentEnergy;
    public bool outOfEnergy;
    private float cdTime;

    private void Start()
    {
        currentEnergy = maxEnergy;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) 
        {
            EnergyConsumption(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2)) 
        {
            EnergyConsumption(2);
        }

        if (currentEnergy <= 0) 
        {
            outOfEnergy = true;
        }
        if (outOfEnergy) 
        {
            StartCoroutine(SlowRegen());
        }
        if (!outOfEnergy) 
        {
            StopCoroutine(SlowRegen());
        }
    }

    public void EnergyConsumption(int amount) 
    {
        if (!outOfEnergy) 
        {
            currentEnergy -= amount;
        }
        if (outOfEnergy) 
        {
            Debug.Log("You're out of luck Pal");
            return;
        }
        
    }

    IEnumerator SlowRegen() 
    {
        yield return new WaitForSeconds(cdTime);
        currentEnergy += 1;
    }
}
