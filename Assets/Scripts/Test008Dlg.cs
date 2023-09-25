using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test008Dlg : MonoBehaviour
{
    [SerializeField] Dropdown m_dropdown = null;
    [SerializeField] Text m_result = null;
    [SerializeField] Button m_btnOk = null;
    [SerializeField] Button m_btnClear = null;

    string[] m_city = { "인천", "대전", "대구", "광주", "울산", "부산" };

    int m_curOptionIdx = -1;

    void Start()
    {
        Init();
    }

    void Init()
    {
        m_btnOk.onClick.AddListener(OnClicked_Ok);
        m_btnClear.onClick.AddListener(OnClicked_Clear);
        m_dropdown.onValueChanged.AddListener(OnValueChanged_Drop);
    }

    void OnClicked_Ok()
    {
        if(m_curOptionIdx == -1)
        {
            m_result.text = "값을 선택해주세요";
            return;
        }

        string str = $"당신이 이동할 도시는 {m_city[m_curOptionIdx]}입니다.";
        m_result.text = str;
    }

    void OnClicked_Clear()
    {
        m_curOptionIdx = -1;
        m_result.text = "초기화";
    }

    void OnValueChanged_Drop(int value)
    {
        m_curOptionIdx = value;
        m_result.text = m_city[value];
    }
}
