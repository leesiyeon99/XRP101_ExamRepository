using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupController : MonoBehaviour
{
    [SerializeField] private float _deactiveTime;
    private WaitForSeconds _wait;
    private Button _popupButton;
    Coroutine _popupCoroutine;

    [SerializeField] private GameObject _popup;

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        _wait = new WaitForSeconds(_deactiveTime);
        _popupButton = GetComponent<Button>();
        SubscribeEvent();
    }

    private void SubscribeEvent()
    {
        _popupButton.onClick.AddListener(Activate);
    }

    private void Activate()
    {
        _popup.gameObject.SetActive(true);
        GameManager.Intance.Pause();
        if (_popupCoroutine == null)
        {
            _popupCoroutine = StartCoroutine(DeactivateRoutine());
        }
    }

    private void Deactivate()
    {
        _popup.gameObject.SetActive(false);
        Debug.Log("비활성화2");
    }

    private IEnumerator DeactivateRoutine()
    {
        yield return _wait;
        Debug.Log("비활성화1");
        Deactivate();
        _popupCoroutine = null;
    }
}
