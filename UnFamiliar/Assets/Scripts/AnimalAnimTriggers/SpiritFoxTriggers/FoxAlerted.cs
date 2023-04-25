using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoxAlerted : MonoBehaviour
{
    public Animator foxAnimator;
    public PlayerMovement2 pm2;
    public MoveAtoB moveAtoB;
    // Start is called before the first frame update
    void Start()
    {
        foxAnimator.SetTrigger("StandIdle");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            foxAnimator.SetTrigger("Spotted");
            pm2.LockMovement();
            StartCoroutine(WaitAndRun());
        }
    }

    IEnumerator WaitAndRun()
    {
        yield return new WaitForSeconds(5f);
        moveAtoB.Move();
        yield return new WaitForSeconds(2.25f);
        Destroy(this.gameObject);
        pm2.UnLockMovement();
    }
}
