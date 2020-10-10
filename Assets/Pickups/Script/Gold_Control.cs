    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gold_Control : MonoBehaviour
{
    GameObject player;
    Text gold;
    Player_Control playerScript;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerScript = player.GetComponent<Player_Control>();
        gold = GameObject.FindGameObjectWithTag("GoldTotal").GetComponent<Text>();
    }


    // Update is called once per frame
    void Update()
    {
        gold.text = playerScript.playGold.ToString();
    }
}
