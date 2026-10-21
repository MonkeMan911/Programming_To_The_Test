using UnityEngine;

public class CS_Time_Frozen : MonoBehaviour
{
    [SerializeField] CS_Player_Deal_Damage playerDamageScript;
    [SerializeField] Animator animator;
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
        if (Input.GetKeyDown(KeyCode.T) && allowedTimeFreeze) 
        {
            playerDamageScript.timeFrozen = true;
            animator.SetBool("Resume Time", false);
            allowedTimeFreeze = false;
        }
        if (playerDamageScript.timeFrozen) 
        {
            mainGameOb.SetActive(true);
            pannel.SetActive(true);
        }
        if (playerDamageScript != null && playerDamageScript.timeFrozen == false)
        { 
            animator.SetBool("Resume Time", true);
            pannel.SetActive(false);
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
