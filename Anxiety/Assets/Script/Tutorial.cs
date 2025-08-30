using System.Collections;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    [SerializeField] private GameObject[] tutorialSteps;
    [SerializeField] private MenuManager menuManager;
    private MenuCtrl menuCtrl;
    private PlayerCtrl player;
    public  int currentStep = 0;
    private ItemGet item;
    private Camera cam;
    private Rigidbody2D rb;
    public bool isTutorial = false;
    private bool isStopping = false;
    void Start()
    {
        ShowStep(currentStep);
        item = GetComponent<ItemGet>();
        menuCtrl = GetComponent<MenuCtrl>();
        player = GetComponent<PlayerCtrl>();
        cam = Camera.main;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
       Debug.Log(currentStep);
        switch (currentStep)
        {
            case 0:
                if (player.isHold)
                {
                    NextStep();
                }
                break;
            case 1:
                if(cam.transform.position.x >= -1650)
                {
                    NextStep();
                }
                break;
            case 2:
                if (!isStopping)
                {
                    isStopping = true;
                    StartCoroutine(TutorialStop());
                }
                break;
            case 3:
                if (item.itemCount == 1)
                {
                    NextStep();
                }
                break;
            case 4:
                if (Input.GetKeyDown(KeyCode.Tab))
                {
                    NextStep();
                }
                break;
            case 5:
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    NextStep();
                }
                break;
            case 6:
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    NextStep();
                }
                break;
            case 7:
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
    private IEnumerator TutorialStop()
    {
        rb.velocity = Vector2.zero;
        player.animator.SetInteger("Speed", 0);
        yield return new WaitForSeconds(3f);

        NextStep();
    }
}
