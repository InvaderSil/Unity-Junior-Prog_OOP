using UnityEngine;

//https://www.youtube.com/watch?v=0yHBDZHLRbQ 
public class DragableObject : MonoBehaviour
{
    private Vector3 _mouseOffset;
    private float _mouseZCoord;

    private void OnMouseDown()
    {
        GetComponent<Rigidbody>().velocity = Vector3.zero;

        _mouseZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;

        _mouseOffset = gameObject.transform.position - GetMouseWorldPos();
    }

    private Vector3 GetMouseWorldPos()
    {
        Vector3 mousePoint = Input.mousePosition;

        mousePoint.z = _mouseZCoord;

        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    private void OnMouseDrag()
    {
        transform.position = GetMouseWorldPos() + _mouseOffset;
    }
}

