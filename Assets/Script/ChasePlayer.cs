using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChasePlayer : MonoBehaviour
{
    // Start is called before the first frame update

    public float speed;
    public Transform player;
    public bool canSeePlayer;
    public Animator anim;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 movement = new Vector3(dirIndex, 0, 0);
        if(player != null)
        {
            if (canSeePlayer)
            {
                Vector3 targetDir = player.position - transform.position;
                float angle = Mathf.Atan2(targetDir.y, targetDir.x) * Mathf.Rad2Deg - 90f;
                Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, q, 180);
                transform.Translate(Vector3.up * Time.deltaTime * speed);
            }
         
        }
      
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(player.gameObject);
        }
    }
}
