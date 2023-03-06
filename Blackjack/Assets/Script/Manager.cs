using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;
using Newtonsoft.Json.Linq;

public class Manager : MonoBehaviour
{
    public int Decks;
    public int[] Player_Cards;
    public int[] Enemy_Cards;
    public GameObject Card;
    public int turn;
    public TMPro.TextMeshProUGUI PlayerValue;
    public TMPro.TextMeshProUGUI EnemyValue;
    int playerval;
    int enval;
    int enturn;
    public GameObject WinnerText;
    string Winnername;
    bool playerhasstayed;
    bool enemydone;
    float t;
    bool go;
    // Start is called before the first frame update
    void Start()
    {
        SpawnCards();
        SpawnEnemyCards();
        Winnername = "";
    }

    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime;

        if (t >= 0.25)
        {
            Camera.main.backgroundColor = new Color(Random.Range(0, 1f), Random.Range(0, 1f), Random.Range(0, 1f));
            t = 0;
        }

        if (!go)
        {
            PlayerValue.text = playerval.ToString();
            EnemyValue.text = enval.ToString();
            if (playerval > 21)
            {
                Winnername = "Enemy";
            }
            if (playerhasstayed && enemydone)
            {

                if (playerval == 21)
                {
                    if (enturn > 1)
                    {
                        Winnername = "Player";
                    }
                    else
                    {
                        SpawnEnemyCards();
                    }
                }
                else if (enval > 21)
                {
                    Winnername = "Player";
                }
                else if (enval == 21)
                {
                    Winnername = "Enemy";
                }
                else if (playerval > enval)
                {
                    Winnername = "Player";

                }
                else if (playerval == enval)
                {
                    Winnername = "Draw!";
                }
                else
                {
                    Winnername = "Enemy";
                }
            }
        }
        

        if(Winnername != "" && !go)
        {
            if (Winnername == "Player")
            {
                FindObjectOfType<Score>().PlayerScore += 1;
            }
            else if (Winnername == "Enemy")
            {
                FindObjectOfType<Score>().EnemyScore += 1;
            }

            Winnername += " Won!";
            WinnerText.SetActive(true);
            WinnerText.GetComponent<TMPro.TextMeshProUGUI>().text = Winnername;
            go = true;
        }

    }

    public void SpawnCards()
    {
        GameObject card_temp;
        card_temp = Instantiate(Card, new Vector3(-4, -2, 0), transform.rotation);
        
        if(Random.Range(0, 4) == 0)
        {
            card_temp.GetComponent<Card>().Value = 10;
            card_temp.GetComponent<Card>().Class = Random.Range(0, 4);
            int rng = Random.Range(0, 3);

            if(rng == 0)
            {
                card_temp.GetComponent<Card>().CardName = "Jack " + card_temp.GetComponent<Card>().Classes[card_temp.GetComponent<Card>().Class];
            }
            if (rng == 1)
            {
                card_temp.GetComponent<Card>().CardName = "Queen " + card_temp.GetComponent<Card>().Classes[card_temp.GetComponent<Card>().Class];
            }
            if (rng == 2)
            {
                card_temp.GetComponent<Card>().CardName = "King " + card_temp.GetComponent<Card>().Classes[card_temp.GetComponent<Card>().Class];
            }
        }
        else
        {
            card_temp.GetComponent<Card>().Value = Random.Range(1, 11);
            card_temp.GetComponent<Card>().Class = Random.Range(0, 4);

            card_temp.GetComponent<Card>().CardName = card_temp.GetComponent<Card>().Classes[card_temp.GetComponent<Card>().Class] + " " + card_temp.GetComponent<Card>().Value;
        }

        Player_Cards[turn] = card_temp.GetComponent<Card>().Value;
        turn += 1;

        card_temp.transform.position += new Vector3(transform.position.x + (turn * 1.25f), transform.position.y, transform.position.z);

        playerval = 0;
        for (int i = 0; i < Player_Cards.Length; i++)
        {
            playerval += Player_Cards[i];
        }
    }

    public void SpawnEnemyCards()
    {
        
        GameObject card_temp;
        card_temp = Instantiate(Card, new Vector3(-4, 4, 0), transform.rotation);

        if (Random.Range(0, 4) == 0)
        {
            card_temp.GetComponent<Card>().Value = 10;
            card_temp.GetComponent<Card>().Class = Random.Range(0, 4);
            int rng = Random.Range(0, 3);

            if (rng == 0)
            {
                card_temp.GetComponent<Card>().CardName = "Jack " + card_temp.GetComponent<Card>().Classes[card_temp.GetComponent<Card>().Class];
            }
            if (rng == 1)
            {
                card_temp.GetComponent<Card>().CardName = "Queen " + card_temp.GetComponent<Card>().Classes[card_temp.GetComponent<Card>().Class];
            }
            if (rng == 2)
            {
                card_temp.GetComponent<Card>().CardName = "King " + card_temp.GetComponent<Card>().Classes[card_temp.GetComponent<Card>().Class];
            }
        }
        else
        {
            card_temp.GetComponent<Card>().Value = Random.Range(1, 11);
            card_temp.GetComponent<Card>().Class = Random.Range(0, 4);

            card_temp.GetComponent<Card>().CardName = card_temp.GetComponent<Card>().Classes[card_temp.GetComponent<Card>().Class] + " " + card_temp.GetComponent<Card>().Value;
        }

        Enemy_Cards[enturn] = card_temp.GetComponent<Card>().Value;
        enturn += 1;

        card_temp.transform.position += new Vector3(transform.position.x + (enturn * 1.25f), transform.position.y, transform.position.z);
        enval = 0;
        for (int i = 0; i < Enemy_Cards.Length; i++)
        {
            enval += Enemy_Cards[i];
        }

        if (enturn > 1)
        {
            playerhasstayed = true;
            if (enval >= 17)
            {
                enemydone = true;
                return;
            }
            else
            {
                SpawnEnemyCards();
            }
        }
    }

    public void PlayAgaine()
    {
        SceneManager.LoadScene(0);
    }
}
