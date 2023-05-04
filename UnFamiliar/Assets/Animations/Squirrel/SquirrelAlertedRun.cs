using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquirrelAlertedRun : MonoBehaviour
{
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator= GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            animator.SetTrigger("Alerted");
            StartCoroutine(DestroyAfterTime());
        }
    }

    IEnumerator DestroyAfterTime()
    {
        yield return new WaitForSeconds(10f);
        Destroy(this.gameObject);
    }
}
