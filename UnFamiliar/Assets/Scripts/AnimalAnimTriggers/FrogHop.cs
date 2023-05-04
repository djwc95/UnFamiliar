using System.Collections;
using UnityEngine;

public class FrogHop : MonoBehaviour
{
    public MoveAtoB moveAtoB;
    private Animator animator;
    private float speed;
    private float waitTime;

    private void Start()
    {
        animator = GetComponent<Animator>();
        moveAtoB.Move();
        StartCoroutine(Randomize());
    }

    private IEnumerator Randomize()
    {
        waitTime = Random.Range(1f, 4f);
        speed = Random.Range(0.75f, 2.5f);
        var randomRotate = new Vector3(0, Random.Range(-360f, 360f), 0);
        yield return new WaitForSeconds(waitTime);
        transform.Rotate(randomRotate * Time.deltaTime * 25, Space.Self);
        Debug.Log("rotating");
        animator.speed = speed;
        StartCoroutine(Randomize());
    }
}
