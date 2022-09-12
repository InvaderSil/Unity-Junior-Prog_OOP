using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Food
{
    [CreateAssetMenu(fileName = "FoodSO", menuName = "SO/Food")]
    public class FoodBase : ScriptableObject
    {
        public string _description;
        public string _name;

        public string GetDescription()
        {
            return _description;
        }

        public string GetName()
        {
            return _name;
        }
    }
}
