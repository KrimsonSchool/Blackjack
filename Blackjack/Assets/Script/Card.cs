using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Card : MonoBehaviour
{
    public string CardName;
    public int Value;
    public int Class;
    public string[] Classes;
    public TMPro.TextMeshPro CardText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CardText.text = CardName;

        GetComponent<SpriteRenderer>().color = new Color(Random.Range(0, 1f), Random.Range(0, 1f), Random.Range(0, 1f));
    }
}
