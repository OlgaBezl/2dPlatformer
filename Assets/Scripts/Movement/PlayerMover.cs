using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private Mover _mover;
    [SerializeField] private Jump _jump;

    private MovementInput _input;
    private Vector2 _direction;
    private bool _isIntentToJump;

    public bool IsJump { get; private set; }
    public bool IsWalk => _direction != Vector2.zero;

    private void Start()
    {
        _input = new MovementInput();
    }

    private void Update()
    {
        _direction = new Vector2(_input.GetHorizontalPosition(), _input.GetVerticalPosition());
        _isIntentToJump = _input.GetIntentJump();
    }

    private void FixedUpdate()
    {
        _mover.MoveTo(_direction);

        IsJump = _isIntentToJump && _jump.TryJump();
   }
}
