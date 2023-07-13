using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntitySpawner : MonoBehaviour
{
    [SerializeField] Entity _entity;
    [SerializeField] string _entityName;
    [SerializeField] int _amountToSpawn;
    [SerializeField] float _spawnTime;
    [SerializeField] bool _canSpawnAfterEntityDeathOnly;        // Long ass var name but basically it's to ensure that you either spawn entities regardless of their state or wait till one dies to spawn the next.
    // TRUE = Wait for entity to die to spawn (i.e event invoke only) FALSE = just spawn them regardless
    //BUG: It will always spawn one extra after the first one dies. 
    [SerializeField] bool _infiniteSpawner = false;
    private float _elapsedTimeSinceSpawn = 0;
    private Entity _lastEntity;
    void Start()
    {
        Spawn();
        _lastEntity.HealthComponent.OnDeath += EntityFreeToSpawn;
    }

    // Update is called once per frame
    void Update()
    {
        if (CanSpawn() && !_canSpawnAfterEntityDeathOnly && (_amountToSpawn > 0 || _infiniteSpawner))
        {
            _elapsedTimeSinceSpawn = 0;
            Spawn();
        }
        if (_amountToSpawn == 0 && !_infiniteSpawner)
        {
            gameObject.SetActive(false);
        }
    }
    bool CanSpawn()
    {
        _elapsedTimeSinceSpawn += Time.deltaTime;
        return _elapsedTimeSinceSpawn >= _spawnTime;
    }
    void EntityFreeToSpawn()
    {
        _lastEntity.HealthComponent.OnDeath -= EntityFreeToSpawn;
        if (_amountToSpawn > 0)
            Spawn();
    }
    protected void Spawn()
    {
        _amountToSpawn--;
        _lastEntity = FactoryManager<Entity>.GetFactory(_entityName).GetProduct(transform.position);
        _lastEntity.HealthComponent.OnDeath += EntityFreeToSpawn;
    }
}
