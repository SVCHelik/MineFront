using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class HPScrpt : MonoBehaviour
{
    // Start is called before the first frame update

    public Enemy target;
    public TextMeshPro my_text = new TextMeshPro();
    public Transform EnemyCentr;
    float HP;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (target){
            transform.eulerAngles = new Vector3(-1,0,0); 
            transform.position = EnemyCentr.position + new Vector3(0,1,+2);
            my_text.text = Mathf.Round(target.HP).ToString();
        }
    }
}
