using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    // Start is called before the first frame update
    public MainMenuManager menuManager;
    public int counter;
    public GameObject[] tutorials;
    public GameObject menus;
    void Start()
    {
        
    }

    private void OnEnable()
    {
        counter = 0;
        for (int i = 0; i < tutorials.Length; i++)
        {
            tutorials[i].gameObject.SetActive(false);
        }
        tutorials[counter].gameObject.SetActive(true);
        menus.SetActive(false);

    }

    private void OnDisable()
    {
        if(menus != null)
        {
            menus.SetActive(true);
        }
    
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            SwitchTutorials();
        }
    }

    void SwitchTutorials()
    {
        counter++;
        if(counter < tutorials.Length)
        {
            Debug.Log("Tutorial");
            for (int i = 0; i < tutorials.Length; i++)
            {
                tutorials[i].gameObject.SetActive(false);
            }
            tutorials[counter].gameObject.SetActive(true);
        }
        else
        {
            menuManager.menus[0].gameObject.SetActive(true);
            menuManager.menus[1].gameObject.SetActive(false);
            counter = 0;
            menuManager.menuOptions = MenuOptions.Start;
            menuManager.ResetMenu();
        }
       
    }
}
