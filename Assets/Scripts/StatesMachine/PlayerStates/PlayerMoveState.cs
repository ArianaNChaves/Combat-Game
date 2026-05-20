using UnityEngine;

public class PlayerMoveState : PlayerBaseState
{
    private float _idleTimer = 0;
    public PlayerMoveState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
        
    }

    public override void Enter()
    {
        
    }

    public override void Tick(float deltaTime)
    {
        Vector3 movement = new Vector3();
        movement.x = stateMachine.InputReader.MovementValue.x;
        movement.z = stateMachine.InputReader.MovementValue.y;
        movement.y = 0;
        movement.Normalize();
        
        stateMachine.Controller.Move(movement * (stateMachine.MovementSpeed * deltaTime));

        if (stateMachine.InputReader.MovementValue == Vector2.zero) //no se mueve no se gira y aca activo la animacion de idle
        {


            _idleTimer += Mathf.SmoothStep(0f, 1f, deltaTime);
            
            Debug.Log(_idleTimer);
            stateMachine.Animator.SetFloat("IdleTime", _idleTimer); 
            // if (_idleTimer >= 0.8f)
            // {
            //     stateMachine.Animator.SetFloat("IdleTime", _idleTimer); 
            // }
            // else
            // {
            //     stateMachine.Animator.SetFloat("IdleTime", 0.0f);
            // }
            
            stateMachine.Animator.SetFloat("Speed", stateMachine.InputReader.MovementValue.magnitude);
            
            return;
        }
        _idleTimer = 0;
        stateMachine.Animator.SetFloat("IdleTime", _idleTimer);
        stateMachine.Animator.SetFloat("Speed", movement.magnitude);
        stateMachine.transform.rotation = Quaternion.LookRotation(movement);

    }
    
    private float SmoothIncrease(float currentValue, float deltaTime, float duration)
    {
        if (duration <= 0f)
        {
            return 1f;
        }

        currentValue += deltaTime / duration;
        currentValue = Mathf.Clamp01(currentValue);

        return Mathf.SmoothStep(0f, 1f, currentValue);
    }

    public override void Exit()
    {
        
    }
}
