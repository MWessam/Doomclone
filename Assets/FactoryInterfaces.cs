using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Factory<T> : MonoBehaviour
{
    protected abstract void Awake();
    public abstract T GetProduct(Vector3 position);
}
