using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class remover : MonoBehaviour
{
    public float time;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyObject", time);
    }

    void DestroyObject()
    {
        Destroy(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
