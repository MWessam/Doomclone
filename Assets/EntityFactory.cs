using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityFactory : Factory<Entity>
{
    [SerializeField] private Entity _entityPrefab;
    [SerializeField] private string _entityName;
    protected override void Awake()
    {
        FactoryManager<Entity>.AddFactory(_entityName, this);
    }
    public override Entity GetProduct(Vector3 position)
    {
        GameObject instance = Instantiate(_entityPrefab.gameObject, position, Quaternion.identity);
        Entity product = instance.GetComponent<Entity>();
        return product;
    }
}
