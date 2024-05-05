using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float LiveTime;
    private float timer;
    public float BulletSpeed;

    // Start is called before the first frame update
    void Start()
    {
        timer = LiveTime;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        transform.position += transform.forward * BulletSpeed * Time.deltaTime;
        if (timer <= 0){
            //transform.position += Vector3.Scale(new Vector3 (0f, 0f,  BulletSpeed), transform.forward);
            
            Destroy(transform.gameObject);
        }
            
    }

}
