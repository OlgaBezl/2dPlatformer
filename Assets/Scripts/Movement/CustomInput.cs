using UnityEngine;

public class CustomInput
{
    private const string HorizontalAxis = "Horizontal";
    private const string VerticalAxis = "Vertical";

    public float GetHorizontalPosition()
    {
        return Input.GetAxis(HorizontalAxis);
    }

    public float GetVerticalPosition()
    {
        return Input.GetAxis(VerticalAxis);
    }

    public bool GetIntentJump()
    {
        return Input.GetKey(KeyCode.Space);
    }

    public bool GetIntentVampire()
    {
        return Input.GetKey(KeyCode.LeftControl);
    }
}
