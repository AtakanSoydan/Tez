using UnityEngine;
using UnityEngine.InputSystem;
using DG.Tweening;

public class CameraManager : MonoBehaviour
{
    #region Variables

    private Vector2 _delta;

    private bool _isMoving;
    private bool _isRotating;
    private bool _isBusy;

    private float _xRotation;

    [Header("Camera Settings")]
    [SerializeField] private float movementSpeed = 10.0f;
    [SerializeField] private float rotationSpeed = 0.5f;

    [SerializeField] private float zoomChange;
    [SerializeField] private float smoothChange;
    [SerializeField] private float minSize, maxSize;

    [SerializeField] private float followSpeed = 3f;
    [SerializeField] private Transform player;
    private Camera cam;

    #endregion

    private void Awake()
    {
        _xRotation = transform.rotation.eulerAngles.x;
        cam = GetComponent<Camera>();
    }
    private void Update()
    {
        ZoomControl();
    }
    public void OnLook(InputAction.CallbackContext context)
    {
        _delta = context.ReadValue<Vector2>();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        _isMoving = context.started || context.performed;
    }

    public void OnRotate(InputAction.CallbackContext context)
    {
        if (_isBusy) return;

        _isRotating = context.started || context.performed;

        if (context.canceled)
        {
            _isBusy = true;
            SnapRotation();
        }
    }

    private void LateUpdate()
    {
        if (_isMoving)
        {
            var position = transform.right * (_delta.x * -movementSpeed);
            position += transform.up * (_delta.y * -movementSpeed);
            transform.position += position * Time.deltaTime;
        }

        if (_isRotating)
        {
            transform.Rotate(new Vector3(_xRotation, _delta.x * rotationSpeed, 0.0f));
            transform.rotation = Quaternion.Euler(_xRotation, transform.rotation.eulerAngles.y, 0.0f);
        }

        FollowPlayer();
    }

    private void SnapRotation()
    {
        transform.DORotate(SnappedVector(), 0.5f)
            .SetEase(Ease.OutBounce)
            .OnComplete(() =>
            {
                _isBusy = false;
            });
    }

    private Vector3 SnappedVector()
    {
        var endValue = 0.0f;
        var currentY = Mathf.Ceil(transform.rotation.eulerAngles.y);

        endValue = currentY switch
        {
            >= 0 and <= 90 => 45.0f,
            _ => 225.0f
        };

        return new Vector3(_xRotation, endValue, 0.0f);
    }

    private void ZoomControl()
    {
        if (Input.mouseScrollDelta.y > 0)
        {
            cam.orthographicSize -= zoomChange * Time.deltaTime * smoothChange;
        }
        if (Input.mouseScrollDelta.y < 0)
        {
            cam.orthographicSize += zoomChange * Time.deltaTime * smoothChange;
        }

        cam.orthographicSize = Mathf.Clamp(cam.orthographicSize, minSize, maxSize);
    }


    private void FollowPlayer()
    {
        if (player == null)
        {
            Debug.LogWarning("No target assigned to the FollowCamera! Assign a target in the Inspector.");
            return;
        }

        // Hedef pozisyonunu al
        Vector3 targetPosition = player.position;

        // Yalnýzca x ve z eksenlerini kullanarak karakterin konumunu belirle
        Vector3 desiredPosition = new Vector3(targetPosition.x, transform.position.y, targetPosition.z);

        // Kamerayý yavaþça karakterin konumuna taþý
        transform.position = Vector3.Lerp(transform.position, desiredPosition, followSpeed * Time.deltaTime);
    }
}

