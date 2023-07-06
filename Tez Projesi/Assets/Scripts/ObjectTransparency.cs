using UnityEngine;

public class ObjectTransparency : MonoBehaviour
{
    public KeyCode key = KeyCode.H;
    public string newLayerName = "Wall";
    public string newLayerName2 = "Default";

    private bool isVisible = true;

    public GameObject[] walls;

    private void Update()
    {
        if (Input.GetKeyDown(key))
        {
            ChangeLayer();
            isVisible = !isVisible;
        }
    }

    private void ChangeLayer()
    {
        foreach (var wall in walls)
        {
            if (isVisible)
            {
                wall.gameObject.layer = LayerMask.NameToLayer(newLayerName);
            }
            else
            {
                wall.gameObject.layer = LayerMask.NameToLayer(newLayerName2);
            }

        }
        
    }
}
