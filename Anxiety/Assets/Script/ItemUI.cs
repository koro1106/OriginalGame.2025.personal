using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemUI : MonoBehaviour
{
    [SerializeField] private GameObject[] itemImages;
    [SerializeField] private ItemGet itemGet;
    void Update()
    {
        switch (itemGet.itemCount)
        {
            case 0:
                foreach(var img in itemImages)
                {
                    img.SetActive(false);
                }
                break;
            case 1:
                foreach (var img in itemImages) img.SetActive(false);
                itemImages[0].SetActive(true);
                break;
            case 2:
                foreach (var img in itemImages) img.SetActive(false);
                itemImages[0].SetActive(true);
                itemImages[1].SetActive(true);
                break;
            case 3:
                foreach (var img in itemImages) img.SetActive(false);
                itemImages[0].SetActive(true);
                itemImages[1].SetActive(true);
                itemImages[2].SetActive(true);
                break;
            case 4:
                foreach (var img in itemImages) img.SetActive(true);
                itemImages[4].SetActive(false);
                itemImages[5].SetActive(false);
                break;
            case 5:
                foreach (var img in itemImages) img.SetActive(true);
                itemImages[5].SetActive(false);
                break;
            case 6:
                foreach (var img in itemImages) img.SetActive(true);
                break;
        }
    }
}
