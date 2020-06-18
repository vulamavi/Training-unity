﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabGroup : MonoBehaviour
{
    public List<TabButton> tabButtons;
    public Sprite tabIdle;
    public Sprite tabHover;
    public Sprite tabActive;
    public TabButton selectedTab;
    public List<GameObject> objectsViewScroll;
    public void Start()
    {
        
    }
    public void Subscribe(TabButton button)
    {
        if (tabButtons == null)
        {
            tabButtons = new List<TabButton>();

        }
        tabButtons.Add(button);
    }
    public void OnTabEnter(TabButton button)
    {
        ResetTab();
        if (selectedTab == null || button != selectedTab)
        {
            button.GetComponentInChildren<SpriteRenderer>().sprite = tabHover;
            //button.background.sprite = tabHover;
        }
    }
    public void OnTabExit(TabButton button)
    {
        ResetTab();
    }
    public void OnTabSelected(TabButton button)
    {
        selectedTab = button;
        ResetTab();
        button.GetComponentInChildren<SpriteRenderer>().sprite = tabActive;
        //button.background.sprite = tabActive;
        int index = button.transform.GetSiblingIndex();
        for(int i = 0; i < objectsViewScroll.Count; i++)
        {
            if (i == index)
            {
                objectsViewScroll[i].SetActive(true);
            }
            else
            {
                objectsViewScroll[i].SetActive(false);
            }
        }
    }

    public void ResetTab() { 
        foreach(TabButton button in tabButtons)
        {
            if (selectedTab != null && button == selectedTab)
            {
                continue;
            }
            button.GetComponentInChildren<SpriteRenderer>().sprite = tabIdle;
            button.background.sprite = tabIdle;
        }
    }
    
}
