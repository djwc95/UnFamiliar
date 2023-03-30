using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.VisualScripting.Member;

public class RespawnScript : MonoBehaviour
{
    public GameObject player;
    public Vector3 respawnPoint;
    public GameObject whereToSpawn;

    public GameObject soulParticles;
    public GameObject deathParticles;

    public AudioSource source;
    public AudioClip clip;

    public PlayerMovement2 pm2;
    // Start is called before the first frame update
    void Start()
    {
        respawnPoint = whereToSpawn.transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(DieSlow());
        }
    }

    public IEnumerator DieSlow()
    {
        source.clip = clip; //play sound
        source.Play();
        Instantiate(deathParticles, player.transform.position, Quaternion.identity);
        player.SetActive(false);
        yield return new WaitForSeconds(2.5f);
        player.transform.position = respawnPoint;
        player.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        Instantiate(soulParticles, respawnPoint, Quaternion.identity);
        pm2.LockMovement();
        yield return new WaitForSeconds(2.5f);
        pm2.UnLockMovement();
    }
}
