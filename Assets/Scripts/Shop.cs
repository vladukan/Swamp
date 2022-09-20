using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] private List<Weapon> _weapons;
    [SerializeField] private Player _player;
    [SerializeField] private WeaponView _weaponTemplate;
    [SerializeField] private GameObject _container;

    private void Start()
    {
        for (int i = 0; i < _weapons.Count; i++) AddItem(_weapons[i]);
    }
    private void AddItem(Weapon weapon)
    {
        var view = Instantiate(_weaponTemplate, _container.transform);
        view.Render(weapon);
        view.SellBtnClick += OnSellBtnClick;
    }
    private void OnSellBtnClick(Weapon weapon, WeaponView view)
    {
        TrySellWeapon(weapon, view);
    }
    private void TrySellWeapon(Weapon weapon, WeaponView view)
    {
        if (weapon.Price <= _player.Money)
        {
            _player.BuyWeapon(weapon);
            weapon.Buy();
            view.SellBtnClick -= OnSellBtnClick;
        }
    }
}
