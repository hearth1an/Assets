using UnityEngine;
using UnityEngine.UI;

public class Viewer : MonoBehaviour
{
    [SerializeField] private Counter _counter;
    [SerializeField] private Text _text;

    private void Update()
    {
        int mouseClickButton = 0;

        if (Input.GetMouseButtonDown(mouseClickButton))
        {
            _counter.Toggle();
        }
    }

    private void OnEnable()
    {
        _counter.CounterUpdated += UpdateCounterText;
    }

    private void OnDisable()
    {
        _counter.CounterUpdated -= UpdateCounterText;
    }

    private void UpdateCounterText(int counterValue)
    {
        _text.text = "Ñ÷¸ò÷èê: " + counterValue;
    }    
}
