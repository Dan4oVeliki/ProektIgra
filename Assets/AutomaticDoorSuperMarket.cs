using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class AutomaticDoorSuperMarket : MonoBehaviour
{
    public Vector3 endPos;
    public float speed;

    private bool moving;
    private bool opening = true;
    private Vector3 startPos;
    private float delay;
    public float HowMuchTime;
    void Start()
    {
        startPos = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if (moving)
        {
            if (opening)
            {
                MoveDoor(endPos);
            }
            else
            {
                MoveDoor(startPos);
            }
        }
    }
    public void MoveDoor(Vector3 goalPos)
    {
        float dist = Vector3.Distance(transform.localPosition, goalPos);
        if (dist > .1f) 
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, goalPos, speed * Time.deltaTime);
        }
        else
        {
            if (opening)
            {
                delay += Time.deltaTime;
                if (delay>HowMuchTime)
                {
                    opening = false;
                }
            }
            else
            {
                moving = false;
                opening= true;
                delay = 0f;
            }
        }
    }
    public bool Moving
    {
        get { return moving; }
        set { moving = value; }
    }
}
