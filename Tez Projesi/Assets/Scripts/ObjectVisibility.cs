using UnityEngine;

public class ObjectVisibility : MonoBehaviour
{
    private float fadeSpeed = 2;
    private float originalOpacitiy;
    Material[] _materials;

    private void Awake()
    {
        _materials = GetComponent<Renderer>().materials;

        foreach (Material material in _materials)
        {
            originalOpacitiy = material.color.a;
        }
    }

    private void Update()
    {
        ResetFade();
    }

    private void ResetFade()
    {
        foreach (Material material in _materials)
        {
            Color currenColor = material.color;
            Color smoothColor = new Color(currenColor.r, currenColor.g, currenColor.b, Mathf.Lerp(currenColor.a, originalOpacitiy, fadeSpeed * Time.deltaTime));
            material.color = smoothColor;
        }
    }
}

