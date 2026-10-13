using UnityEngine;

public class CS_Basic_RayCast : MonoBehaviour
{
    [SerializeField] LayerMask layerMask;
    [SerializeField] float rayLength;
    [SerializeField] Vector3 offset;
    RaycastHit hitInfo;
    void Start()
    {
        
    }

    void Update()
    {
        //RayCasting
        Ray ray = new Ray(this.transform.position + offset, transform.TransformDirection(Vector3.forward));
        if (Physics.Raycast(ray, out hitInfo, rayLength, layerMask))
        {
            Debug.DrawRay(this.transform.position + offset, transform.TransformDirection(Vector3.forward) * hitInfo.distance, Color.green);
        }
        else
        {
            Debug.DrawRay(this.transform.position + offset, transform.TransformDirection(Vector3.forward) * hitInfo.distance, Color.red);
        }
    }
}
