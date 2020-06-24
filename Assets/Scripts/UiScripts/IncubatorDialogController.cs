using UnityEngine;
using System.Collections;
using UnityEngine.UI;
//°С
public class IncubatorDialogController : DialogController {
    public int minutes = 0;
    public int hours = 0;
    public int temperature = 30;
    public InputField timeInputField;
    public InputField temperatureInputField;

    public void ChangeTimeValue(int delta)
    {
        minutes += delta;
        if (minutes >= 60)
        {
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

    public void ChangeTemperatureValue(int delta)
    {
        temperature += delta;
        temperature = Mathf.Clamp(temperature, -1000, 1000);
        RefreshText();
    }

    public override void RefreshText()
    {
        timeInputField.text = hours + " ч. " + minutes + " мин.";
        temperatureInputField.text = temperature + " °С";
    }

    public override void CheckScenarioPart()
    {
       /* if (hours == scenarioPart.intValues[0] && minutes == scenarioPart.intValues[1] && temperature == scenarioPart.intValues[2])
        {
            scenarioPart.isDone = true;
        }*/
    }
}
