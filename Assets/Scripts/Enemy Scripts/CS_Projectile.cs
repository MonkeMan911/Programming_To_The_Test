using UnityEngine;

public class CS_Projectile : MonoBehaviour
{
    float projectileSpeed;
    Rigidbody rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(Vector3.forward * projectileSpeed);
        float cTime = 0;
        float tTime = 5;
        cTime += Time.deltaTime;
        if (cTime >= tTime) 
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player")) 
        {
            Destroy(gameObject);
        }
    }
}
