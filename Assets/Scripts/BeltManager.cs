using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeltManager : MonoBehaviour
{
    [SerializeField] private Transform _beltPusherSpawnPoint;
    [SerializeField] private GameObject _platePrefab;
        
    public void SpawnAPlateOnBelt(Order order, GameObject orderItem)
    {

        if (GameManager.Instance.IsGameRunning())
        {
            var plate = Instantiate(_platePrefab, _beltPusherSpawnPoint.position, _platePrefab.transform.rotation);
            plate.GetComponent<PlateBase>().AddOrder(order);
            plate.GetComponent<PlateBase>().OnPlateDestoyed += orderItem.GetComponent<OrderDisplay>().DestorySelf;
        }
    }



}
