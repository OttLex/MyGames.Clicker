using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private Button _startButton;
    [SerializeField] private Button _extrasButton;
    [SerializeField] private GameObject _extrasPanel;

    public void LoadGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Game");
    }

    public void ShowExtras()
    {
        _extrasButton.gameObject.SetActive(false);
        _startButton.gameObject.SetActive(false);
        _extrasPanel.gameObject.SetActive(true);
    }

    public void HideExtras()
    {
        _extrasButton.gameObject.SetActive(true);
        _startButton.gameObject.SetActive(true);
        _extrasPanel.gameObject.SetActive(false);
    }
}
