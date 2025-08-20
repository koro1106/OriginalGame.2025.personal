using UnityEngine;

public class Tutorial : MonoBehaviour
{
    [SerializeField] private GameObject[] tutorialSteps;
    [SerializeField] private MenuManager menuManager;
    private MenuCtrl menuCtrl;
    public  int currentStep = 0;
    private ItemGet item;
    public bool isTutorial = false;
    void Start()
    {
        ShowStep(currentStep);
        item = GetComponent<ItemGet>();
        menuCtrl = GetComponent<MenuCtrl>();
    }

    void Update()
    {
        switch (currentStep)
        {
            case 0:
                if (Input.GetKeyDown(KeyCode.K))
                {
                    NextStep();
                }
                break;
            case 1:
                if(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
                {
                    NextStep();
                }
                break;
            case 2:
                if (item.itemCount == 1)
                {
                    NextStep();
                }
                break;
            case 3:
                if (Input.GetKeyDown(KeyCode.Tab))
                {
                    NextStep();
                }
                break;
            case 4:
                if(menuManager.isInventory)
                {
                    NextStep();
                }
                break;
            case 5:
                if (!menuCtrl.isMenuOpne)
                {
                    NextStep();
                }
                break;
        }
    }
    public void NextStep()
    {
        tutorialSteps[currentStep].SetActive(false);
        currentStep++;

        if(currentStep < tutorialSteps.Length)
        {
            ShowStep(currentStep);
        }
        else
        {
            Debug.Log("Tutorial End");
            isTutorial = false;
        }
    }
    void ShowStep(int step)
    {
        tutorialSteps[step].SetActive(true);
    }
}
