using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Food
{
    public class Meatpatty : PlatableFood
    {
        public override void DestroySelf()
        {
            Debug.Log("Is this even cooked? Anyway, throw it away.");
            base.DestroySelf();
        }
    }
}
