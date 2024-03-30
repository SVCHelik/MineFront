using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public float LiveTime = 1;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        
        LiveTime = Time.deltaTime;
        timer = LiveTime;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0){
            Destroy(transform.gameObject);
        }
    }
}
