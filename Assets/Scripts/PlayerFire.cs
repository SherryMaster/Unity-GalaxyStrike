using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerFire : MonoBehaviour
{
    [SerializeField] GameObject[] LaserGuns;
    [SerializeField] RectTransform crosshair;
    [SerializeField] Transform targetPoint;
    [SerializeField] float targetDistance = 250f;

    bool isFiring;

    void Start()
    {
        Cursor.visible = false;
    }

    void Update()
    {
        ProcessFiring();
        MoveCrosshair();
        MoveTargetPoint();
        AimLasers();
    }

    public void OnFire(InputValue value)
    {
        isFiring = value.isPressed;
    }

    void ProcessFiring()
    {
        foreach (var laserGun in LaserGuns)
        {
            var emission = laserGun.GetComponent<ParticleSystem>().emission;
            emission.enabled = isFiring;
        }
    }

    void MoveCrosshair()
    {
        Vector2 mousePosition = Mouse.current.position.ReadValue();
        crosshair.position = mousePosition;
    }

    void MoveTargetPoint()
    {
        Vector3 targetPointPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, targetDistance);
        targetPoint.position = Camera.main.ScreenToWorldPoint(targetPointPosition);
    }

    void AimLasers(){
        foreach(GameObject laserGun in LaserGuns)
        {
            Vector3 direction = targetPoint.position - this.transform.position;
            Quaternion rotationToTarget = Quaternion.LookRotation(direction);
            laserGun.transform.rotation = rotationToTarget;
        }
    }

}
