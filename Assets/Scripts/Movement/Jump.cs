using UnityEngine;

public class Jump : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private float _jumpHeight = 2;
    [SerializeField] private float _zeroDistanceToGround = 0.5f;

    private const float JumpMultiply = -2f;

    private bool _isGrounded;

    internal void UpdateGroundCollision()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, _zeroDistanceToGround, LayerMask.GetMask("Ground"));
        _isGrounded = hit.collider != null;
    }

    internal bool TryJump()
    {
        if (_isGrounded == false)
        {
            return false;
        }

        var jumpVelocity = new Vector2(0f, Mathf.Sqrt(_jumpHeight * JumpMultiply * Physics.gravity.y));

        _rigidbody.velocity = jumpVelocity;
        return true;
    }
}
