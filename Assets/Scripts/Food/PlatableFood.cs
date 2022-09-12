using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Assets.Scripts.Food;

public abstract class PlatableFood : MonoBehaviour
{
    [SerializeField] private FoodBase _foodBase;

    public string GetName()
    {
        return _foodBase.GetName();
    }

    public string GetDescription()
    {
        return _foodBase.GetDescription();
    }
        
    public virtual void DestroySelf()
    {
        Destroy(gameObject);
    }

}
