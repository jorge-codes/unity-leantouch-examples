using UnityEngine;
using Lean.Touch;

public class TapIndicatorController : MonoBehaviour
{
    [SerializeField] private Animator animator = null;
    [SerializeField] private string animationTrigger = "Tap";
    
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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Animate()
    {
        animator.SetTrigger(animationTrigger);
    }

    private void HandleFingerTap(LeanFinger finger)
    {
        // print($"TapIndicatorController.HandleFingerTap");
        // var cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        // var worldPosition = cam.ScreenToWorldPoint(finger.ScreenPosition);
        Animate();
    }
}
