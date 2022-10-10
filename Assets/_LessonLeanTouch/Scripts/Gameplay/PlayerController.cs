using UnityEngine;
using Lean.Touch;

public class PlayerController : MonoBehaviour
{
    [Header("Gameplay Settings")]
    [SerializeField] private Camera mainCamera = null;
    [SerializeField] private SpriteRenderer spriteRenderer = null;
    [Header("Audio Settings")]
    [SerializeField] private AudioSource audioSource = null;
    [SerializeField] private AudioClip clipShoot = null;
    private Bounds cameraBounds;
    private void OnEnable()
    {
        LeanTouch.OnFingerTap += HandleFingerTap;
    }

    private void OnDisable()
    {
        LeanTouch.OnFingerTap -= HandleFingerTap;
    }

    // Start is called before the first frame update
    void Start()
    {
        if (mainCamera == null)
        {
            mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        }
        cameraBounds = GetOrthoCameraBounds(mainCamera);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LateUpdate()
    {
        transform.position = ClampPlayerPosition(transform.position, spriteRenderer.bounds, cameraBounds);
    }

    private void Shoot()
    {
        audioSource.PlayOneShot(clipShoot);
    }

    private void HandleFingerTap(LeanFinger finger)
    {
        Shoot();
    }

    private Bounds GetOrthoCameraBounds(Camera cam)
    {
        var bounds = new Bounds();
        var halfHeight = cam.orthographicSize;
        var halfWidth = halfHeight * cam.aspect;
        
        bounds.center = cam.transform.position;
        bounds.extents = new Vector3(halfWidth, halfHeight);
        // print("Bounds max");
        // print(bounds.max.ToString());
        // print("Bounds min");
        // print(bounds.min.ToString());
        // print("Bounds size");
        // print(bounds.size.ToString());
        return bounds;
    }

    private Vector3 ClampPlayerPosition(Vector3 playerPosition, Bounds playerBounds, Bounds gameBounds)
    {
        var newPosition = playerPosition;

        // clamping bottom
        if (playerPosition.y - playerBounds.extents.y < gameBounds.min.y)
        {
            newPosition.y = gameBounds.min.y + playerBounds.extents.y;
        }
        // clamping top
        if (playerPosition.y + playerBounds.extents.y > gameBounds.max.y)
        {
            newPosition.y = gameBounds.max.y - playerBounds.extents.y;
        }
        // clamping right
        if (playerPosition.x + playerBounds.extents.x > gameBounds.max.x)
        {
            newPosition.x = gameBounds.max.x - playerBounds.extents.x;
        }
        // clamping left
        if (playerPosition.x - playerBounds.extents.x < gameBounds.min.x)
        {
            newPosition.x = gameBounds.min.x + playerBounds.extents.x;
        }

        // optimizacion opcional trabajando solo con bounds de cada objeto
        // if (playerBounds.min.y < gameBounds.min.y)
        // {
        //     newPosition.y = gameBounds.min.y + playerBounds.extents.y;
        // }    

        return newPosition;
    }
}
