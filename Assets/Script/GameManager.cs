using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static GameManager instance;
    public GameObject[] NPCS;
    public string currentLevel;
    public string nextLevel;
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            return;
        }

        NPCS = GameObject.FindGameObjectsWithTag("NPC");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   public void PlayerHide()
    {
      if(NPCS != null)
      {
        foreach (GameObject go in NPCS)
        {

              //  go.gameObject.GetComponent<ChasePlayer>().canSeePlayer = !go.gameObject.GetComponent<ChasePlayer>().canSeePlayer;
        }

      }
    }
      
   public void ProceedNextLevel()
    {
        SceneManager.LoadScene(nextLevel);
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(currentLevel);
    }
      
}

