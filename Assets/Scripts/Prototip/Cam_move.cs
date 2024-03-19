using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam_move : MonoBehaviour
{
    public CamField_moove _CamF;
    [SerializeField] private float _CamY;
    [SerializeField] private float fixDist;



    void Update()
    {
        //Debug.Log(_CamF.transform.position.z - transform.position.z);
        
        transform.position += Vector3.Scale(new Vector3 (0f, (_CamF.Max_dist - transform.position.y + _CamY)/10,  0f), transform.forward*-1) + new Vector3 (0f, 0f, _CamF.transform.position.z - transform.position.z - fixDist);

        if (transform.position.y < 35) transform.position += Vector3.Scale(new Vector3 (0f, (35 - transform.position.y), 0f ), transform.forward*-1) + new Vector3 (0f, 0f, _CamF.transform.position.z - transform.position.z - fixDist);
    }
}
