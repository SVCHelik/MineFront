using System.Collections;
using UnityEngine;

public class PoliceObserver : MonoBehaviour{
    public GameObject _playerObject;

    void Start()
    {
        if (_playerObject == null)
        {
        _playerObject = GameObject.FindWithTag("Player");
         }
    }

    void Update()
    {
       if (_playerObject!= null)
    {
        transform.LookAt(_playerObject.transform);
    }
    }

    public void SetTarget(GameObject newPlayerObject)
    {
        _playerObject = newPlayerObject;
    }
}