using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum MenuOptions
{
    Start,
    HowTo,
    Quit
};

public class MainMenuManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Image[] letters;

    public Sprite X, Z;

    public int counter;

    public RectTransform[] dottedLineTransform;
    public RectTransform dottedLine;

    public MenuOptions menuOptions;

    public RectTransform[] arrowPosition;

    public RectTransform arrow;

    public GameObject[] menus;

    // Update is called once per frame

    private void Start()
    {
        dottedLine.anchoredPosition = dottedLineTransform[0].anchoredPosition;
        arrow.anchoredPosition = arrowPosition[0].anchoredPosition;
        ChangeLetters(counter);
        counter = 0;
    }

    private void OnEnable()
    {
        dottedLine.anchoredPosition = dottedLineTransform[0].anchoredPosition;
        arrow.anchoredPosition = arrowPosition[0].anchoredPosition;
        ChangeLetters(0);
        counter = 0;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            SwitchMenuOptions();
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            DoMenuOption();
        }
    }

    void SwitchMenuOptions()
    {
        if (counter > 1)
        {
            counter = 0;
            menuOptions = 0;
        }
        else
        {
            menuOptions++;
            counter++;
        }
        dottedLine.anchoredPosition = dottedLineTransform[counter].anchoredPosition;
        arrow.anchoredPosition = arrowPosition[counter].anchoredPosition;
        ChangeLetters(counter);
    }

    void DoMenuOption()
    {
        switch (menuOptions)
        {
            case MenuOptions.Start:
                SceneManager.LoadScene("SampleScene");
                break;
            case MenuOptions.HowTo:
                menus[0].gameObject.SetActive(false);
                menus[1].gameObject.SetActive(true);
                break;

            case MenuOptions.Quit:
                Application.Quit();
                break;
        }
    }


    void ChangeLetters(int index)
    {
        for(int i = 0; i < letters.Length; i++)
        {
            letters[i].sprite = Z;
        }

        letters[index].sprite = X;
    }

    public void ResetMenu()
    {
        dottedLine.anchoredPosition = dottedLineTransform[0].anchoredPosition;
        arrow.anchoredPosition = arrowPosition[0].anchoredPosition;
        ChangeLetters(0);
        counter = 0;
    }
}
