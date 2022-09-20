using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

public class WeaponView : MonoBehaviour
{
    [SerializeField] private TMP_Text _label;
    [SerializeField] private TMP_Text _price;
    [SerializeField] private Image _icon;
    [SerializeField] private Button _buyBtn;
    private Weapon _weapon;
    public event UnityAction<Weapon, WeaponView> SellBtnClick;
    public void Render(Weapon weapon)
    {
        _weapon = weapon;
        _label.text = weapon.Label;
        _price.text = weapon.Price.ToString();
        _icon.sprite = weapon.Icon;
    }
    private void OnEnable()
    {
        _buyBtn.onClick.AddListener(OnBtnClick);
        _buyBtn.onClick.AddListener(TryLockItem);
    }
    private void OnDisable()
    {
        _buyBtn.onClick.RemoveListener(OnBtnClick);
        _buyBtn.onClick.RemoveListener(TryLockItem);
    }
    private void TryLockItem()
    {
        if (_weapon.IsBuyed) _buyBtn.interactable = false;
    }
    private void OnBtnClick()
    {
        SellBtnClick?.Invoke(_weapon, this);
    }
}
