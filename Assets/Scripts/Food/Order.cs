using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro;
using Assets.Scripts.Food;

public class Order : MonoBehaviour
{
    

    private List<PlatableFood> foodList = new List<PlatableFood>();
    private List<PlatableFood> completedList = new List<PlatableFood>();

    public string OrderId { get; set; }

  
    public List<PlatableFood> GetItems()
    {
        return foodList;
    }

    public bool IsInOrder(PlatableFood food)
    {
        return foodList.Contains(food, new FoodComparer());
        
    }

    public bool IsOrderComplete()
    {
        if(foodList.Count != completedList.Count)
        {
            return false;
        }

        bool isEqual = foodList.SequenceEqual<PlatableFood>(completedList, new FoodComparer());

        if(isEqual)
        {
            GameManager.Instance.AddScore();
        }

        return isEqual;
    }
    public void AddFoundFood(PlatableFood food)
    {
        if(IsInOrder(food))
        {
            completedList.Add(food);
            Debug.Log(food.GetName() + " was added!");
        }
        else
        {
            Debug.Log(food.GetName() + " is not a part of this order.");
        }
    }

    public void AddItem(PlatableFood foodItem)
    {
        foodList.Add(foodItem);
    }
}
