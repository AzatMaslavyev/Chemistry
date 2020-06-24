using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DozatorDialogController : DialogController {
    public float value = 0.0f;
    public InputField inputField;

    public void ChangeValue(float delta)
    {
        value += delta;
        if (value < 0.01f)
            value = 0f;
        else
            if (value > 10f)
                value = 10f;
        RefreshText();
    }

    public override void RefreshText()
    {
        int temp = Mathf.RoundToInt(value * 100f);
        int v1 = temp/100;
        int v2 = (temp/10)%10;
        inputField.text = v1+"."+v2 + " мл.";
    }

    public override void CheckScenarioPart()
    {
        /*Debug.Log(value + " " + scenarioPart.floatValues[0]);
        if (Mathf.Abs(value - scenarioPart.floatValues[0])<0.001)
        {
            scenarioPart.isDone = true;
        }*/
    }
}
