using UnityEngine;

public class CharacterController : MonoBehaviour, IPauseHandler
{
    [SerializeField] private float _speed;
    [SerializeField] private Boundary _boundary;

    private Camera _mainCamera;
    private bool _isPaused;
    
    public void Start()
    {
        _mainCamera = Camera.main;
    }
    
    private void Update()
    {
        if (_isPaused)
            return;

        if (Input.GetMouseButton(0))
        {
            Vector3 mousePosition = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
            MovePlayer(mousePosition);
            return;
        }

        if (Input.touchCount == 1)
        {
            Touch touch = Input.touches[0];
            Vector3 touchPosition = _mainCamera.ScreenToWorldPoint(touch.position);
            MovePlayer(touchPosition);
        }
    }
    
    private void MovePlayer(Vector3 pressedPosition)
    {
        pressedPosition.y = transform.position.y;
        pressedPosition.z += 1f;
        
        if (pressedPosition.z <= _boundary.zMax && pressedPosition.z >= _boundary.zMin)
        {
            transform.position = Vector3.MoveTowards(transform.position, pressedPosition,
                _speed + PlayerPrefs.GetFloat("Speed"));
        }
    }
    
    public void SetPaused(bool isPaused)
    {
        _isPaused = isPaused;
    }

}
