
using UnityEngine;
using UnityEngine.UI;

public class WinLoseText : MonoBehaviour, IObserver<bool>
{
    [SerializeField] private GameObject _winText;
    [SerializeField] private GameObject _loseText;
    [SerializeField] private WinCondition _winCondition;

    private void Start()
    {
        _winCondition?.Subscribe(this);
    }

    public void OnNotify(bool result, params object[] args)
    {
        if (result)
        {
            _winText.SetActive(true);
        }
        else
        {
            _loseText.SetActive(false);
        }
    }
}
