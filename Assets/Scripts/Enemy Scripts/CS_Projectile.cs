using UnityEngine;

public class CS_Projectile : MonoBehaviour
{
    float projectileSpeed = 2;
    Rigidbody rb;
    [SerializeField] Transform ePosition;
    [SerializeField] Vector3 offset;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        transform.rotation = ePosition.rotation;
        transform.position = ePosition.position + Vector3.forward;
    }

    void Update()
    {
        rb.AddForce(Vector3.forward * projectileSpeed);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player")) 
        {
            Destroy(gameObject);
        }
    }
}
