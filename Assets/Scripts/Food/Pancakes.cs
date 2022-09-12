using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Food
{
    public class Pancakes : PlatableFood
    {
        public override void DestroySelf()
        {
            Debug.Log("Waffles are superior. Throw this away.");
            base.DestroySelf();
        }
    }
}
