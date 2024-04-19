using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class CamField_moove : MonoBehaviour
{
    [SerializeField] private float _speedCam;
    public float playerDist;
    private Vector3 _Direction;
    private Vector3 PlayersMidPoint;
    public Transform[] players;
    public Vector3 playersDistVect;
    // Start is called before the first frame update
    // Update is called once per frame
    void Start(){
    }
    void Update()
    {
        PlayersMidPoint = (players[0].position + players[1].position)/2;    
        PlayersMidPoint.y = 1f;
        _Direction = (PlayersMidPoint - transform.position).normalized;
        playersDistVect = players[0].position - players[1].position;
        transform.localScale = new Vector3 (Mathf.Abs(playersDistVect.x), 0.5f, Mathf.Abs(playersDistVect.z));
        playerDist = playersDistVect.magnitude;
    }
    private void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, transform.position + _Direction * _speedCam, Time.fixedDeltaTime);
    }

}
