using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DiagnosisCheckDialogController : DialogController {
    public GameObject[] rights;
    public GameObject[] wrongs;
    public GameObject[] pickedDiagnoses;
    public GameObject[] fluidPoints;
    public FluidController fluidController;
    public override void RefreshText()
    {
        Debug.Log("Check");
  /*      fluidController = GameObject.FindObjectOfType<FluidController>();
        for (int i =0; i<3; i++)
            if (scenarioPart.intValues[i] == fluidController.patientsStates[i])
                rights[i].SetActive(true);
            else
                wrongs[i].SetActive(true);
        for (int i = 0; i < 3; i++)
            if (scenarioPart.intValues[i] == 0)
                pickedDiagnoses[i].GetComponent<Text>().text = "Нулевая вероятность";
            else if (scenarioPart.intValues[i] == 1)
                pickedDiagnoses[i].GetComponent<Text>().text = "Малая вероятность";
            else if (scenarioPart.intValues[i] == 2)
                pickedDiagnoses[i].GetComponent<Text>().text = "Средняя вероятность";
            else if (scenarioPart.intValues[i] == 3)
                pickedDiagnoses[i].GetComponent<Text>().text = "Большая вероятность";

        for (int i = 0; i < 3; i++)
            for (int j = 0; j < fluidController.patientsStates[i]; j++)
                fluidPoints[i * 3 + j].GetComponent<Image>().color = Color.yellow;
       */
                
    }

    public override void Accept()
    {
        base.Accept();
        Application.Quit();
    }

    public override void Decline()
    {
        base.Decline();
        SceneManager.LoadScene("2");
    }
}
