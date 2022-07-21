using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update

    public float speed;
    public bool isMovingRight;
    public float dirIndex;
    public bool canUseVeil;
    public VeilCountdown veil;

    public Animator anim;

    public Transform groundChecker;
    private bool isGrounded;
    public float groundCheckRadius;
    public LayerMask ground;
    public SpriteRenderer spriteRenderer;
    public GameObject tilemapVeil;
    public GameObject blockerVeil;
    public GameObject[] objVeil;


    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        if(objVeil != null)
        {
            objVeil = GameObject.FindGameObjectsWithTag("Objects");

        
                foreach (GameObject obj in objVeil)
                {
                    obj.SetActive(false);
                }
            
        }
       
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            MovementDirection();
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            if (canUseVeil)
            {
                EquipVeil();
            }
        
        }

        CheckGround();
    }


    public void EquipVeil()
    {
        if(tilemapVeil != null)
        {
            tilemapVeil.gameObject.SetActive(true);
            
        }

        if(blockerVeil != null)
        {
            blockerVeil.gameObject.SetActive(false);
        }

        if(objVeil != null)
        {
            foreach(GameObject obj in objVeil)
            {
                obj.SetActive(true);
            }
        }
        canUseVeil = !canUseVeil;
        StartCoroutine(veil.CountdownReset());
        GameManager.instance.PlayerHide();
        
        veil.logo.sprite = veil.x;
        spriteRenderer.color = Color.gray;
    }

    void CheckGround()
    {
        isGrounded = Physics2D.OverlapCircle(groundChecker.position, groundCheckRadius, ground);
        anim.SetBool("IsGrounded", isGrounded);
    }
   
    private void LateUpdate()
    {
        
        Vector3 movement = new Vector3(dirIndex,0, 0);

        Vector3 translation = movement * speed * Time.deltaTime;

        transform.Translate(translation);
    }

    void MovementDirection()
    {
        isMovingRight = !isMovingRight;

        spriteRenderer.flipX = !spriteRenderer.flipX;
        if (isMovingRight)
        { 
            dirIndex = changeDirection();
        }
        else
        {
            dirIndex = changeDirection();
        }
    }

    float changeDirection()
    {
        float idRef; 
        if (isMovingRight)
        {
            idRef = 1;
        }
        else
        {
            idRef = -1;
        }
        return idRef;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(groundChecker.position, groundCheckRadius);
    }

}
