using UnityEngine;
using System.Collections;

public class DialogController : MonoBehaviour {
   // public ScenarioPart scenarioPart;
    public static DialogController Instance = null;

    public void Start()
    {
        Debug.Log(transform.name);
        RefreshText();
        KeyBoardController.Instance.SetMoving(false);
        Instance = this;
    }

    public virtual void Accept()
    {
        KeyBoardController.Instance.SetMoving(true);
        Instance = null;
        CheckScenarioPart();
        Destroy(this.gameObject);
    }

    public virtual void Decline()
    {
        KeyBoardController.Instance.SetMoving(true);
        Instance = null;
        Destroy(this.gameObject);
    }

    public virtual void RefreshText()
    {
        Debug.Log("Refresh Text");
    }

    public virtual void CheckScenarioPart()
    {
        Debug.Log("Check Scenario");
    }
}
