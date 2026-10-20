using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Energy : MonoBehaviour 
{
    [SerializeField] Slider energySlider;
    private int maxEnergy = 5;
    [SerializeField] private int currentEnergy;
    public bool outOfEnergy;
    [SerializeField] private float cdTime = 1;
    public bool regenEnergy;

    private void Start()
    {
        currentEnergy = maxEnergy;
        energySlider.value = currentEnergy;
    }
    private void Update()
    {
        energySlider.value = currentEnergy;

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
            AddEnergy();
        }
        if (!outOfEnergy) 
        {
            regenEnergy = false;
            StopAllCoroutines();
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
    public void AddEnergy() 
    {
        if (!regenEnergy) 
        {
            StartCoroutine(SlowRegen());
        }
    }

    IEnumerator SlowRegen() 
    {
        regenEnergy = true;
        int targetEnergy = currentEnergy + 5;
        while (currentEnergy < targetEnergy) 
        {
            currentEnergy++;
            yield return new WaitForSeconds(cdTime);
        }
        regenEnergy = false;
    }
}
