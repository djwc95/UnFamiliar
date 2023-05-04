using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiritStagRandomize : MonoBehaviour
{
    private Animator animator;
    private float speed;
    private float waitTime;
    void Start()
    {
        animator = GetComponent<Animator>();
        var state = animator.GetCurrentAnimatorStateInfo(layerIndex: 0);
        animator.Play(state.fullPathHash, layer: 0, normalizedTime: Random.Range(0f, 1f));
        StartCoroutine(Randomize());
    }

    private IEnumerator Randomize()
    {
        waitTime = Random.Range(1f, 4f);
        speed = Random.Range(0.75f, 1.75f);
        yield return new WaitForSeconds(waitTime);
        animator.speed = speed;
        StartCoroutine(Randomize());
    }
}
