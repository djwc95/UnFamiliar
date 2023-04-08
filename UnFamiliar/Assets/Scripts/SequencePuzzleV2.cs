using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

public class SequencePuzzleV2 : MonoBehaviour
{
    public DestroyThis destroyThis;
    private int buttonsPushed = 0;

    public List<int> correctSequence = new List<int>();
    public List<int> currentSequence = new();

    public AudioClip[] chime;

    public GameObject switch1;
    public GameObject switch2;
    public GameObject switch3;

    public Transform position1;
    public Transform position2;
    public Transform position3;
    public Transform position4;
    public Transform position5;

    public GameObject rune1;
    public GameObject rune2;
    public GameObject rune3;
    public GameObject particles;

    [SerializeField] private Animator gate = null;

    void Update()
    {
        if (currentSequence.SequenceEqual(correctSequence)) //do the sequences match?
        {
            gate.Play("OpenGate", 0, 0f);
        }
        else if (buttonsPushed >= 5) //reset puzzle after we pushed all buttons
        {
            destroyThis.Destroy();
            buttonsPushed = 0;
            currentSequence.Clear();
        }
    }

    public void Button1()
    {
        currentSequence.Add(1); //just the num that corresponds with symbol (left to right in unity panel)
        buttonsPushed++;

        if (buttonsPushed == 1)
        {
            Instantiate(rune1, position1.position, position1.rotation);
            Instantiate(particles, position1.position, position1.rotation);
        }
        else if (buttonsPushed == 2)
        {
            Instantiate(rune1, position2.position, position2.rotation);
            Instantiate(particles, position2.position, position2.rotation);
        }
        else if (buttonsPushed == 3)
        {
            Instantiate(rune1, position3.position, position3.rotation);
            Instantiate(particles, position3.position, position3.rotation);
        }
        else if (buttonsPushed == 4)
        {
            Instantiate(rune1, position4.position, position4.rotation);
            Instantiate(particles, position4.position, position4.rotation);
        }
        else if (buttonsPushed == 5)
        {
            Instantiate(rune1, position5.position, position5.rotation);
            Instantiate(particles, position5.position, position5.rotation);
        }
    }

    public void Button2()
    {
        currentSequence.Add(2); //just the num that corresponds with symbol (left to right in unity panel)
        buttonsPushed++;
        if (buttonsPushed == 1)
        {
            Instantiate(rune2, position1.position, position1.rotation);
            Instantiate(particles, position1.position, position1.rotation);
        }
        else if (buttonsPushed == 2)
        {
            Instantiate(rune2, position2.position, position2.rotation);
            Instantiate(particles, position2.position, position2.rotation);
        }
        else if (buttonsPushed == 3)
        {
            Instantiate(rune2, position3.position, position3.rotation);
            Instantiate(particles, position3.position, position3.rotation);
        }
        else if (buttonsPushed == 4)
        {
            Instantiate(rune2, position4.position, position4.rotation);
            Instantiate(particles, position4.position, position4.rotation);
        }
        else if (buttonsPushed == 5)
        {
            Instantiate(rune2, position5.position, position5.rotation);
            Instantiate(particles, position5.position, position5.rotation);
        }
    }

    public void Button3()
    {
        currentSequence.Add(3); //just the num that corresponds with symbol (left to right in unity panel)
        buttonsPushed++;

        if (buttonsPushed == 1)
        {
            Instantiate(rune3, position1.position, position1.rotation);
            Instantiate(particles, position1.position, position1.rotation);
        }
        else if (buttonsPushed == 2)
        {
            Instantiate(rune3, position2.position, position2.rotation);
            Instantiate(particles, position2.position, position2.rotation);
        }
        else if (buttonsPushed == 3)
        {
            Instantiate(rune3, position3.position, position3.rotation);
            Instantiate(particles, position3.position, position3.rotation);
        }
        else if (buttonsPushed == 4)
        {
            Instantiate(rune3, position4.position, position4.rotation);
            Instantiate(particles, position4.position, position4.rotation);
        }
        else if (buttonsPushed == 5)
        {
            Instantiate(rune3, position5.position, position5.rotation);
            Instantiate(particles, position5.position, position5.rotation);
        }
    }
}
