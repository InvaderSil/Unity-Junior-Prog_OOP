using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Food
{
    public class Fries : PlatableFood
    {
        public override void DestroySelf()
        {
            Debug.Log("Look. In/out fries are garbage. Like this object.");
            base.DestroySelf();
        }
    }
}
