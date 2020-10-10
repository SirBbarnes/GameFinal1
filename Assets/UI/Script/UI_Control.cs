using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Control : MonoBehaviour
{
    public GameObject pause;
    GameObject player;
    bool paused;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        Player_Control playerScript = player.GetComponent<Player_Control>();
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && paused == false)
        {
            pause.SetActive(true);
            paused = true;
            player.SetActive(false);

        }

        else if (Input.GetKeyDown(KeyCode.Escape) && paused == true)
        {
            pause.SetActive(false);
            paused = false;
            player.SetActive(true);
        }
    }
}
