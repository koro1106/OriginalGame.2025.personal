using UnityEngine;

public class ButtonGimmick : MonoBehaviour
{
    [SerializeField] private Vector3 pressedOffset = new Vector3(0, -0.3f, 0); // hekomuryou
    private Vector3 startPos; //firstPos
    private bool isOn = false;
    public bool gimmickGround;
    private int pushCount = 0;
    public MoveGround moveground;


    void Start()
    {
       startPos = transform.localPosition;
    }
   
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Anxiety") || collision.CompareTag("Player"))
        {
            pushCount++;
            if (!isOn)
            {
                isOn = true;
                Debug.Log(isOn);
                transform.localPosition = startPos + pressedOffset;//hekomaseru
                if (gimmickGround)
                {
                    GetComponentInParent<MoveGround>()?.SetState(true);//oyano jimennni tuuti
                }
                else
                {
                    moveground?.SetState(true);
                }
            }
        }
    }

   void OnTriggerExit2D(Collider2D collision)
   {
      if (gimmickGround)
      {
          if (collision.CompareTag("Anxiety") || collision.CompareTag("Player"))
          {
              pushCount--;
              if (pushCount <= 0)
              {
                  isOn = false;
                  transform.localPosition = startPos;
                  GetComponentInParent<MoveGround>()?.SetState(false);
              }
          }
      }
   }
}
