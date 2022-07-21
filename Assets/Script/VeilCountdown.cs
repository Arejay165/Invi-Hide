using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class VeilCountdown : MonoBehaviour
{
    // Start is called before the first frame update

    public TextMeshProUGUI veilCountdown;
    public float countdown = 5;
    public float resetCoolDown = 4;
    public PlayerMovement player;
    public Image logo;
    public Sprite check;
    public Sprite x;
    void Start()
    {
        ResetLogo();
        StartCoroutine(CountdownStart());
    }



    public IEnumerator CountdownStart()
    {
        while(countdown > 0)
        {
            veilCountdown.text = countdown.ToString();
            yield return new WaitForSeconds(1f);
            countdown--;
        }
        veilCountdown.gameObject.SetActive(false);
        player.canUseVeil = true;
        Debug.Log("Start");
        countdown = 5;
        logo.color = new Color(1, 1, 1, 255f);
        logo.sprite = check;
     //   StartCoroutine(CountdownReset());
    }

   public IEnumerator CountdownReset()
    {
      
        while(resetCoolDown > 0)
        {
            resetCoolDown--;
            yield return new WaitForSeconds(1f);
        }
       
        player.canUseVeil = false;
        resetCoolDown = 4;
        StartCoroutine(CountdownStart());
        veilCountdown.gameObject.SetActive(true);
        Debug.Log("Reset");
        GameManager.instance.PlayerHide();
        player.spriteRenderer.color = Color.white;

        if (player.tilemapVeil != null)
        {
            player.tilemapVeil.SetActive(false);
        }
        
        if(player.objVeil != null)
        {
            foreach(GameObject obj in player.objVeil)
            {
                obj.SetActive(false);
            }
        }

        if (player.blockerVeil != null)
        {
            player.blockerVeil.gameObject.SetActive(true);
        }

        ResetLogo();
    }

    void ResetLogo()
    {
        logo.color = new Color(0,0,0,0);
    }
}
