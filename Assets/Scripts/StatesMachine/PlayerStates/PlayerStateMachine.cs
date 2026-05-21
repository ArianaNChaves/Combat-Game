using UnityEngine;

public class PlayerStateMachine : StateMachine
{
    [field: SerializeField] public InputReader InputReader { get; private   set; }
    [field: SerializeField] public CharacterController Controller { get; private   set; }
    [field: SerializeField] public Animator Animator { get; private   set; }
    public Transform MainCameraTransform { get; private   set; }
    
    [Header("Data")]
    [field: SerializeField] public float MovementSpeed { get; private   set; }
    [field: SerializeField] public float MovementAcceleration { get; private   set; } 
    [field: SerializeField] public float IdleBlendDuration { get; private   set; } 
    [field: SerializeField] public float RotationSpeed { get; private   set; } 

    private void Start()
    {
        if (Camera.main != null) MainCameraTransform = Camera.main.transform;
        SwitchState(new PlayerMoveState(this));
    }

}
