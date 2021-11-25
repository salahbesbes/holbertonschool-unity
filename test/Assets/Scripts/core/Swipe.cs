using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swipe : MonoBehaviour
{
    private bool tap, swipeLeft, swipeRight;
    private Vector2 startTouch, swipeDelta;

    private void update()
    {
        tap = swipeLeft = swipeRight = false;

        #region Standalone Inputs
        if (Input.GetMouseButtonDown(0))
        {
            tap = true;
            startTouch = Input.mousePosition;
        }
        else if (Input.GetMouseButtonDown(0))
        {
            reset();
        }
        #endregion

        #region Mobile Inputs
        if (Input.touches.Length > 0)
        {
            if (Input.touches[0].phase == TouchPhase.Began)
            {
                tap = true;
                startTouch = Input.touches[0].position;
            }
            else if (Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
            { 
                reset();
            }
        }
        #endregion
    }

    private void reset()
    {
        startTouch = swipeDelta = Vector2.zero;
    }
    
    public Vector2 SwipeDelta { get { return swipeDelta; } }
    public bool SwipeLeft { get { return swipeLeft;  } }
    public bool SwipeRight { get { return swipeRight;  } }
}