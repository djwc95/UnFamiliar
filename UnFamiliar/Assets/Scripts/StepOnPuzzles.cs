using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepOnPuzzles : MonoBehaviour
{
    public SequencePuzzleV2 puzzleV2;

    private bool canClick = true;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Button1" && Input.GetKey(KeyCode.E))
        {
            if (!canClick)
            {
                return;
            }
            else if (canClick)
            {
                puzzleV2.Button1();
                canClick = false;
                StartCoroutine(Timeout());
            }
        }
        if (other.gameObject.tag == "Button2" && Input.GetKey(KeyCode.E))
        {
            if (!canClick)
            {
                return;
            }
            else if (canClick)
            {
                puzzleV2.Button2();
                canClick = false;
                StartCoroutine(Timeout());
            }
        }
        if (other.gameObject.tag == "Button3" && Input.GetKey(KeyCode.E))
        {
            if (!canClick)
            {
                return;
            }
            else if (canClick)
            {
                puzzleV2.Button3();
                canClick = false;
                StartCoroutine(Timeout());
            }
        }
    }

    private IEnumerator Timeout()
    {
        yield return new WaitForSeconds(.75f);
        canClick= true;
    }
}
