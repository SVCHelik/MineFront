using UnityEngine;
using System.Collections.Generic;
using Cinemachine;
using UnityEditor.UIElements;
using System;

public class FSM 
{
    public FsmState _currentState { get; private set; }
    private Dictionary<Type, FsmState> _states;  
    
    public FSM(){
        _states = new Dictionary<Type, FsmState>();
    }
    public void AddState(FsmState state){
        _states.Add(state.GetType(), state);
    }

    public void SetState<T>() where T: FsmState {
        Debug.Log("Setting state: " + typeof(T).Name);
        var type = typeof(T);
        if(_currentState.GetType() == type) return;

        if(_states.TryGetValue(type, out var newState)){
            _currentState?.Exit();
            _currentState = newState;
            _currentState.Enter();
        }

    }
    public void Update()
    {
        
        _currentState?.Update();

    }
}