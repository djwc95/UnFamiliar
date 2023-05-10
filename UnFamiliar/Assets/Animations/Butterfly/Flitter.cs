using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flitter : MonoBehaviour
{
    private Animator animator;
    //private float speed;
    private float waitTime;
    public float minTimeRange;
    public float maxTimeRange;
    public float minRotationRange;
    public float maxRotationRange;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        var state = animator.GetCurrentAnimatorStateInfo(layerIndex: 0);
        animator.Play(state.fullPathHash, layer: 0, normalizedTime: Random.Range(0f, 1f));
        StartCoroutine(Randomize());
    }

    private IEnumerator Randomize()
    {
        waitTime = Random.Range(minTimeRange, maxTimeRange);
        // speed = Random.Range(0.75f, 2.5f);
        var randomRotate = new Vector3(Random.Range(minRotationRange, maxRotationRange), Random.Range(minRotationRange, maxRotationRange), Random.Range(minRotationRange, maxRotationRange));
        yield return new WaitForSeconds(waitTime);
        transform.Rotate(randomRotate * Time.deltaTime * 20, Space.Self);
        //animator.speed = speed;
        StartCoroutine(Randomize());
    }
}
