using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test012Dlg : MonoBehaviour
{
    [SerializeField] ScrollRect m_scroll = null;
    [SerializeField] Text m_txtResult = null;
    [SerializeField] Button m_btnOk = null;
    [SerializeField] Button m_btnClear = null;

    [SerializeField] GameObject m_preItem = null;

    string[] m_animals = { "Ļ�ŷ�", "������ź", "�����ӱ�", "���ܿ��Ҹ�", "������", "ǳ�갳", "����" };

    ItemText m_curItem = null;

    private void Start()
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
        for (int i = 0; i < m_animals.Length; i++)
        {
            GameObject go = Instantiate(m_preItem, m_scroll.content);
            ItemText item = go.GetComponent<ItemText>();
            item.m_txt.text = m_animals[i];

            item.m_btn.onClick.AddListener(() => SelectedItem(item));
        }
    }

    void SelectedItem(ItemText item)
    {
        if (m_curItem != null)
            m_curItem.m_txt.color = Color.white;

        item.m_txt.color = Color.red;

        m_curItem = item;

        m_txtResult.text = item.m_txt.text;
    }

    void OnClicked_Ok()
    {
        if(m_curItem == null)
        {
            m_txtResult.text = "������ �������ּ���.";
            return;
        }

        m_txtResult.text = $"����� ������ ������ {m_curItem.m_txt.text}�Դϴ�.";
    }

    void OnClicked_Clear()
    {
        if (m_curItem != null)
            m_curItem.m_txt.color = Color.white;

        m_curItem = null;
        m_txtResult.text = "�ʱ�ȭ";
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
