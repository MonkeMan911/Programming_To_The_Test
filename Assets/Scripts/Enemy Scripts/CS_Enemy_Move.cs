using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class CS_Enemy_Move : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(LerpLerpLerpSahurPlus());
    }

    // Update is called once per frame
    void Update()
    {

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
