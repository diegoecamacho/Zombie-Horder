using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AK47Component : WeaponComponent
{
    private Vector3 hitLocation;

    protected override void FireWeapon()
    {
        if (weaponStats.bulletsInClip > 0 && !reloading && !weaponHolder.controller.isRunning)
        {
            base.FireWeapon();

            if(!firingEffect)
            {
                firingEffect = Instantiate(firingAnimation, particleSpawnLocation).GetComponent<ParticleSystem>();
            }
            
            Ray screenRay = mainCamera.ScreenPointToRay(new Vector3(crosshair.CurrentAimPosition.x, crosshair.CurrentAimPosition.y, 0));

            if (Physics.Raycast(screenRay, out RaycastHit hit, weaponStats.fireDistance, weaponStats.weaponHitLayer))
            {
                hitLocation = hit.point;
                Vector3 hitDirection = hit.point - mainCamera.transform.position;

                TakeDamage(hit);

                Debug.DrawRay(mainCamera.transform.position, hitDirection.normalized * weaponStats.fireDistance, Color.red);
            }
        }
        else if (weaponStats.bulletsInClip <= 0)
        {
            if (!weaponHolder)
                return;

            weaponHolder.StartReloading();
        }
    }

    private void TakeDamage(RaycastHit hitInfo)
    {
        IDamageable damageable = hitInfo.collider.GetComponent<IDamageable>();

        damageable?.TakeDamage(weaponStats.damage);
    }

    private void OnDrawGizmos()
    {
        if(hitLocation != Vector3.zero)
        {
            Gizmos.DrawWireSphere(hitLocation, 0.2f);
        }
    }
}
