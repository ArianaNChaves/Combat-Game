using UnityEngine;

public class PlayerStateMachine : StateMachine
{
    [field: SerializeField] public InputReader InputReader { get; private   set; }
    [field: SerializeField] public CharacterController Controller { get; private   set; }
    [field: SerializeField] public Animator Animator { get; private   set; }
    
    [Header("Data")]
    [field: SerializeField] public float MovementSpeed { get; private   set; }
    private void Start()
    {
        SwitchState(new PlayerMoveState(this));
    }

}
