using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlateBase : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _orderIdText;

    private Order _order;

    public delegate void PlateDestroyed(bool isOrderComplete);
    public event PlateDestroyed OnPlateDestoyed;

    public void AddOrder(Order order)
    {
        _order = order;
        _orderIdText.text = order.OrderId;
    }

    private void Update()
    {
        if (!GameManager.Instance.IsGameRunning())
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        PlatableFood food;
        if(other.gameObject.TryGetComponent<PlatableFood>(out food))
        {
            Debug.Log("you got a food on the plate " + food.GetName());
            _order.AddFoundFood(food);

            // This destroys and leaves the food object in tact
            Destroy(other.gameObject);
        }

        if(other.CompareTag("EndBin"))
        {
            OnPlateDestoyed?.Invoke(_order.IsOrderComplete());
            
            //if()
            //{
            //    Debug.Log("We have a winner!!! OrderId: " + _order.OrderId);
            //}

            Destroy(gameObject);
        }
    }
}
