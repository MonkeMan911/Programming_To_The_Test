using UnityEngine;

public class CS_Enemy_Stare : MonoBehaviour
{
    [SerializeField] Transform iris1;
    [SerializeField] Transform iris2;
    [SerializeField] Transform pupil1;
    [SerializeField] Transform pupil2;
    [SerializeField] Transform player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        iris1.transform.LookAt(player);
        pupil1.transform.LookAt(player);
        iris2.transform.LookAt(player);
        pupil2.transform.LookAt(player);
    }
}
