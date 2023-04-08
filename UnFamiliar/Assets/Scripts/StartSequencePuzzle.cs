using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSequencePuzzle : MonoBehaviour
{
    public GameObject sequencePuzzlePanel;

    void Start()
    {
        sequencePuzzlePanel = GameObject.Find("SequencePuzzle"); //set the panel that will pop up
        sequencePuzzlePanel.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            sequencePuzzlePanel.SetActive(true); //when we step on button, puzzle overlay appears
        }
    }

    private void OnTriggerExit(Collider other)
    {
        sequencePuzzlePanel.SetActive(false);
    }
}
