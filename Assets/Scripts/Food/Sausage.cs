using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Food
{
    // INHERITANCE
    public class Sausage : PlatableFood
    {
        // POLYMORPHISM
        public override void DestroySelf()
        {
            Debug.Log("This sausage is garbage!");
            base.DestroySelf();
        }
    }
}
