using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject _startCanvas;
    [SerializeField] private GameObject _shopCanvas;
    [SerializeField] private GameObject _extrasCanvas;

    public void LoadGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("EndlesGame");
    }

    public void ShowExtras()
    {
        _startCanvas.SetActive(false);
        _extrasCanvas.SetActive(true);
    }

    public void HideExtras()
    {
        _startCanvas.SetActive(true);
        _extrasCanvas.SetActive(false);
    }
    public void OpenShop()
    {
        _startCanvas.SetActive(false);
        _shopCanvas.SetActive(true);
    }
    public void CloseShop()
    {
        _startCanvas.SetActive(true);
        _shopCanvas.SetActive(false);
    }
}
