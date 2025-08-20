using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TitleCtrl : MonoBehaviour
{
    [SerializeField]public GameObject firstSelected;
    void Start()
    {
        EventSystem.current.SetSelectedGameObject(firstSelected);
    }
    void Update()
    {
        
    }
}
