public class State
{
    protected StateMachine StateMachine;
    public float UpdateInterval { get; protected set; } = 1.0f;

    protected State(StateMachine stateMachine)
    {
        StateMachine = stateMachine;
    }

    public virtual void Start()
    {
        
    }
    
    public virtual void IntervalUpdate()
    {
        
    }
    
    public virtual void Update()
    {
        
    }
    
    public virtual void FixedUpdate()
    {
        
    }
    
    public virtual void Exit()
    {
        
    }
}