using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerFire : MonoBehaviour
{
    [SerializeField] ParticleSystem[] LaserGuns;
    [SerializeField] RectTransform crosshair;

    bool isFiring;

    void Start()
    {
        Cursor.visible = false;
    }

    void Update()
    {
        ProcessFiring();
        MoveCrosshair();
    }

    public void OnFire(InputValue value)
    {
        isFiring = value.isPressed;
    }

    void ProcessFiring()
    {
        foreach (var laserGun in LaserGuns)
        {
            var emission = laserGun.emission;
            emission.enabled = isFiring;
        }
    }

    void MoveCrosshair()
    {
        Vector2 mousePosition = Mouse.current.position.ReadValue();
        crosshair.position = mousePosition;
    }

}
