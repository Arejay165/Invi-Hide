using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VeilStopper : MonoBehaviour
{
    public PlayerMovement player;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //float castDistance = Mathf.Infinity;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player");
            player.canUseVeil = false;
            player.veil.logo.sprite = player.veil.x;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //player.canUseVeil = false;
            //player.veil.logo.sprite = player.veil.x;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //Debug.Log("Player Exit");
            player.veil.logo.sprite = player.veil.check;
            //player.canUseVeil = true;
             StartCoroutine(player.veil.CountdownStart());


        }
    }
}