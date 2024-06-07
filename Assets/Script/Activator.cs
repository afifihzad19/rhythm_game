using System.Collections;
using UnityEngine;

public class Activator : MonoBehaviour
{

    SpriteRenderer sr;
    public KeyCode key;
    bool active = false;
    GameObject note, gm;
    Color old;
    public bool createMode;
    public GameObject n;

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        gm = GameObject.Find("GameManager");
        old = sr.color;
    }

    void Update()
    {
        if (createMode)
        {
            if (Input.GetKeyDown(key))
                Instantiate(n, transform.position, Quaternion.identity);
        }
        else
        {
            if (Input.GetKeyDown(key))
                StartCoroutine(Pressed());

            if (Input.GetKeyDown(key) && active)
            {
                Destroy(note);
                gm.GetComponent<GameManager>().AddStreak();
                AddScore();
                active = false;
            }
            else if (Input.GetKeyDown(key) && !active)
            {
                gm.GetComponent<GameManager>().ResetStreak();
            }
        }

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "WinNote")
            gm.GetComponent<GameManager>().Win();

        if (col.gameObject.tag == "Note")
            note = col.gameObject;
        active = true;
    }

    void OnTriggerExit2D(Collider2D col)
    {
        active = false;
        gm.GetComponent<GameManager>().ResetStreak();
    }

    void AddScore()
    {
        PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score") + gm.GetComponent<GameManager>().GetScore());
    }

    IEnumerator Pressed()
    {

        sr.color = new Color(0, 0, 0);
        yield return new WaitForSeconds(0.1f);
        sr.color = old;
    }
}