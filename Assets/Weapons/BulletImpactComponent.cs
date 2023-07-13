using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletImpactComponent : MonoBehaviour, IBulletImpact
{
    [SerializeField] GameObject bulletImpact;
    public GameObject CreateImpact()
    {
        return bulletImpact;
    }
}
