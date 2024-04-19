public abstract class FsmState{
    protected readonly FSM Fsm;

    public FsmState(FSM fsm)
    {
        Fsm = fsm;
    }

    public abstract void Enter();
    public abstract void Update();
    public abstract void Exit();   
}
