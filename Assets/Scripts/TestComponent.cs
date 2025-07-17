using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class TestComponent : MonoBehaviour
{

    [SerializeField] private Image _testImage;
    [Header("Test Component")]
    [SerializeField] private float _corotineDuration;
    [SerializeField] private float _durationOfColorDelay;
    [SerializeField] private Color[] _targetColor = new Color[7];


    int _indes = 0;

    private void Start()
    {
            StartCoroutine(Rainbow(_testImage, _corotineDuration, _targetColor[_indes]));
    }




    private IEnumerator Rainbow(Image image, float deration, Color targetColor)
    {
        yield return new WaitForSeconds(_durationOfColorDelay);
        if (_indes == 6)
        {
            _indes = -1;
        }

        float currentTime = 0;
        Color startColor = image.color;
        Color currentColor;

        while (currentTime < deration)
        {
            currentColor = Color.Lerp(startColor, targetColor, currentTime / deration);
            image.color = currentColor;
            currentTime += Time.deltaTime;
            yield return null;
        }
        image.color = targetColor;
        _indes++;
        StartCoroutine(Rainbow(image, deration, _targetColor[_indes]));
    }

}
