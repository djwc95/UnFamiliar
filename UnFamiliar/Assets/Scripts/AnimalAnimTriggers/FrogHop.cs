using System.Collections;
using UnityEngine;

public class FrogHop : MonoBehaviour
{
    public float speed;

    public Vector3 destination;
    public GameObject carrotStick;

    public Animator frogAnimator;
    public float coolDown;
    public float fullCoolDown = 2.5f;

    public float minRange;
    public float maxRange;

    private void Start()
    {
        coolDown = fullCoolDown;
    }

    void Update()
    {
        destination = carrotStick.transform.position;
        IncrementPosition();

        coolDown -= Time.deltaTime;
        if (coolDown <= 0)
        {
            StartCoroutine(RollTime());
            coolDown = fullCoolDown;
        }
    }

    void IncrementPosition()
    {
        // Calculate the next position
        float delta = speed * Time.deltaTime;
        Vector3 currentPosition = gameObject.transform.position;
        Vector3 nextPosition = Vector3.MoveTowards(currentPosition, destination, delta);

        // Move the object to the next position
        gameObject.transform.position = nextPosition;
    }

    public IEnumerator RollTime()
    {
        frogAnimator.SetTrigger("turn");
        yield return new WaitForSeconds(Random.Range( minRange, maxRange));
        frogAnimator.SetBool("turn", true);
        yield return new WaitForSeconds(.1f);
        frogAnimator.SetBool("turn", false);
    }
}
