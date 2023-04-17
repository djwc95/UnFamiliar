using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothFallingPlatform : MonoBehaviour
{
    [SerializeField] private GameObject objectToAttach;

    public GameObject GetObjectToAttach()
    {
        return objectToAttach;
    }

    public void SetObjectToAttach(GameObject objectToAttach)
    {
        this.objectToAttach = objectToAttach;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            objectToAttach.transform.SetParent(this.transform);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            objectToAttach.transform.parent = null;
        }
    }
}
