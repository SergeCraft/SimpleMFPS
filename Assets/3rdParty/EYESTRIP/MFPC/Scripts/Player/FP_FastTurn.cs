using UnityEngine;
using UnityEngine.UI;

public class FP_FastTurn : MonoBehaviour
{
    public static bool turn;
    public float turnSpeed = 5.5F;
    public float turnAngle = 180;
    public Button leftTurn, rightTurn;
    private Quaternion targetRotation;

    private Transform thisT;

    // Use this for initialization
    private void Start()
    {
        thisT = transform;
        leftTurn.onClick.AddListener(LeftTurn);
        rightTurn.onClick.AddListener(RightTurn);
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
            LeftTurn();
        else if (Input.GetKeyDown(KeyCode.E))
            RightTurn();

        if (thisT.rotation != targetRotation)
        {
            if (turn)
                thisT.rotation =
                    Quaternion.RotateTowards(thisT.rotation, targetRotation, turnSpeed * 100 * Time.deltaTime);
        }
        else
        {
            turn = false;
        }
    }


    private void LeftTurn()
    {
        targetRotation = Quaternion.AngleAxis(turnAngle, transform.up) * thisT.rotation;
        turn = true;
    }

    private void RightTurn()
    {
        targetRotation = Quaternion.AngleAxis(-turnAngle, transform.up) * thisT.rotation;
        turn = true;
    }
}