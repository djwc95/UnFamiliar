using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyThis : MonoBehaviour
{
    public void Destroy()
    {
        Destroy(this.gameObject);
        Debug.Log("destroyed");
    }
}
