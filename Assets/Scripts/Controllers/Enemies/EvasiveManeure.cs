using System.Collections;
using UnityEngine;

public class EvasiveManeure : MonoBehaviour
{
    private Boundary _boundary;
    
    private Vector2 _startWait;
    private Vector2 _maneuvreTime;
    private Vector2 _maneuvreWait;

    private Rigidbody _rigidbody;
    
    [SerializeField] private float _targetManeuvre;
    [SerializeField] private float _dodge;
    [SerializeField] private float _maneuvreSpeed;
    [SerializeField] private float _currentSpeed;
    [SerializeField] private float _tilt;
    
    private void Start()
    {
        _currentSpeed = GetComponent<Rigidbody>().velocity.z;
        _rigidbody = GetComponent<Rigidbody>();
        StartCoroutine(Evade());
    }

    public void InitBoundary(Boundary boundary)
    {
        _boundary = boundary;
    }
    
    IEnumerator Evade()
    {
        yield return new WaitForSeconds
        (
            Random.Range(
                _startWait.x,
                _startWait.y)       
        );

        while (true)
        {
            _targetManeuvre = Random.Range(1, _dodge) * (-Mathf.Sign(transform.position.x));
            
            yield return new WaitForSeconds
            (
                Random.Range(
                    _maneuvreTime.x,
                    _maneuvreTime.y)
            );
            _targetManeuvre = 0;

            yield return new WaitForSeconds
            (
                Random.Range(
                    _maneuvreWait.x,
                    _maneuvreWait.y)
            );

        }
    }

    private void FixedUpdate()
    {
        float newManeuvre = Mathf.MoveTowards
        (
            GetComponent<Rigidbody>().velocity.x,
            _targetManeuvre,
            _maneuvreSpeed * Time.deltaTime
    
        );

        _rigidbody.velocity = new Vector3(newManeuvre, 0.0f, _currentSpeed);

        _rigidbody.position = new Vector3
        (
            Mathf.Clamp(_rigidbody.position.x, _boundary.xMin, _boundary.xMax),
            0.0f,
            Mathf.Clamp(_rigidbody.position.z, _boundary.zMin * 2, _boundary.zMax)
        );
        
        _rigidbody.rotation = Quaternion.Euler
           (
               0f,
               0f,
               _rigidbody.velocity.x * (-_tilt)
           );
    }

}
