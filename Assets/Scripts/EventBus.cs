using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventBus
{
    public static EventBus _instance;

    // Start is called before the first frame update
    public static Action<GameObject> SpawnAsked;
    public static Action<float, Vector3, float, float > Exploded;
    public static Action<float, float, float> ExplodeAsked;
    
    public static Action<float> MobDespawned;
    public static Action<float> MobSpawned;

    public static Action removed;

    public static Action<Vector3> Player1Moved;
    public static Action<Vector3> Player2Moved;



    public EventBus()
    {
        if (_instance != null) throw new Exception("Another bus exists");
        _instance = this;
    }

    public static EventBus Instance
    {
        get
        {
            if(_instance == null) {
                _instance = new EventBus();
            }
            return _instance;
        }
    }

}
