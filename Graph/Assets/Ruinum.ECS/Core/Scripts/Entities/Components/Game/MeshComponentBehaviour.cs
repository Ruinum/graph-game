using UnityEngine;

public class MeshComponentBehaviour : MonoBehaviour
{
    [SerializeField] private Transform _meshParent;
    public GameObject Mesh => _meshParent.gameObject;
}
