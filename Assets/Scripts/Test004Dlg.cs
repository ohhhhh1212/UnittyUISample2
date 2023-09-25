using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test004Dlg : MonoBehaviour
{
    [SerializeField] Slider m_slider = null;
    [SerializeField] Text m_txtResult = null;
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
        m_slider.onValueChanged.AddListener(OnValueChanged_Slider);
    }

    void OnClicked_Ok()
    {
        m_txtResult.text = $"���� ����� ���� {m_slider.value} �Դϴ�.";
    }

    void OnClicked_Clear()
    {
        m_txtResult.text = "�ʱ�ȭ";
    }

    void OnValueChanged_Slider(float value)
    {
        m_txtResult.text = $"{value}";
    }
}
