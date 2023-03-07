using UnityEngine;
using Zenject;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Vector3 _offset;
    [SerializeField] private float _speed;

    private Transform _target;

    [Inject]
    public void Construct(Ship ship)
    {
        _target = ship.transform;
    }

    private void Update()
    {
        if (_target == null) return;

        Follow();
    }

    private void Follow()
    {
        transform.position = Vector3.Lerp(transform.position, _offset + _target.position, _speed * Time.deltaTime);
    }
}
