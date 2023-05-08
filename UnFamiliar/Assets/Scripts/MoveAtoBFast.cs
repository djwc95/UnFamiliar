using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAtoBFast : MonoBehaviour
{
    public GameObject pointA;
    public GameObject pointB;
    public float speed = 5;

    public bool moveToB;
    public bool stayStill = false;

    // Start is called before the first frame update
    void Start()
    {
        this.transform.position = pointA.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (stayStill)
        {
            moveToB = false;
            //do whatever needs to be done while not moving
        }
        else if (moveToB)
        {
            stayStill = false;
            var step = speed * Time.deltaTime; // calculate distance to move
            transform.position = Vector3.MoveTowards(transform.position, pointB.transform.position, step);
        }
        else
        {
            stayStill = false;
            moveToB = false;
            var step = speed * Time.deltaTime; // calculate distance to move
            transform.position = Vector3.MoveTowards(transform.position, pointA.transform.position, step);
        }
    }

    public void MoveFast()
    {
        stayStill = false;
        moveToB = true;
    }

    public void StopMovingFast()
    {
        stayStill = true;
        moveToB = false;
    }
}