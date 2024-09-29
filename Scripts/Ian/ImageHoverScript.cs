using UnityEngine;
using UnityEngine.UI;

public class ImageHoverScript : MonoBehaviour
{
    public bool isEnabled;
    public float rotationSpeed = 2f;
    public float hoverRotationAngle = -0.3f;

    private Quaternion originalRotation;
    private RectTransform rectTransform;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        originalRotation = rectTransform.localRotation;
    }

    void Update()
    {
        if (isEnabled)
        {
            Quaternion targetRotation = Quaternion.Euler(0f, 0f, hoverRotationAngle);
            rectTransform.localRotation = Quaternion.Slerp(rectTransform.localRotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
        else
        {
            rectTransform.localRotation = Quaternion.Slerp(rectTransform.localRotation, originalRotation, rotationSpeed * Time.deltaTime);
        }
       
    }

    bool IsMouseOver()
    {
        Vector2 mousePos = Input.mousePosition;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(rectTransform, mousePos, null, out Vector2 localPoint);
        return rectTransform.rect.Contains(localPoint);
    }

    public void hover()
    {
        isEnabled = true;
    }

    public void unHover()
    {
        isEnabled = false;
    }
}
