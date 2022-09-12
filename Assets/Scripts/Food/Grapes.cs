using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Food
{
    public class Grapes : PlatableFood
    {
        public override void DestroySelf()
        {
            Debug.Log("One grape, two grape, three grape, wine. Destorying grapes for wine.");
            base.DestroySelf();
        }
    }
}
