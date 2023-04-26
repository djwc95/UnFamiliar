using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

public class SequencePuzzleV2 : MonoBehaviour
{
    public OpenGate openGate;
    private int buttonsPushed = 0;

    public List<int> correctSequence = new List<int>();
    public List<int> currentSequence = new();

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
    private GameObject destroyRune1; //destroy each rune
    private GameObject destroyRune2;
    private GameObject destroyRune3;
    private GameObject destroyRune4;
    private GameObject destroyRune5;

    public GameObject particles;
    private GameObject destroyParticles1;
    private GameObject destroyParticles2;
    private GameObject destroyParticles3;
    private GameObject destroyParticles4;
    private GameObject destroyParticles5;

    public AudioClip failSound;
    public AudioClip passSound;
    public AudioClip stoneDragging;
    public AudioSource audioSource;

    private bool canWin = true;
    private bool canInteract = true;

    [SerializeField] private Animator gate = null;

    void Update()
    {
        if (!canInteract)
        {
            return;
        }
        if (currentSequence.SequenceEqual(correctSequence)) //do the sequences match?
        {
            PuzzleWon();
            canWin= false;
            canInteract= false;

        }
        else if (buttonsPushed >= 5) //reset puzzle after we pushed all buttons
        {
            StartCoroutine(ResetRunes());
            openGate.Shake();
            audioSource.PlayOneShot(failSound, 0.7f);
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
            destroyRune1 =  Instantiate(rune1, position1.position, position1.rotation);
            destroyParticles1 = Instantiate(particles, position1.position, position1.rotation);
        }
        else if (buttonsPushed == 2)
        {
            destroyRune2 = Instantiate(rune1, position2.position, position2.rotation);
            destroyParticles2 = Instantiate(particles, position2.position, position2.rotation);
        }
        else if (buttonsPushed == 3)
        {
            destroyRune3 = Instantiate(rune1, position3.position, position3.rotation);
            destroyParticles3 = Instantiate(particles, position3.position, position3.rotation);
        }
        else if (buttonsPushed == 4)
        {
            destroyRune4 = Instantiate(rune1, position4.position, position4.rotation);
            destroyParticles4 = Instantiate(particles, position4.position, position4.rotation);
        }
        else if (buttonsPushed == 5)
        {
            destroyRune5 = Instantiate(rune1, position5.position, position5.rotation);
            destroyParticles5 = Instantiate(particles, position5.position, position5.rotation);
        }
    }

    public void Button2()
    {
        currentSequence.Add(2); //just the num that corresponds with symbol (left to right in unity panel)
        buttonsPushed++;
        if (buttonsPushed == 1)
        {
            destroyRune1 = Instantiate(rune2, position1.position, position1.rotation);
            destroyParticles1 = Instantiate(particles, position1.position, position1.rotation);
        }
        else if (buttonsPushed == 2)
        {
            destroyRune2 = Instantiate(rune2, position2.position, position2.rotation);
            destroyParticles2 = Instantiate(particles, position2.position, position2.rotation);
        }
        else if (buttonsPushed == 3)
        {
            destroyRune3 = Instantiate(rune2, position3.position, position3.rotation);
            destroyParticles3 = Instantiate(particles, position3.position, position3.rotation);
        }
        else if (buttonsPushed == 4)
        {
           destroyRune4 = Instantiate(rune2, position4.position, position4.rotation);
           destroyParticles4 = Instantiate(particles, position4.position, position4.rotation);
        }
        else if (buttonsPushed == 5)
        {
            destroyRune5 = Instantiate(rune2, position5.position, position5.rotation);
            destroyParticles5 = Instantiate(particles, position5.position, position5.rotation);
        }
    }

    public void Button3()
    {
        currentSequence.Add(3); //just the num that corresponds with symbol (left to right in unity panel)
        buttonsPushed++;

        if (buttonsPushed == 1)
        {
            destroyRune1 = Instantiate(rune3, position1.position, position1.rotation);
            destroyParticles1 = Instantiate(particles, position1.position, position1.rotation);
        }
        else if (buttonsPushed == 2)
        {
            destroyRune2 = Instantiate(rune3, position2.position, position2.rotation);
            destroyParticles2 = Instantiate(particles, position2.position, position2.rotation);
        }
        else if (buttonsPushed == 3)
        {
            destroyRune3 = Instantiate(rune3, position3.position, position3.rotation);
            destroyParticles3 = Instantiate(particles, position3.position, position3.rotation);
        }
        else if (buttonsPushed == 4)
        {
            destroyRune4 = Instantiate(rune3, position4.position, position4.rotation);
            destroyParticles4 = Instantiate(particles, position4.position, position4.rotation);
        }
        else if (buttonsPushed == 5)
        {
            destroyRune5 = Instantiate(rune3, position5.position, position5.rotation);
            destroyParticles5 = Instantiate(particles, position5.position, position5.rotation);
        }
    }

    public IEnumerator ResetRunes()
    {
        yield return new WaitForSeconds(1);
        Destroy(destroyRune1);
        Destroy(destroyRune2);
        Destroy(destroyRune3);
        Destroy(destroyRune4);
        Destroy(destroyRune5);
        Destroy(destroyParticles1);
        Destroy(destroyParticles2);
        Destroy(destroyParticles3);
        Destroy(destroyParticles4);
        Destroy(destroyParticles5);


    }

    public void PuzzleWon()
    {
        if (canWin)
        {
            gate.Play("OpenGate", 0, 0f);
            openGate.Shake();
            audioSource.PlayOneShot(passSound, 0.7f);
            audioSource.clip = stoneDragging;
            audioSource.Play();
        }
    }
}
