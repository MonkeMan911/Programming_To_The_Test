using UnityEngine;
using System.Collections;

public class Energy : MonoBehaviour 
{
    private int maxEnergy = 5;
    [SerializeField] private int currentEnergy;
    public bool outOfEnergy;
    [SerializeField] private float cdTime = 1;
    private bool regenEnergy;

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
        if (currentEnergy > maxEnergy) 
        {
            currentEnergy = maxEnergy;
            outOfEnergy = false;
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
        currentEnergy++;
    }
}
