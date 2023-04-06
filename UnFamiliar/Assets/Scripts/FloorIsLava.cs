using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorIsLava : MonoBehaviour
{
    public GameObject player;
    public RespawnScript respawnScript;
    public Transform respawnPoint;

    public float timeUntilDeath;
    public float currentTime;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = timeUntilDeath;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentTime <= 0)
        {
            StartCoroutine(respawnScript.DieSlow());
            currentTime = timeUntilDeath;
        }
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            currentTime -= Time.deltaTime;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            currentTime = timeUntilDeath;
        }
    }
}
