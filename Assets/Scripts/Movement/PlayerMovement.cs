using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Movement _movement;
    [SerializeField] private Jump _jump;

    public bool IsJump { get; private set; }
    public bool IsWalk => _direction != Vector2.zero;

    private MovementInput _input;
    private Vector2 _direction;
    private bool _isIntentToJump;

    private void Start()
    {
        _input = new MovementInput();
    }

    private void Update()
    {
        _direction = new Vector2(_input.HorizontalMove(), _input.VerticalMove());
        _isIntentToJump = _input.Jump();

        if (_isIntentToJump)
        {
            _jump.UpdateGroundCollision();
        }
    }

    private void FixedUpdate()
    {
        _movement.MoveTo(_direction);

        IsJump = _isIntentToJump && _jump.TryJump();
   }
}
