using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartFrog : MonoBehaviour
{
    private Animator animator;
    private bool canTrigger;
    public MoveAtoB moveAtoB;
    private float speed;
    private float waitTime;

    private void Start()
    {
        animator = GetComponent<Animator>();
        
    }

    private IEnumerator Randomize()
    {
        waitTime = Random.Range(1f, 4f);
        speed = Random.Range(0.75f, 2.5f);
        var randomRotate = new Vector3(0, Random.Range(-360f, 360f), 0);
        yield return new WaitForSeconds(waitTime);
        transform.Rotate(randomRotate * Time.deltaTime * 25, Space.Self);
        animator.speed = speed;
        StartCoroutine(Randomize());
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            canTrigger= true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            canTrigger = false;
        }
    }

    private void Update()
    {
        if (canTrigger && Input.GetKeyDown(KeyCode.E))
        {
            moveAtoB.Move();
            StartCoroutine(Randomize());
            animator.SetTrigger("StartHopping");
        }
    }
}
