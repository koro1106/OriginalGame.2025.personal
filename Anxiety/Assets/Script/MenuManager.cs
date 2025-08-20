using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject inventory;
    [SerializeField] private GameObject userGuide;
    [SerializeField] private GameObject setting;
    public bool isInventory = false;
    public void OnInventoryButton()
    {
        isInventory = true;
        inventory.SetActive(true);
        userGuide.SetActive(false);
        setting.SetActive(false);
    }
    public void OnSettingButton()
    {
        setting.SetActive(true);
        userGuide.SetActive(false);
        inventory.SetActive(false);
    }
    public void OnUserGuideButton()
    {
        userGuide.SetActive(true);
        setting.SetActive(false);
        inventory.SetActive(false);
    }
    public void OnBackToTitleButton()
    {
        SceneManager.LoadScene("TitleScene");
    }
}
