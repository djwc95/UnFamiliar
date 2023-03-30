using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoulFragment : MonoBehaviour
{
    public SoulCounter soulSO;
    public PlayerMovement2 pm2;
    //========================UI Elements=====================
    public CanvasGroup canvas;
    private float fadeTime;
    private float waitTime;

    public int soulsCollected;
    //=========================Images==========================
    public Image empty;

    public Sprite zero;
    public Sprite one;
    public Sprite two;
    public Sprite three;
    public Sprite four;
    public Sprite five;
    public Sprite six;
    public Sprite seven;
    public Sprite eight;
    public Sprite nine;
    //==========================Audio and Animation FX========================
    public AudioSource source;
    public AudioClip clip;

    public Animator animator;
    private string disappear = "disappear";

    private Vector3 thisLocation;
    public GameObject particles;

    private void Start()
    {
        thisLocation = transform.position;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == ("Player"))
        {
            StartCoroutine(Visible());
            StartCoroutine(LockPlayer());
            animator.Play(disappear, 0, 0f);
            Instantiate(particles, thisLocation, Quaternion.identity); //particleFX
            soulSO.soulsNum++;

            source.clip = clip; //play sound
            source.Play();
        }
    }

    public IEnumerator LockPlayer()
    {
        pm2.LockMovement();
        yield return new WaitForSeconds(2.5f);
        pm2.UnLockMovement();
    }

    public IEnumerator Visible()
    {
        StartCoroutine(FadeIn());
        yield return new WaitForSeconds(waitTime);
        StartCoroutine(FadeOut());
    }

    private IEnumerator FadeOut()
    {
        while (canvas.alpha > 0)
        {
            canvas.alpha -= Time.deltaTime / fadeTime;
            yield return null;
        }
        yield return null;
    }

    private IEnumerator FadeIn()
    {
        while (canvas.alpha < 1)
        {
            canvas.alpha += Time.deltaTime / fadeTime;
            yield return null;
        }
        yield return null;
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            StartCoroutine(Visible());
        }

        if(pm2.stamina <=0)
        {
            StartCoroutine(Visible());
        }
        //================== Fill in Sprite with correct num of souls =============================
        if (soulSO.soulsNum == 0) 
        {
            empty.sprite = zero;
        }
        else if (soulSO.soulsNum == 1)
        {
            empty.sprite = one;
        }
        else if (soulSO.soulsNum == 2)
        {
            empty.sprite = two;
        }
        else if (soulSO.soulsNum == 3)
        {
            empty.sprite = three;
        }
        else if (soulSO.soulsNum == 4)
        {
            empty.sprite = four;
        }
        else if (soulSO.soulsNum == 5)
        {
            empty.sprite = five;
        }
        else if (soulSO.soulsNum == 6)
        {
            empty.sprite = six;
        }
        else if (soulSO.soulsNum == 7)
        {
            empty.sprite = seven;
        }
        else if (soulSO.soulsNum == 8)
        {
            empty.sprite = eight;
        }
        else if (soulSO.soulsNum == 9)
        {
            empty.sprite = nine;
        }
    }
}
