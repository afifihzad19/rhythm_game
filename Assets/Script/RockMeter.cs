using System.Collections;
using UnityEngine;

public class RockMeter : MonoBehaviour
{

    float rm;
    GameObject needle;

    // Start is called before the first frame update
    void Start()
    {
        needle = transform.Find("GameObject/needle").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        rm = PlayerPrefs.GetInt("RockMeter");

        needle.transform.localPosition = new Vector3((rm - 50 )/ 50, 0, 0);
    }
}