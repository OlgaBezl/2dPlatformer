using UnityEngine;

public class HealthBar : FollowerUI
{
    [SerializeField] private HealthView _healthView;

    private void OnDisable()
    {
        enabled = false;
    }

    public void SetParameters(RectTransform canvasRectTransform, Camera camera, Transform sceneElement, Vector3 offset, Health health)
    {
        CanvasRectTransform = canvasRectTransform;
        Camera = camera;
        SceneElement = sceneElement;
        Offset = offset;

        _healthView.SetHealth(health);
        health.Died += DisableComponent;
    }
    
    private void DisableComponent()
    {
        gameObject.SetActive(false);
    }
}
