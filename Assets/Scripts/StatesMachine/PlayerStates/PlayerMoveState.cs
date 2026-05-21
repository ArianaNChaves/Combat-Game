using UnityEngine;

public class PlayerMoveState : PlayerBaseState
{
    private static readonly int Speed = Animator.StringToHash("Speed");
    private static readonly int IdleTime = Animator.StringToHash("IdleTime");
    private const float AnimatorBlendValueMin = 0f;
    private const float AnimatorBlendValueMax = 1f;
    private const float MovementMagnitudeMin = 0.01f;
    private float _idleTimer = 0;
    public PlayerMoveState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
        
    }

    public override void Enter()
    {
        
    }

    public override void Tick(float deltaTime)
    {
        Vector3 movement = CalculateMovement();

        stateMachine.Controller.Move(movement * (stateMachine.MovementSpeed * deltaTime));
        if (stateMachine.InputReader.MovementValue.sqrMagnitude < MovementMagnitudeMin)
        {
            
            _idleTimer += Mathf.SmoothStep(AnimatorBlendValueMin, AnimatorBlendValueMax, deltaTime);
            stateMachine.Animator.SetFloat(IdleTime, _idleTimer); 
            stateMachine.Animator.SetFloat(Speed, AnimatorBlendValueMin);
            
            return;
        }

        _idleTimer = 0;
        stateMachine.Animator.SetFloat(IdleTime, _idleTimer);
        stateMachine.Animator.SetFloat(Speed, stateMachine.InputReader.MovementValue.sqrMagnitude);
        
        FaceMovementDirection(movement, deltaTime);

    }

    public override void Exit()
    {
        
    }

    private void FaceMovementDirection(Vector3 movementDirection, float deltaTime)
    {
        stateMachine.transform.rotation = Quaternion.Lerp(stateMachine.transform.rotation,
            Quaternion.LookRotation(movementDirection), deltaTime * stateMachine.RotationSpeed);

    }

    private Vector3 CalculateMovement()
    {
        Vector3 forward = stateMachine.MainCameraTransform.forward;
        Vector3 right = stateMachine.MainCameraTransform.right;
        
        forward.y = 0;
        right.y = 0;
        
        forward.Normalize();
        right.Normalize();
        
        return forward * stateMachine.InputReader.MovementValue.y + right * stateMachine.InputReader.MovementValue.x;
    }
    
}
