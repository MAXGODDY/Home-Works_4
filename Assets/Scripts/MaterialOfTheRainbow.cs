using System.Collections;
using UnityEngine;

public class MaterialOfTheRainbow : MonoBehaviour
{
    [SerializeField] private Renderer _targetMaterial;
    [SerializeField] private float _coroutineDuration = 1f;
    [SerializeField] private float _colorDelay = 0.5f;
    [SerializeField] private Color[] _targetColors = new Color[7];

    private int _index = 0;


    private void Start()
    {
        StartCoroutine(Rainbow(_targetMaterial, _coroutineDuration));
    }



    private IEnumerator Rainbow(Renderer material, float duration)
    {
        while (true)
        {

            yield return new WaitForSeconds(_colorDelay);


            Color startColor = material.material.color;
            Color targetColor = _targetColors[_index];
            float currentTime = 0f;



            while (currentTime < duration)
            {
                material.material.color = Color.Lerp(startColor, targetColor, currentTime / duration);
                currentTime += Time.deltaTime;
                yield return null;

            }


            material.material.color = targetColor;
            _index = (_index + 1) % _targetColors.Length;

        }
    }
}
