using UnityEngine;
using UnityEngine.UI;

public class Viewer : MonoBehaviour
{
    [SerializeField] private Counter _counter;
    [SerializeField] private Text _text;

    private void OnEnable()
    {
        _counter.OnCounterUpdated += UpdateCounterText;
    }

    private void OnDisable()
    {
        _counter.OnCounterUpdated -= UpdateCounterText;
    }

    private void UpdateCounterText(int counterValue)
    {
        _text.text = "�������: " + counterValue;
    }

    private void Update()
    {
        int mouseClickButton = 0;

        if (Input.GetMouseButtonDown(mouseClickButton))
        {
            _counter.ToggleCounter();
        }
    }
}
