using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface IHealthComponent
{
    public event Action OnHealthChange;
    public event Action OnDeath;
    float Health { get; set; }
    void Heal(float health);
    void Damage(float damage);
}
public interface IMovementComponent
{
    float Speed { get; set; }
    void Move();
}
public interface ILookComponent
{
    Transform ParentTransform { get; }
    void Look(Transform target);
}
public interface IGraphicsComponent
{
    AnimatorOverrideController AnimatorController { get; }
    Animator Animator { get; }
    void StartDeathAnimation();
}
public interface IWeaponComponent
{
    IWeapon Weapon { get; }
}

public interface IEntity
{
    IHealthComponent HealthComponent { get; }

}
public interface ICharacterEntity
{
    ILookComponent LookComponent { get; }
    IMovementComponent MovementComponent { get; }
    IWeaponComponent WeaponComponent { get; }
}