using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Food
{
    public class Hotdog : PlatableFood
    {
        public override void DestroySelf()
        {
            Debug.Log("Costco hot dogs are still the best value.");
            base.DestroySelf();
        }
    }
}
