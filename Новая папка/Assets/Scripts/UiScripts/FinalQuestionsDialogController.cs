using UnityEngine;
using System.Collections;

public class FinalQuestionsDialogController : DialogController {
    public DropListController dlc1;
    public DropListController dlc2;
    public DropListController dlc3;
    override public void CheckScenarioPart()
    {
        int[] results = new int[3];
        results[0] = dlc1.currentState;
        results[1] = dlc2.currentState;
        results[2] = dlc3.currentState;
        ScenarioController scenarioController = GameObject.FindObjectOfType<ScenarioController>();
       // ScenarioPart temp = scenarioController.scenario.scenario[scenarioController.scenario.currentPosition+1].scenarioParts[0];
       // temp.intValues = results;
       // scenarioPart.isDone = true;
    }


}
