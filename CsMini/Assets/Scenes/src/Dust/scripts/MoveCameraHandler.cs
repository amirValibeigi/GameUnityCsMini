using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MoveCameraHandler : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{

    [HideInInspector]
    public bool isMove;

    [HideInInspector]
    public Vector2 position = new Vector2(0, 0);


    [HideInInspector]
    Vector2 lastPosition;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.touchCount > 0 && isMove)
        {
            Touch touch = Input.GetTouch(0);
            if (lastPosition.x != int.MaxValue && lastPosition.y != int.MaxValue)
            {
                position = new Vector2(touch.position.x - lastPosition.x, touch.position.y - lastPosition.y);
            }
            lastPosition = touch.position;
        }
        else
        {
            lastPosition = new Vector2(int.MaxValue, int.MaxValue);
            position = new Vector2(0, 0);
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isMove = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isMove = false;
    }
}
