using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpViewer : MonoBehaviour
{
    private Text hpText;
    private GameObject player;

    private void Start()
    {
        hpText = GetComponent<Text>();
    }

    private void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player");


        if (player != null)
        {
            hpText.text = "HP: " + player.GetComponent<StatusPlayer>().HpPlayer;
        }
    }
}
