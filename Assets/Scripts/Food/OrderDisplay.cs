using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Assets.Scripts.Food;

public class OrderDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _orderText;

    private string _orderIndex;
    public void SetOrderText(string orderIndex, List<PlatableFood> foodList)
    {
        _orderIndex = orderIndex;

        string combinedText = orderIndex;

        foreach (var item in foodList)
        {
            combinedText += $", {item.GetName()}";
        }

        _orderText.text = combinedText;

    }

    public void DestorySelf(bool isComplete)
    {
        Destroy(gameObject);
    }

}
