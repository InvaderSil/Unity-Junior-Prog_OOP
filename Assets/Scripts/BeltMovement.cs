using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeltMovement : MonoBehaviour
{
    [SerializeField] private float _forwardSpeed;

    
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * _forwardSpeed * Time.deltaTime);
        
    }
}
