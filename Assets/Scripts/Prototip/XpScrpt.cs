using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class XpScrpt : MonoBehaviour
{
    // Start is called before the first frame update

    public Enemy turget;
    public TextMeshPro my_text;
    float Xp;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.eulerAngles = new Vector3(0,0,-1);
        my_text.text = turget.Xp.ToString();

        
    }
}
