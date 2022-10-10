using TMPro;
using UnityEngine;

public class PanelInfoView : MonoBehaviour
{
    [SerializeField] private Camera mainCam = null;
    [SerializeField] private TextMeshProUGUI labelResolution = null;
    [SerializeField] private TextMeshProUGUI mousePosition = null;
    [SerializeField] private TextMeshProUGUI viewportPosition = null;
    
    void Start()
    {
        labelResolution.text = GetCurrentResolutionText();
    }
    

    private void OnGUI()
    {
        labelResolution.text = GetCurrentResolutionText();
        mousePosition.text = GetCurrentMousePositionText();
        viewportPosition.text = GetCurrentViewportPositionText();
    }
    
    private string GetCurrentResolutionText()
    {
        return $"{Screen.width}x{Screen.height}";
    }

    private string GetCurrentMousePositionText()
    {
        var mp = Input.mousePosition;
        return $"x:{mp.x.ToString("0.00")}\ty:{mp.y.ToString("0.00")}";
    }

    private string GetCurrentViewportPositionText()
    {
        var vp = mainCam.ScreenToViewportPoint(Input.mousePosition);
        return $"a:{vp.x}\tb:{vp.y}";
    }
}
