using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class KillCounter : MonoBehaviour
{
    public TextMeshProUGUI killCounter;

    // Update is called once per frame
    void Update()
    {
        killCounter.text = "Kills: " + FindObjectOfType<GameManager>().enemyKillCount.ToString();
    }
}
