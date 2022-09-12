using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class VisualTimer : MonoBehaviour
{
    [SerializeField] private Slider _timerSlider;
    [SerializeField] private float _maxTime;

    [SerializeField] private UnityEvent _OnEndOfTimerEvent;

    // Start is called before the first frame update
    void Start()
    {
        _timerSlider.value = _timerSlider.maxValue;
        StartCoroutine(StartTimer());
    }

    private IEnumerator StartTimer()
    {
        float currentTimer = _maxTime;

        while(currentTimer > 0)
        {
            currentTimer -= Time.deltaTime;
            yield return new WaitForEndOfFrame();
            UpdateSlider(currentTimer);
        }

        _OnEndOfTimerEvent?.Invoke();
    }

    private void UpdateSlider(float currentTimer)
    {
        float sliderValue = currentTimer / _maxTime;
        _timerSlider.value = sliderValue;
    }
}
