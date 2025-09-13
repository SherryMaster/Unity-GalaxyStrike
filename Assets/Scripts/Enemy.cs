using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject explosionVFX;
    [SerializeField] int HitPoints = 5;
    
    void OnParticleCollision(GameObject other)
    {
        HitPoints -= 1;
        if (HitPoints <= 0)
        {
            Instantiate(explosionVFX, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
