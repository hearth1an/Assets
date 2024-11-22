using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{    
    private int _minNumber = 0;
    private float _delay = 0.5f;
    private bool _isCounting = false;

    private Coroutine _counterCoroutine;
    private WaitForSeconds _waitForSeconds;

    private void Start()
    {
        _waitForSeconds = new WaitForSeconds(_delay);
    }

    public void ToggleCounter()
    {
        if (_isCounting)
        {
            StopCoroutine(_counterCoroutine);
            _isCounting = false;
        }
        else
        {
            _counterCoroutine = StartCoroutine(CounterRoutine());
            _isCounting = true;
        }        
    }    

    private IEnumerator CounterRoutine()
    {
        while (true)
        {
            yield return _waitForSeconds;

            _minNumber++;
            OnCounterUpdated?.Invoke(_minNumber);
        }
    }

    public event System.Action<int> OnCounterUpdated;
}
