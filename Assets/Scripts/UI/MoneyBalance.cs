using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyBalance : MonoBehaviour
{
    [SerializeField] private TMP_Text _money;
    [SerializeField] private Player _player;

    private void OnEnable()
    {
        _money.text = _player.Money.ToString();
        _player.MoneyChanged += OnChangedMoney;
    }
    private void OnDisable()
    {
        _player.MoneyChanged -= OnChangedMoney;
    }

    private void OnChangedMoney(int money)
    {
        _money.text = money.ToString();
    }

}
