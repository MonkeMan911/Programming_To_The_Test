using System.Collections.Generic;
using UnityEngine;

public class CS_Teleport_Behind : MonoBehaviour
{
    [SerializeField] LayerMask tpLayer; //Layer for RayCast and Capsule Overlap
    [SerializeField] float rayLength; // Length for RayCast Ray
    [SerializeField] float capsuleRadius; // Radius for Capsule Overlap
    [SerializeField] Vector3 offset; // offset for RayCast Ray
    [SerializeField] Vector3 tpOffset; // offset for RayCast Ray
    [SerializeField] Transform startPoint; // Start Position for Capsule Overlap
    [SerializeField] Transform endPoint; //End Position for Capsule Overlap
    [SerializeField] Material[] outlineMaterials; //Set of Materials for outlining Enemies
    [SerializeField] Material regularMat; //Just the base material set in the Inspector
    public List<MeshRenderer> outlinedEnemies = new(); //List of MeshRenderers That creates an empty list for the renderers
    public bool highlighted = false; //Bool to only allow the TeleportCheck() function to be run once
    RaycastHit hitInfo; //Tells Unity what the RayCast is Hitting
    [SerializeField] bool tpAble;
    [SerializeField] Transform player;

    private void Start()
    {
        highlighted = false; //Sets the bool to false
    }
    void Update()
    {
        Ray ray = new Ray(this.transform.position + offset, transform.TransformDirection(Vector3.forward)); //Creates a RayCast from the player 
        if (Physics.Raycast(ray, out hitInfo, rayLength, tpLayer)) //if RayCast Hits the desired Layer then execute Below
        {
            Debug.DrawRay(this.transform.position + offset, transform.TransformDirection(Vector3.forward) * hitInfo.distance, Color.green); //Shows Raycast as green in the scene
            if (!highlighted) //if canTp is false then Execute
            {
                HighlightEnemy(); //Runs The Teleport Check Function if the RayCast Hits Enemy Layer and canTp == False
                highlighted = true; //sets to true so it cannot be executed again
            }
            if (tpAble && Input.GetKeyDown(KeyCode.E))
            {
                TeleportBehindEnemy();
            }
        }
        else //if the raycast doesnt hit the desired layer
        {
            Debug.DrawRay(this.transform.position + offset, transform.TransformDirection(Vector3.forward) * hitInfo.distance, Color.red);//Shows Raycast as red in the scene
            UnHighlight(); //Runs the UnHighlight() funtion if the enemy layer is not detected by the Ray
        }
        
    }

    public void HighlightEnemy() //public void can be accessed by multiple scripts
    {
        tpAble = true;
        Collider[] enemyColliders = Physics.OverlapCapsule(startPoint.position, endPoint.position, capsuleRadius, tpLayer); //defines multiple colliders inside a Capsule Overplap that determines whether they are inside/overlapping with the capsule or not
        foreach (Collider collider in enemyColliders) //foreach Collider inside the Overlapp
        {
            MeshRenderer meshRenderer = collider.gameObject.GetComponent<MeshRenderer>(); //get the meshrenderer of that object
            if (meshRenderer != null) //if the meshrenderer is there/active
            {
                meshRenderer.materials = outlineMaterials; //set the mesh renderers materials to the already definded outline materials
                outlinedEnemies.Add(meshRenderer); //then store the meshrenderer inside
            }
        }
    }
    void UnHighlight() //private void can only be accessed by this script
    {
        highlighted = false; //sets the canTp bool back to false so an enemy can be highlighted again once the original highlight has been removed
        tpAble = false;
        foreach (MeshRenderer rend in outlinedEnemies) //foreach Meshrenderer that is defined inside the new list
        {
            if (rend != null) //if the renderer is not null
            {
                Debug.Log("Back to OG"); //sends a messgase to the console so i know what is happening
                Material[] materials = new Material[rend.sharedMaterials.Length]; //creates a set of materials then defines the set as a new set based on the materials already inside the current mesh renderer
                materials[0] = regularMat; //sets the first material to the regular material
                materials[1] = outlineMaterials[0]; //sets the second material to the first material (to remove the outline)
                rend.sharedMaterials = materials; //gets the meshrenderer and sets its materials to the newly defined set
                
            }
        }
        outlinedEnemies.Clear(); //clears the list once the capsule no longer overlaps
    }

    public void TeleportBehindEnemy() 
    {
        Collider[] backCollider = Physics.OverlapCapsule(startPoint.position, endPoint.position, capsuleRadius);
        foreach (Collider col in backCollider)
        {
            CS_Allow_Teleport allow_Teleport = col.GetComponentInChildren<CS_Allow_Teleport>();
            if (allow_Teleport != null)
            {
                Debug.Log("Behind You");
                player.transform.position = col.transform.position + tpOffset;
                player.transform.rotation = col.transform.rotation;
            }
        }
    }
    void OnDrawGizmos()
    {
        if (startPoint == null || endPoint == null) return;
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(startPoint.position, capsuleRadius);
        Gizmos.DrawWireSphere(endPoint.position, capsuleRadius);
    }
}
