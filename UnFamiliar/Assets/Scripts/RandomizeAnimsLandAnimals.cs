using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomizeAnimsLandAnimals : MonoBehaviour
{
    private Animator animator;
    private float speed;
    private float waitTime;
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
        waitTime = Random.Range(1f, 4f);
        speed = Random.Range(0.75f, 2.5f);
        var randomRotate = new Vector3(0, Random.Range(0f, 360f), 0);
        yield return new WaitForSeconds(waitTime);
        transform.Rotate(randomRotate * Time.deltaTime, Space.Self);
        animator.speed = speed;
        StartCoroutine(Randomize());
    }
}
