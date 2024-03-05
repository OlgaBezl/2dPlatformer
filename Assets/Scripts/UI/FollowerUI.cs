using UnityEngine;

[RequireComponent (typeof(RectTransform))]
public class FollowerUI : MonoBehaviour
{
    protected RectTransform CanvasRectTransform;
    protected Camera Camera;
    protected Transform SceneElement;
    protected Vector3 Offset;

    private const float _halfFactor = 0.5f;

    private RectTransform _uiElement;

    private void Start()
    {
        _uiElement = GetComponent<RectTransform>();
    }

    private void Update()
    {
        _uiElement.anchoredPosition = GetPositionOnCanvas();
    }
    
    private Vector2 GetPositionOnCanvas()
    {
        Vector2 viewportPosition = Camera.WorldToViewportPoint(SceneElement.position + Offset);

        return new Vector2(
            ((viewportPosition.x * CanvasRectTransform.sizeDelta.x) - (CanvasRectTransform.sizeDelta.x * _halfFactor)),
            ((viewportPosition.y * CanvasRectTransform.sizeDelta.y) - (CanvasRectTransform.sizeDelta.y * _halfFactor)));
    }
}
