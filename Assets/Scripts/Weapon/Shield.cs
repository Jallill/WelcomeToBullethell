using UnityEngine;

public class Shield : MonoBehaviour, IShield<DamageType>
{
    [SerializeField] private ShieldSO _shieldSo;
    [SerializeField] private GameObject _shield;

    private bool _activeShield;

    public bool ActiveShield => _activeShield;
    public DamageType DefenseType => _shieldSo.DefenseType;
    
    public void ActivateShield()
    {
        _activeShield = true;
        _shield.SetActive(_activeShield);
    }

    public void DeactivateShield()
    {
        _activeShield = false;
        _shield.SetActive(false);
    }
}