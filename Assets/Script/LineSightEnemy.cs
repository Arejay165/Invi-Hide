using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineSightEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform castPoint;
    public float distance;
    public PlayerMovement player;
    public float speed;
    public bool isRight;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //float castDistance = Mathf.Infinity;

        float castDistance = -distance;
        if (!isRight)
        {
            castDistance = distance;
        }
        Vector2 endPos = castPoint.position + Vector3.right * castDistance;

        RaycastHit2D hit = Physics2D.Linecast(castPoint.position, endPos, 1 << LayerMask.NameToLayer("Player"));

        if(hit.collider != null)
        {
            if (hit.collider.gameObject.CompareTag("Player"))
            {
                Debug.Log("On Sight");
                Vector3 targetDir = player.transform.position - transform.position;
                transform.Translate(targetDir * Time.deltaTime * speed);
               // DoFunction();
            }
            else
            {
                Debug.Log("Not Sight");
            }

            Debug.DrawLine(castPoint.position, hit.point, Color.red);
        }
        else
        {
            Debug.DrawLine(castPoint.position, endPos, Color.blue);
        }
    }

    //public virtual void DoFunction()
    //{
    //    Vector3 targetDir = player.transform.position - transform.position;
    //    transform.Translate(targetDir * Time.deltaTime * speed);
    //}
}
