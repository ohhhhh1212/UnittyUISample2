using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test001Dlg : MonoBehaviour
{
    [SerializeField] InputField m_inputName = null;
    [SerializeField] Text m_txtResult = null;
    [SerializeField] Button m_ok = null;
    [SerializeField] Button m_clear = null;

    void Start()
    {
        Init();
    }

    void Init()
    {
        m_ok.onClick.AddListener(OnClicked_OK);
        m_clear.onClick.AddListener(OnClicked_Clear);
        m_inputName.onSubmit.AddListener(OnSubmit_Name);
    }

    void OnClicked_OK()
    {
        m_txtResult.text = $"<color=#CAFF00>당신이 입력한 이름은 <color=#FF7000>{m_inputName.text}</color>입니다.</color>";
    }

    void OnClicked_Clear()
    {
        m_inputName.text = string.Empty;
        m_txtResult.text = "초기화";
    }

    void OnSubmit_Name(string str)
    {
        m_txtResult.text = $"<color=#CAFF00>입력이 끝났습니다. <color=#FF7000>{str}</color></color>";
    }
}
