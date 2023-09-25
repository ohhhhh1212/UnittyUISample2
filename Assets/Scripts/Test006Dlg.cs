using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test006Dlg : MonoBehaviour
{
    [SerializeField] Scrollbar m_scroll = null;
    [SerializeField] Text m_result = null;
    [SerializeField] Button m_btnOk = null;
    [SerializeField] Button m_btnClear = null;

    void Start()
    {
        Init();
    }

    void Init()
    {
        m_btnOk.onClick.AddListener(OnClicked_Ok);
        m_btnClear.onClick.AddListener(OnClicked_Clear);
        m_scroll.onValueChanged.AddListener(OnValueChanged_Scroll);
    }

    void OnClicked_Ok()
    {
        m_result.text = string.Format("현재 진행된 값은 {0:0.00} 입니다.", m_scroll.value);
    }

    void OnClicked_Clear()
    {
        m_result.text = "초기화";
        m_scroll.value = 0;
    }

    void OnValueChanged_Scroll(float value)
    {
        m_result.text = string.Format("{0:0.00}", value);
    }
}
