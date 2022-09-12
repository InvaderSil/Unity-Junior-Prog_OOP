using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Food;

public class OrderManager : MonoBehaviour
{
    [SerializeField] private GameObject _layoutContainer;
    [SerializeField] private GameObject _orderItemPrefab;
    [SerializeField] private BeltManager _beltManager;
    [SerializeField] private float _plateSpawnRate;

    [SerializeField] private BoxCollider _spawningArea;

    [SerializeField] private List<PlatableFood> _foodItemPrefabs;
    [SerializeField] private float _foodSpawnRate;

    [SerializeField] private List<Order> _orders = new List<Order>();

    private float _minXSpawn;
    private float _maxXSpawn;
    private float _minZSpawn;
    private float _maxZSpawn;
    private float _YSpawn;

    // Start is called before the first frame update
    void Start()
    {
        GetSpawnLimits();
        StartCoroutine(SpawnPlate());
        StartCoroutine(SpawnFood());
        
    }
  
    private void SpawnFoodItem()
    {
        float randX = Random.Range(_minXSpawn, _maxXSpawn);
        float randZ = Random.Range(_minZSpawn, _maxZSpawn);

        Vector3 randLoc = new Vector3(randX, _YSpawn, randZ);

        int foodIndex = Random.Range(0, _foodItemPrefabs.Count);
        //Debug.Log(foodIndex);

        Instantiate(_foodItemPrefabs[foodIndex], randLoc, _foodItemPrefabs[foodIndex].transform.rotation);
    }

    private void GetSpawnLimits()
    {
        Bounds spawnArea = _spawningArea.bounds;
        _maxXSpawn = spawnArea.max.x;
        _minXSpawn = spawnArea.min.x;
        _maxZSpawn = spawnArea.max.z;
        _minZSpawn = spawnArea.min.z;
        _YSpawn = spawnArea.min.y;
                
    }

    private GameObject SpawnOrderItem(Order order)
    {
        var orderItem = Instantiate(_orderItemPrefab);
        orderItem.transform.parent = _layoutContainer.transform;
        orderItem.GetComponent<OrderDisplay>().SetOrderText(order.OrderId, order.GetItems());

        return orderItem;
    }

    private Order CreateOrder()
    {
        // first get a random size for the order 1-3
        int orderSize = Random.Range(1, 2);

        Order newOrder = new Order();
        for (int i = 0; i < orderSize; i++)
        {
            // Then get a random selection of items to put into order
            int randomItem = Random.Range(0, _foodItemPrefabs.Count);
            
            newOrder.AddItem(_foodItemPrefabs[randomItem]);
        }

        return newOrder;
    }

   
    public void AddOrder(Order order)
    {
        _orders.Add(order);
    }

    private IEnumerator SpawnPlate()
    {
        int orderNumber = 0;

        while(GameManager.Instance.IsGameRunning())
        {
            orderNumber++;
            yield return new WaitForSeconds(_plateSpawnRate);

            var order = CreateOrder();
            order.OrderId = orderNumber.ToString();
            _beltManager.SpawnAPlateOnBelt(order, SpawnOrderItem(order));

        }
    }

    private IEnumerator SpawnFood()
    {
        while(GameManager.Instance.IsGameRunning())
        {
            SpawnFoodItem();
            yield return new WaitForSeconds(_foodSpawnRate);
          
        }
    }
}
