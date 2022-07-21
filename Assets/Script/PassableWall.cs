using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassableWall : MonoBehaviour
{
    // Start is called before the first frame update
    public BoxCollider2D collide;
    public PlayerMovement player;
    void Start()
    {
        collide = gameObject.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!player.canUseVeil)
        {
            collide.isTrigger = true;
        }
        else
        {
            collide.isTrigger = false;
        }
    }

   
}
