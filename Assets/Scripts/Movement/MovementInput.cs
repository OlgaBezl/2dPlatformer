using UnityEngine;

public class MovementInput
{
    private const string HorizontalAxis = "Horizontal";
    private const string VerticalAxis = "Vertical";

    public float HorizontalMove()
    {
        return Input.GetAxis(HorizontalAxis);
    }

    public float VerticalMove()
    {
        return Input.GetAxis(VerticalAxis);
    }

    public bool Jump()
    {
        return Input.GetKey(KeyCode.Space);
    }
}
