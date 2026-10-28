using UnityEngine;

public class CS_Time_Frozen : MonoBehaviour
{
    [SerializeField] CS_Player_Deal_Damage playerDamageScript;
    [SerializeField] CS_Energy energy;
    [SerializeField] Animator animator;
    [SerializeField] Animator rotateAnimator;
    [SerializeField] GameObject mainGameOb;
    [SerializeField] GameObject pannel;
    [SerializeField] private float currentAmountOfTimeFrozen;
    [SerializeField] private float maxAmountOfTimeFrozen;
    bool allowedTimeFreeze = true;
    void Start()
    {
        mainGameOb.SetActive(false);
        allowedTimeFreeze = true;
    }
    void Update()
    {
        bool oOE = energy.outOfEnergy;
        if (Input.GetKeyDown(KeyCode.T) && allowedTimeFreeze && !oOE) 
        {
            energy.EnergyConsumption(3);
            playerDamageScript.timeFrozen = true;
            animator.SetBool("Resume Time", false);
            allowedTimeFreeze = false;
        }
        if (playerDamageScript.timeFrozen) 
        {
            mainGameOb.SetActive(true);
            pannel.SetActive(true);
            rotateAnimator.speed = 0;
        }
        if (playerDamageScript != null && playerDamageScript.timeFrozen == false)
        { 
            animator.SetBool("Resume Time", true);
            pannel.SetActive(false);
            rotateAnimator.speed = 1;
        }
        if (playerDamageScript.timeFrozen) 
        {
            currentAmountOfTimeFrozen += Time.deltaTime;
        }
        if (currentAmountOfTimeFrozen >= maxAmountOfTimeFrozen && playerDamageScript.timeFrozen) 
        {
            playerDamageScript.timeFrozen = false;
            allowedTimeFreeze = true;
        }
        if (playerDamageScript.timeFrozen == false) 
        {
            currentAmountOfTimeFrozen = 0;
        }
    }


}
