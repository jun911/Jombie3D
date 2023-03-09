using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Camera fpsCamera;
    [SerializeField][Range(0,200)] private float range = 100f;

    private void Update()
    {
        WeaponProcessing();
    }

    private void WeaponProcessing()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        RaycastHit hit;
        Physics.Raycast(fpsCamera.transform.position, fpsCamera.transform.forward, out hit, range);

        Debug.Log($"{hit.transform.name} shoot!!");
    }
}