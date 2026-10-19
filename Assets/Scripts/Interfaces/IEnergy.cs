using UnityEngine;

public class Energy : MonoBehaviour 
{
    private int maxEnergy;
    private int currentEnergy;
    public bool outOfEnergy;

    private void Start()
    {
        currentEnergy = maxEnergy;
    }
    private void Update()
    {
        if (currentEnergy <= 0) 
        {
            outOfEnergy = true;
        }
    }

    void EnergyConsumption(int amount) 
    {
        if (!outOfEnergy) 
        {
            currentEnergy -= amount;
        }
    }
}
