using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonWeapon : Weapon
{
    IMeleeWeaponStats _weaponStats;
    public override IWeaponStats StatsComponent { get => _weaponStats; protected set => _weaponStats = (IMeleeWeaponStats) value; }
    protected override void AttackImplementation()
    {
        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, 1f, LayerMask.GetMask("Player")))
        {
            hit.collider.GetComponent<IHealthComponent>().Damage(_weaponStats.Damage);
        }
    }
}
