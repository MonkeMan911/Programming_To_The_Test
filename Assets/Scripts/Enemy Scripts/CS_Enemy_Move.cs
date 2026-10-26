using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class CS_Enemy_Move : MonoBehaviour
{
    [SerializeField] CS_Player_Deal_Damage player_Damage;
    void Start()
    {
        StartCoroutine(LerpLerpLerpSahurPlus());
    }

    void Update()
    {
        if (player_Damage.timeFrozen == true)
        {
            StopAllCoroutines();
        }
        else if (player_Damage.timeFrozen == false)
        {
            StartCoroutine(LerpLerpLerpSahurPlus());
        }
    }

    IEnumerator LerpLerpLerpSahurPlus() 
    {
        Vector3 origin = transform.position;
        Vector3 plusTarget = transform.position + new Vector3(0, 0, 20);

        float currentTime = 0;
        float timeLeft = 5;
        while (currentTime < timeLeft) 
        {
            this.transform.position = Vector3.Lerp(origin, plusTarget, currentTime/timeLeft);
            currentTime += Time.deltaTime;
            yield return null;
        }
        this.transform.position = plusTarget;
        StartCoroutine(LerpLerpLerpSahurMinus());
    }
    IEnumerator LerpLerpLerpSahurMinus() 
    {
        Vector3 origin = transform.position;
        Vector3 minusTarget = transform.position + new Vector3(0, 0, -20);

        float currentTime = 0;
        float timeLeft = 5;
        while (currentTime < timeLeft) 
        {
            this.transform.position = Vector3.Lerp(origin, minusTarget, currentTime/timeLeft);
            currentTime += Time.deltaTime;
            yield return null;
        }
        this.transform.position = minusTarget;
        StartCoroutine(LerpLerpLerpSahurPlus());
    }
}
