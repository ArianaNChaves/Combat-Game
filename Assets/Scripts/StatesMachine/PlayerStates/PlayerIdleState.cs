using UnityEngine;

public class PlayerIdleState : PlayerBaseState
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public PlayerIdleState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
        
    }
    

    public override void Enter()
    {
        Debug.Log("Entering PlayerIdleState");
    }

    public override void Tick(float deltaTime)
    {
        Debug.Log("Ticking PlayerIdleState");
    }

    public override void Exit()
    {
        Debug.Log("Exiting PlayerIdleState");
    }
}
