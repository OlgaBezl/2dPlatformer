using UnityEngine;

public class PlayerMover : CharacterMover
{
    [SerializeField] private Jump _jump;

    private bool _isIntentToJump;

    private void Update()
    {
        if(IsActive == false)
        {
            return;
        }

        Direction = new Vector2(Input.GetHorizontalPosition(), Input.GetVerticalPosition());
        _isIntentToJump = Input.GetIntentJump();
    }

    private void FixedUpdate()
    {
        if (IsActive == false)
        {
            return;
        }

        Mover.MoveTo(Direction);

        if (_isIntentToJump)
        {
            _jump.TryJump();
        }
    }
}
