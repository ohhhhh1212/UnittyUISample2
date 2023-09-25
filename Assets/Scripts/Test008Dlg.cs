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

    string[] m_city = { "��õ", "����", "�뱸", "����", "���", "�λ�" };

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
            m_result.text = "���� �������ּ���";
            return;
        }

        string str = $"����� �̵��� ���ô� {m_city[m_curOptionIdx]}�Դϴ�.";
        m_result.text = str;
    }

    void OnClicked_Clear()
    {
        m_curOptionIdx = -1;
        m_result.text = "�ʱ�ȭ";
    }

    void OnValueChanged_Drop(int value)
    {
        m_curOptionIdx = value;
        m_result.text = m_city[value];
    }
}
