using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorIsLava : MonoBehaviour
{
    public RespawnScript respawnScript;

    public bool canFlash = true;
    public float timeUntilDeath;
    public float currentTime;
    public Material rascalMat;
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
            if (canFlash == true)
            {
                Debug.Log("flashing");
                StartCoroutine(FlashRed());
                canFlash= false;
            }
        }
    }

    public IEnumerator FlashRed()
    {
        rascalMat.color = Color.red;
        yield return new WaitForSeconds(.15f);
        rascalMat.color = Color.black;
        yield return new WaitForSeconds(.15f);
        canFlash= true;
    }
}
