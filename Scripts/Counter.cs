using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{    
    private int _minNumber = 0;
    private float _delay = 0.5f;
    private bool _isCounting = false;

    private Coroutine _coroutine;
    private WaitForSeconds _waitForSeconds;

    public event System.Action<int> CounterUpdated;

    private void Start()
    {
        _waitForSeconds = new WaitForSeconds(_delay);
    }

    public void Toggle()
    {
        if (_isCounting)
        {
            StopCoroutine(_coroutine);
            _isCounting = false;
        }
        else
        {
            _coroutine = StartCoroutine(Routine());
            _isCounting = true;
        }        
    }    

    private IEnumerator Routine()
    {
        while (true)
        {
            yield return _waitForSeconds;

            _minNumber++;
            CounterUpdated?.Invoke(_minNumber);
        }
    }
}
