using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOver : MonoBehaviour
{    
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private TMP_Text distanceText;
    [SerializeField] private TMP_Text killCountText;
    [SerializeField] private Pause pause;
    [HideInInspector] public float distance;
    [HideInInspector] public int killCount;    

    public void Defeat()
    {
        pause.PauseOn();
        distanceText.text = "Distance\n" + distance.ToString();
        killCountText.text = "Enemies killed\n" + killCount.ToString();
        gameOverPanel.SetActive(true);        
    }
}
