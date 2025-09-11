using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] ParticleSystem explosionEffect;
    void OnTriggerEnter(Collider other)
    {
        Instantiate(explosionEffect, transform.position, transform.rotation);
        Destroy(this.gameObject);
    }
}
