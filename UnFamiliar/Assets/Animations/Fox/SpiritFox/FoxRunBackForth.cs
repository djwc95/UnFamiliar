using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoxRunBackForth : MonoBehaviour
{
    public MoveABC MoveABC;


    private void Start()
    {
        StartCoroutine(Switch());
    }

    IEnumerator Switch()
    {
        MoveABC.MoveToC();
        yield return new WaitForSeconds(Random.Range(2f, 4.5f));
        MoveABC.MoveToB();
        yield return new WaitForSeconds(Random.Range(2f, 4.5f));
        StartCoroutine(Switch());
    }
}
