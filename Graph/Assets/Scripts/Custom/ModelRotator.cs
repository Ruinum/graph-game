using UnityEngine;


public class ModelRotator : MonoBehaviour
{
    [SerializeField] private GameObject _modelPrefab;
    [SerializeField] private int _rotationSpeed;

    private GameObject _createdModel;

    private void Start()
    {
        _createdModel = Instantiate(_modelPrefab, transform);
    }
    
    private void Update()
    {
        if (_createdModel == null) return;

        _createdModel.transform.Rotate(0, _rotationSpeed * Time.deltaTime, 0);
    }
}
