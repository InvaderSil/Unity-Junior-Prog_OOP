using UnityEngine;

namespace Assets.Scripts.Food
{
     public  class Fish : PlatableFood
    {
        public override void DestroySelf()
        {
            Debug.Log("It once swam. Now? Destroyed.");
            base.DestroySelf();
        }

    }
   
}
