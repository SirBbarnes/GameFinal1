using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_Start_Control : MonoBehaviour
{
    public GameObject settings;
    public GameObject Menu;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ButtonStart()
    {
        int curScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(curScene + 1);
    }

    public void ButtonSettings()
    {
        settings.SetActive(true);
        Menu.SetActive(false);
    }

    public void ButtonExit()
    {
        Application.Quit();
        Debug.Log("Quit");
    }

    public void ButtonBack()
    {
        settings.SetActive(false);
        Menu.SetActive(true);
    }
}
