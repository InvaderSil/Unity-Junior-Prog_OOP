using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Food
{
    public class Sandwich : PlatableFood
    {
        public override void DestroySelf()
        {
            Debug.Log("This app hasn't been made fun. Just eat this sandwich.");
            base.DestroySelf();
        }
    }
}
