using System.Collections;
using UnityEngine;

public class MaterialOfTheRainbow : MonoBehaviour
{
    [SerializeField] private Renderer _targetMaterial;
    [SerializeField] private float _coroutineDuration = 1f;
    [SerializeField] private Color[] _targetColors = new Color[7];

    private int _index = 0;


    private void Start()
    {
        StartCoroutine(Rainbow(_targetMaterial.material, _coroutineDuration));
    }
    private IEnumerator Rainbow(Material material, float duration)
    {
        while (true)
        {
            Color startColor = material.color;
            Color targetColor = _targetColors[_index];
            float currentTime = 0f;

            while (currentTime < duration)
            {
                material.color = Color.Lerp(startColor, targetColor, currentTime / duration);
                currentTime += Time.deltaTime;
                yield return null;

            }
            material.color = targetColor;
            _index = (_index + 1) % _targetColors.Length;

        }
    }
}
