using UnityEngine;

public class WallVisibility : MonoBehaviour
{
    public string newLayerName = "Wall";
    public string newLayerName2 = "Default";

    private bool isVisible = true;

    public GameObject[] walls_225f;
    public GameObject[] walls_45f;

    private float targetAngle = 225f;
    private float targetAngle2 = 45f;
    private float angleThreshold = 90f;

    private void Update()
    {
        ChangeLayer();
        ToggleVisibility();
    }

    private void ChangeLayer()
    {
        SetWallLayer(walls_225f, targetAngle, newLayerName, newLayerName2);
        SetWallLayer(walls_45f, targetAngle2, newLayerName, newLayerName2);
    }

    private void SetWallLayer(GameObject[] walls, float targetAngle, string defaultLayer, string newLayer)
    {
        foreach (var wall in walls)
        {
            Quaternion cameraRotation = Camera.main.transform.rotation;
            float cameraYAngle = cameraRotation.eulerAngles.y;
            float angleDifference = Mathf.Abs(cameraYAngle - targetAngle);

            if (angleDifference <= angleThreshold)
            {
                SetWallVisibility(wall, true, newLayer);
            }
            else
            {
                SetWallVisibility(wall, false, defaultLayer);
            }
        }
    }

    private void SetWallVisibility(GameObject wall, bool isVisible, string layerName)
    {
        wall.gameObject.layer = LayerMask.NameToLayer(layerName);
        this.isVisible = isVisible;
    }

    private void ToggleVisibility()
    {
        isVisible = !isVisible;
    }
}
