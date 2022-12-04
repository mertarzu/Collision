using TMPro;
using UnityEngine;

public class DepthView : UIView
{
    [SerializeField] TextMeshProUGUI _depthText;
    [SerializeField] CircleCircleCollision _circleCircleCollision;
    public override void Initialize()
    {
        _depthText.text = "Penetration Depth: " + PlayerHelper.Depth.ToString("N5");
        _circleCircleCollision.OnDepthChange += UpdateView;
    }
    public override void SetActive(bool isActive)
    {
        gameObject.SetActive(isActive);
    }
    public override void UpdateView()
    {
        _depthText.text = "Penetration Depth: " + PlayerHelper.Depth.ToString("N5");

    }
}
                                                            