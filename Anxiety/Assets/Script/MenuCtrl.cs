using UnityEngine;

public class MenuCtrl : MonoBehaviour
{
    public bool isMenuOpne;
    public GameObject menuObject;
    public GameObject settingObject;
    public GameObject userGuideObject;

    void Start()
    {
        menuObject.SetActive(false);
        settingObject.SetActive(false);
        userGuideObject.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab) && !isMenuOpne)
        {
            isMenuOpne = true;
        }
        else if (Input.GetKeyDown(KeyCode.Tab) && isMenuOpne)
        {
            isMenuOpne = false;
        }

        if (isMenuOpne)
        {
            menuObject.SetActive(true);
        }
        else
        {
            menuObject.SetActive(false);
        }
    }
}
