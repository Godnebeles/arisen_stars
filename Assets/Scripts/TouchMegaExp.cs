using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TouchMegaExp : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler
{
    private float _lastTimeClick;
    private const float DOUBLE_CLICK_TIME = 1f;

    private int _pointerId;
    private bool _isTouched;
    private bool _canFire;

    public TouchMegaExp()
    {
        _isTouched = false;
    }

    public void OnPointerDown(PointerEventData eventData)
    {


    }


    public void OnPointerUp(PointerEventData eventData)
    {

    }

    public bool CanFire()
    {
        return _canFire;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        float currentTimeClick = eventData.clickTime;
        float timeSinceLastClick = Time.time - _lastTimeClick;

        if (currentTimeClick - _lastTimeClick <= DOUBLE_CLICK_TIME)
        {
            _canFire = true;
        }
        else
        {
            _canFire = false;
        }

        _lastTimeClick = Time.time;
    }
}
