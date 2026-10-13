using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CS_Teleport_Behind : MonoBehaviour
{
    [SerializeField] LayerMask tpLayer;
    [SerializeField] float rayLength;
    [SerializeField] float capsuleRadius;
    [SerializeField] Vector3 offset;
    [SerializeField] Transform startPoint;
    [SerializeField] Transform endPoint;
    [SerializeField] Material[] outlineMaterials;
    [SerializeField] Material regularMat;
    public List<MeshRenderer> outlinedEnemies = new();
    RaycastHit hitInfo;

    private void Start()
    {

    }
    void Update()
    {
        Ray ray = new Ray(this.transform.position + offset, transform.TransformDirection(Vector3.forward));
        if (Physics.Raycast(ray, out hitInfo, rayLength, tpLayer))
        {
            Debug.DrawRay(this.transform.position + offset, transform.TransformDirection(Vector3.forward) * hitInfo.distance, Color.green);
            TeleportCheck();
        }
        else
        {
            Debug.DrawRay(this.transform.position + offset, transform.TransformDirection(Vector3.forward) * hitInfo.distance, Color.red);
            UnHighlight();
        }
        
    }

    public void TeleportCheck() 
    {
        Collider[] enemyColliders = Physics.OverlapCapsule(startPoint.position, endPoint.position, capsuleRadius, tpLayer);
        foreach (Collider collider in enemyColliders)
        {
            MeshRenderer meshRenderer = collider.gameObject.GetComponent<MeshRenderer>();
            if (meshRenderer != null)
            {
                meshRenderer.materials = outlineMaterials;
                outlinedEnemies.Add(meshRenderer);
            }
        }
    }
    void UnHighlight() 
    {
        foreach (MeshRenderer rend in outlinedEnemies)
        {
            if (rend != null)
            {
                rend.material = regularMat;
            }
        }
        outlinedEnemies.Clear();
    }
    void OnDrawGizmos()
    {
        if (startPoint == null || endPoint == null) return;
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(startPoint.position, capsuleRadius);
        Gizmos.DrawWireSphere(endPoint.position, capsuleRadius);
    }
}
