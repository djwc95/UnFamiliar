using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartRunningFox : MonoBehaviour
{
    public MoveAtoB moveAtoB;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            moveAtoB.Move();
        }
    }
}
