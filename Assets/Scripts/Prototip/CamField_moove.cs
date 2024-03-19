using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamField_moove : MonoBehaviour
{
    public float Player1_x;
    public float Player1_z;
    public float Player2_x;
    public float Player2_z;
    public float Max_dist;
    [SerializeField] private float _speedCam;

    private Vector3 _Direction;
    private Vector3 _PlayersPos;
    private float Players_x;
    private float Players_z;
    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
        _PlayersPos.x = (Player1_x + Player2_x)/2;
        _PlayersPos.y = 1f;
        _PlayersPos.z = (Player1_z + Player2_z)/2;
        _Direction = _PlayersPos - transform.position;
        Players_x = Mathf.Abs( Player1_x - Player2_x);
        Players_z = Mathf.Abs( Player1_z - Player2_z);
        transform.localScale = new Vector3 (Players_x, 0.5f, Players_z);
        Max_dist = Mathf.Max(Players_x, Players_z*1.7f);
    }
    private void FixedUpdate()
    {
        transform.position+=(_Direction * _speedCam * Time.fixedDeltaTime);
    }
}
