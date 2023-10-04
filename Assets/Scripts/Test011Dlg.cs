using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test011Dlg : MonoBehaviour
{
    [SerializeField] ScrollRect m_scroll = null;
    [SerializeField] Text m_txtResult = null;
    [SerializeField] Button m_btnOk = null;
    [SerializeField] Button m_btnClear = null;
    [SerializeField] GameObject m_preItem = null;

    string[] m_City = { "��⵵", "������", "��û��", "����", "���" };

    Item2 m_curItem = null;

    void Start()
    {
        Init();
    }

    void Init()
    {
        m_btnOk.onClick.AddListener(OnClicked_Ok);
        m_btnClear.onClick.AddListener(OnClicked_Clear);
        CreateItem();
    }

    void CreateItem()
    {
        for (int i = 0; i < m_City.Length; i++)
        {
            GameObject go = Instantiate(m_preItem, m_scroll.content);
            Item2 item = go.GetComponent<Item2>();
            item.m_txt.text = m_City[i];

            item.m_btn.onClick.AddListener(() => SelectedItem(item));
        }
    }

    void SelectedItem(Item2 item)
    {
        if (m_curItem != null)
            m_curItem.m_img.color = Color.white;

        item.m_img.color = Color.green;

        m_txtResult.text = item.m_txt.text;

        m_curItem = item;
    }

    void OnClicked_Ok()
    {
        if (m_curItem == null)
        {
            m_txtResult.text = "������ �������ּ���.";
            return;
        }

        m_txtResult.text = $"����� ������ ������ {m_curItem.m_txt.text}�Դϴ�.";
    }

    void OnClicked_Clear()
    {
        m_txtResult.text = "�ʱ�ȭ";
        if (m_curItem != null)
            m_curItem.m_img.color = Color.white;
        m_curItem = null;
    }

    void DestroyItem()
    {
        for (int i = 0; i < m_scroll.content.childCount; i++)
        {
            Destroy(m_scroll.content.GetChild(i).gameObject);
        }
    }

    private void OnDestroy()
    {
        DestroyItem();
    }
}
