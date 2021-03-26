using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Doublsb.Dialog;

public class TestMessage_Selection : MonoBehaviour
{
    public DialogManager DialogManager;

    private void Awake()
    {
        var dialogTexts = new List<DialogData>();

        dialogTexts.Add(new DialogData("/size:up/Hi, /size:init/my name is Li.", "Li"));

        dialogTexts.Add(new DialogData("I am Sa. Popped out to let you know Asset can show other characters.", "Sa"));

        dialogTexts.Add(new DialogData("This Asset, The D'Dialog System has many features.", "Li"));

        var Text1 = new DialogData("What is 2 times 5?", "Sa");
        Text1.SelectList.Add("Correct", "10");
        Text1.SelectList.Add("Wrong", "7");
        Text1.SelectList.Add("Whatever", "Why should I care?");

        Text1.Callback = () => Check_Correct();

        dialogTexts.Add(Text1);

        DialogManager.Show(dialogTexts);
    }

    private void Check_Correct()
    {
        if(DialogManager.Result == "Correct")
        {
            var dialogTexts = new List<DialogData>();

            dialogTexts.Add(new DialogData("You are right.", "Sa"));

            DialogManager.Show(dialogTexts);
        }
        else if (DialogManager.Result == "Wrong")
        {
            var dialogTexts = new List<DialogData>();

            dialogTexts.Add(new DialogData("You are wrong.", "Sa"));

            DialogManager.Show(dialogTexts);
        }
        else
        {
            var dialogTexts = new List<DialogData>();

            dialogTexts.Add(new DialogData("Right. You don't have to get the answer.", "Sa"));

            DialogManager.Show(dialogTexts);
        }
    }
}
