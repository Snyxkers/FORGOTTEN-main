
using UnityEngine;
using UnityEngine.UI;

public class CrosshairController : MonoBehaviour
{
    [Header("Crosshair Settings")]
    public Color crosshairColor = Color.white;
    public float size = 8f;
    public float gap = 5f;
    public float thickness = 2f;

    private Canvas crosshairCanvas;

    void Start()
    {
        CreateCrosshair();
    }

    void CreateCrosshair()
    {
        // Create a UI Canvas
        GameObject canvasObject = new GameObject("CrosshairCanvas");

        crosshairCanvas = canvasObject.AddComponent<Canvas>();
        crosshairCanvas.renderMode = RenderMode.ScreenSpaceOverlay;

        CanvasScaler scaler =
            canvasObject.AddComponent<CanvasScaler>();
        scaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;

        canvasObject.AddComponent<GraphicRaycaster>();

        // Create the four lines
        CreateLine("Top", 0, gap + size / 2,
            thickness, size);

        CreateLine("Bottom", 0, -(gap + size / 2),
            thickness, size);

        CreateLine("Left", -(gap + size / 2), 0,
            size, thickness);

        CreateLine("Right", gap + size / 2, 0,
            size, thickness);
    }

    void CreateLine(string lineName, float x, float y,
        float width, float height)
    {
        GameObject line = new GameObject(lineName);

        line.transform.SetParent(crosshairCanvas.transform, false);

        Image image = line.AddComponent<Image>();
        image.color = crosshairColor;
        image.raycastTarget = false;

        RectTransform rect = line.GetComponent<RectTransform>();

        rect.anchorMin = new Vector2(0.5f, 0.5f);
        rect.anchorMax = new Vector2(0.5f, 0.5f);
        rect.pivot = new Vector2(0.5f, 0.5f);
        rect.anchoredPosition = new Vector2(x, y);
        rect.sizeDelta = new Vector2(width, height);
    }
}
