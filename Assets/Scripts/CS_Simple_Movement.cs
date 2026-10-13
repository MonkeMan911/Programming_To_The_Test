using UnityEngine;

public class CS_Simple_Movement : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] float hSpeed;
    [SerializeField] float vSpeed;
    [SerializeField] float jumpHeight;
    [SerializeField] bool canMove;
    [SerializeField] bool canJump;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //Movement
        float x = Input.GetAxis("Horizontal") * hSpeed;
        float z = Input.GetAxis("Vertical") * vSpeed;

        x *= Time.deltaTime;
        z *= Time.deltaTime;

        if (canMove) 
        {
            transform.Translate(x, 0, z);
        }

        if (canJump) 
        {
            rb.AddForce(Vector3.up * jumpHeight);
        }
    }
}
