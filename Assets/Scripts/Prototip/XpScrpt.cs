using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class XpScrpt : MonoBehaviour
{
    // Start is called before the first frame update

    public Enemy turget;
    public TextMeshPro my_text;
    public Transform EnemyCentr;
    float Xp;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.eulerAngles = new Vector3(-1,0,0); 
        transform.position = EnemyCentr.position + new Vector3(0,1,+2);
        my_text.text = Mathf.Round(turget.Xp).ToString();

        
    }
}
