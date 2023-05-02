using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveListenerWithRascal : MonoBehaviour
{
    public GameObject Rascal;
    public GameObject Listener;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Listener.transform.position = Rascal.transform.position;
    }
}
