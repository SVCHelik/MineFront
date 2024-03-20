using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam_move : MonoBehaviour
{
    public CamField_moove _CamF;
    [SerializeField] private float fixfixDist;
    [SerializeField] private float fixDist;
    [SerializeField] private float Offset;



    void Update()
    {
        //Debug.Log(_CamF.transform.position.z - transform.position.z);
        transform.position += new Vector3 (_CamF.transform.position.x - transform.position.x, 0f, 0f);
        transform.position += Vector3.Scale(new Vector3 (0f, (_CamF.Max_dist * Offset - transform.position.y)/20,  0f), transform.forward*-1) + new Vector3 (0f, 0f, _CamF.transform.position.z - transform.position.z - fixDist - (transform.position.y-35)*fixfixDist);

        if (transform.position.y < 35) transform.position += Vector3.Scale(new Vector3 (0f, (35 - transform.position.y), 0f ), transform.forward*-1) + new Vector3 (0f, 0f, _CamF.transform.position.z - transform.position.z - fixDist);
    }
    
}
