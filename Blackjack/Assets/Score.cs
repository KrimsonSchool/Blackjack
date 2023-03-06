using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;

public class Score : MonoBehaviour
{
    public int PlayerScore;
    public int EnemyScore;
    public TMPro.TextMeshProUGUI scoretext;
    // Start is called before the first frame update
    void Start()
    {
        PlayerScore = PlayerPrefs.GetInt("PlayerScore");
        EnemyScore = PlayerPrefs.GetInt("EnemyScore");
    }

    // Update is called once per frame
    void Update()
    {
        scoretext.text = "Player score: " + PlayerScore + "\n" + "Enemy score: " + EnemyScore;

        PlayerPrefs.SetInt("PlayerScore", FindObjectOfType<Score>().PlayerScore);
        PlayerPrefs.SetInt("EnemyScore", FindObjectOfType<Score>().EnemyScore);
    }
}
