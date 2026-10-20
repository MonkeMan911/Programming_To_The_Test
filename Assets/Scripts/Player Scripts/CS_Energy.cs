using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Energy : MonoBehaviour 
{
    [SerializeField] Slider energySlider; // Visual Slider represents energy levels on the screen for the player
    private int maxEnergy = 5; //maximum amount of energy
    [SerializeField] private int currentEnergy;//current amount of energy
    public bool outOfEnergy;//bool called "Out Of Energy"
    [SerializeField] private float cdTime = 1;//number given the value 1 called cdTime (Cooldown time)
    private bool regenEnergy;//bool called "regen Energy"

    private void Start() //anything inside is called on the moment the scene starts
    {
        currentEnergy = maxEnergy; //current energy value is the same as the max value
        energySlider.value = currentEnergy; //The energy slider visual shows the current energy
    }
    private void Update()//anything inside is checked every frame while the scene is being played
    {
        energySlider.value = currentEnergy; //The energy slider visual shows the current energy

        if (Input.GetKeyDown(KeyCode.Alpha1)) //(Test Input) Checks if the number 1 key has been pressed
        {
            EnergyConsumption(1); //Calls the Energy Consumption Function with the number 1 inside its parameters 
        }
        if (Input.GetKeyDown(KeyCode.Alpha2)) //(Test Input) Checks if the number 2 key has been pressed
        {
            EnergyConsumption(2); //Calls the Energy Consumption Function with the number 2 inside its parameters
        }

        if (currentEnergy <= 0) //if the current energy is less than or equal to 0
        {
            outOfEnergy = true; //out of Energy bool becomes true
        }
        if (currentEnergy > maxEnergy) //if the current Energy is greater than the max energy
        {
            currentEnergy = maxEnergy; //sets the current energy to the max energy to stop it from giving the player extra energy
            outOfEnergy = false; //out of energy bool becomes false
        }
        if (outOfEnergy) //if the out of energy bool becomes true
        {
            AddEnergy(); //Call the Add Energy Function
        }
        if (!outOfEnergy) //if the out of energy bool becomes false
        {
            regenEnergy = false; //regen Energy bool becomes true
            StopAllCoroutines(); //Stop all of the coroutines which are basically timed routines (this stop the energy from regening)
        }
    }

    public void EnergyConsumption(int amount) //function that takes an integer in its parameters when referenced
    {
        if (!outOfEnergy) //if the out of energy bool becomes false
        {
            currentEnergy -= amount; //take away the integer specified inside the parameters of the function from the current Energy
        }
        if (outOfEnergy) //if the out of energy bool becomes true
        {
            energySlider.value = currentEnergy;
            Debug.Log("You're out of luck Pal"); //Send a message to the console
            return; //return means sends a message to the script saying this is a deadend (so nothing happens) this is to stop the player from spending energy they dont have
        }

    }
    public void AddEnergy() //function Called AddEnergy
    {
        if (!regenEnergy) //if regen energy bool becomes false
        {
            StartCoroutine(SlowRegen()); //starts the Slow regen coroutine if the regen energy is false
        }
    }

    IEnumerator SlowRegen() //coroutine allows things to happen over a certain amount of frames instead of every frame like in Update()
    {
        regenEnergy = true; //regen energy bool becomes true
        int targetEnergy = currentEnergy + 5; // creates and integer that is equal to the current energy plus 5 and is called target Energy
        while (currentEnergy < targetEnergy) //while the target energy is greater than the current energy repeat the lines of code inside
        {
            currentEnergy++; //current Energy plus 1
            yield return new WaitForSeconds(cdTime); //create a new delay where the coroutine waits for amount of seconds in this case the amount of seconds is the "cdTime" float
        }
        regenEnergy = false;// regen energy bool becomes false again to end the coroutine
    }
    //IEnumerator SlowRegen() OLD CODE DIDN'T WORK
    //{
    // yield return new WaitForSeconds(cdTime);
    // currentEnergy++;
    //}
}
