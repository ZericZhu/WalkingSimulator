using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject Goog, GoogMid, GoogLeft, GoogRight;
    public Transform Camera;
    public float speed;
    public string[] RandomWord;
    public TMPro.TMP_FontAsset[] RandomFont;
    public GameObject MainText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            Color TempRandomColor = new Color(Random.value, Random.value, Random.value);
            print("space key was pressed");
            for (int i =0; i<Goog.transform.childCount;i++)
            {
                Goog.transform.GetChild(i).GetComponent<SpriteRenderer>().color = TempRandomColor;
            }
            MainText.GetComponent<TextMeshProUGUI>().text = RandomWord[0];
            MainText.GetComponent<TextMeshProUGUI>().font = RandomFont[0];
        }


        if (Input.GetKeyDown(KeyCode.A)|| Input.GetKeyDown(KeyCode.S)||Input.GetKeyDown(KeyCode.W)|| Input.GetKeyDown(KeyCode.D)
            || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            MainText.GetComponent<TextMeshProUGUI>().text = RandomWord[Random.Range(1, RandomWord.Length)];
            MainText.GetComponent<TextMeshProUGUI>().font = RandomFont[Random.Range(1, RandomFont.Length)];
        }

    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal")*speed, 0, 0);

        if (Goog.transform.position.y <= 1 && Input.GetAxis("Vertical") >= 0)
        {
            movement += new Vector3(0, Input.GetAxis("Vertical") * speed * 0.5f, 0);
        }

        if (Goog.transform.position.y >= -0.5 && Input.GetAxis("Vertical") <= 0)
        {
            movement += new Vector3(0, Input.GetAxis("Vertical") * speed * 0.5f, 0);
        }
        Goog.transform.position += movement;
        Camera.transform.position = new Vector3(Goog.transform.position.x, 0, -10);

        if (Input.GetAxis("Horizontal") <= 0.1 && Input.GetAxis("Horizontal") >= -0.1)
        {
            GoogMid.SetActive(true);
            GoogLeft.SetActive(false);
            GoogRight.SetActive(false);
        }
        else if(Input.GetAxis("Horizontal") > 0.1)
        {
            GoogMid.SetActive(false);
            GoogLeft.SetActive(false);
            GoogRight.SetActive(true);
        }
        else if (Input.GetAxis("Horizontal") < -0.1)
        {
            GoogMid.SetActive(false);
            GoogLeft.SetActive(true);
            GoogRight.SetActive(false);
        }
    }
}
