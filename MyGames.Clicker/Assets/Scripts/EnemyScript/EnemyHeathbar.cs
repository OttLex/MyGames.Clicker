using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHeathbar : MonoBehaviour
{
    //HealthBar
    [SerializeField] Slider _helthBar;
    private Color _lowHealthbar =  Color.red;
    private Color _highHealthbar = Color.green;
    [SerializeField] private Vector3 _heathbarOffset;

    public void SetHealth(int heath, int maxHelth)
    {
        _helthBar.gameObject.SetActive(heath < maxHelth);
        _helthBar.value = heath;
        _helthBar.maxValue = maxHelth;

        _helthBar.fillRect.GetComponentInChildren<Image>().color = Color.Lerp(_lowHealthbar, _highHealthbar, _helthBar.normalizedValue);
    }

    void Update()
    {
        _helthBar.transform.position = Camera.main.WorldToScreenPoint(transform.parent.position + _heathbarOffset);
    }
}
