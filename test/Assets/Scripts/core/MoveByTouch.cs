using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveByTouch : MonoBehaviour
{
    public Player player;
    private Vector2 startPosition;
    private bool fingerDown;
    //public float movmentSpeed = 2f;
    public int pixelsDistToDetect = 7;
    //Start is called before the first frame update
    //void Start()
    //{
    //    player = gameObject.GetComponent<playerController>();
    //}

    // Update is called once per frame
    void Update()
    {
        //if (fingerDown == false && Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        //{
        //    startPosition = Input.touches[0].position;
        //    fingerDown = true;
        //}

        //if (fingerDown)
        //{
        //    if (Input.touches[0].position.x >= startPosition.x + pixelsDistToDetect)
        //    {
        //        fingerDown = false;
        //        //player.Move(Vector3.right);
        //        Debug.Log("Swipe right");
        //    }

        //    if (Input.touches[0].position.x <= startPosition.x - pixelsDistToDetect)
        //    {
        //        fingerDown = false;
        //        //player.Move(Vector3.left);
        //        Debug.Log("Swipe left");
        //    }
        //}




        // Testing for PC
        if (fingerDown == false && Input.GetMouseButton(0))
        {
            startPosition = Input.mousePosition;
            fingerDown = true;
        }

        if(fingerDown)
        {
            if(Input.mousePosition.x >= startPosition.x + pixelsDistToDetect)
            {
                fingerDown = false;
                //Debug.Log("Swipe Right");
                //Debug.Log(Input.mousePosition.x);
                player.Move(Vector3.right);
            }

            if (Input.mousePosition.x <= startPosition.x - pixelsDistToDetect)
            {
                fingerDown = false;
                //Debug.Log("Swipe Left");
                //Debug.Log(Input.mousePosition.x);
                player.Move(Vector3.left);
            }
        }

    }
}
