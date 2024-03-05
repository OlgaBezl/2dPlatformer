using System.Collections.Generic;
using UnityEngine;

public class HealthBarCreator : MonoBehaviour
{
    [SerializeField] private RectTransform _canvasRectTransform;
    [SerializeField] private Camera _camera;
    [SerializeField] private List<Health> _sceneElements;
    [SerializeField] private HealthBar _prefab;
    [SerializeField] private float _vericalOffsetFactor = 0.6f;

    private void Start()
    {
        foreach (Health sceneElement in _sceneElements)
        {
            HealthBar healthBar = Instantiate(_prefab, transform);

            Vector3 offset = new Vector3(0f, sceneElement.transform.lossyScale.y * _vericalOffsetFactor);
            healthBar.SetParameters(_canvasRectTransform, _camera, sceneElement.transform, offset, sceneElement);
        }
    }
}
