using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CentrifugeDialogController :DialogController {
    public int minutes = 0;
    public int hours = 0;
    public InputField inputField;

    public void ChangeValue(int delta)
    {
        minutes += delta;
        if (minutes >= 60){
            hours++;
            minutes -= 60;
        }

        if (minutes < 0)
        {
            if (hours > 0)
            {
                hours--;
                minutes += 60;
            }
            else
                minutes = 0;
        }
        RefreshText();
    }

    public override void RefreshText()
    {
        inputField.text = hours+ " ч. " +minutes + " мин.";
    }

    public override void CheckScenarioPart()
    {
    /*    if (hours == scenarioPart.intValues[0] && minutes == scenarioPart.intValues[1])
        {
            scenarioPart.isDone = true;
        }*/
    }
}
