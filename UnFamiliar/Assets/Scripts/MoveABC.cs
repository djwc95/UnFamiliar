using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveABC : MonoBehaviour
{
    public GameObject pointA;
    public GameObject pointB;
    public GameObject pointC;
    public float speed = 5;

    public bool moveToB;
    public bool moveToC;
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
            moveToC= false;
            //do whatever needs to be done while not moving
        }
        else if (moveToB)
        {
            stayStill = false;
            moveToB = true;
            moveToC = false;
            var step = speed * Time.deltaTime; // calculate distance to move
            transform.position = Vector3.MoveTowards(transform.position, pointB.transform.position, step);
        }
        else if (moveToC)
        {
            stayStill = false;
            moveToB = false;
            moveToC = true;
            var step = speed * Time.deltaTime; // calculate distance to move
            transform.position = Vector3.MoveTowards(transform.position, pointC.transform.position, step);
        }
    }

    public void MoveToB()
    {
        stayStill = false;
        moveToB = true;
        moveToC= false;
    }
    public void MoveToC()
    {
        stayStill = false;
        moveToB = false;
        moveToC = true;
    }

    public void StopMoving()
    {
        stayStill = true;
        moveToB = false;
    }
}
