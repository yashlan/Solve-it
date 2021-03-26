using Doublsb.Dialog;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogQuiz1 : MonoBehaviour
{
    public DialogManager DialogManager;

    private const string _name = "Ali : ";
    private const string char_name = "Ali";

    private void Awake()
    {
        var dialogTexts = new List<DialogData>();

        dialogTexts.Add(new DialogData(_name + "Hi, saya " + char_name + ".", char_name));

        dialogTexts.Add(new DialogData(_name + "Saya akan memberikan beberapa kuis berdasarkan materi ke 1 yaitu Pengenalan Python kepada anda.", char_name));

        dialogTexts.Add(new DialogData(_name + "Pastikan anda sudah siap ya.", char_name));

        dialogTexts.Add(new DialogData(_name + "oke ini soal pertama.", char_name));

        var Text1 = new DialogData(_name + "Siapakah penemu bahasa pemrograman python ?", char_name);
        Text1.SelectList.Add("Correct", "Guido van Rossum");
        Text1.SelectList.Add("Wrong", "Guido van");
        Text1.SelectList.Add("Wrong", "Rossum");
        Text1.SelectList.Add("Wrong", "ASDASD");

        dialogTexts.Add(Text1);
        Text1.Callback = () => Check_Correct();

        dialogTexts.Add(new DialogData(_name + "Oke, sekarang pertanyaan kedua.", char_name));

        var Text2 = new DialogData(_name + "print(“Hello, World!”). apakah hasil outputnya ?", char_name);
        Text2.SelectList.Add("Correct", "Hello, World!");
        Text2.SelectList.Add("Wrong", "HelloWorld!");
        Text2.SelectList.Add("Wrong", "Hello");
        Text2.SelectList.Add("Wrong", "Syntax Error");

        dialogTexts.Add(Text2);
        Text2.Callback = () => Check_Correct();


        DialogManager.Show(dialogTexts);
    }

    private void Check_Correct()
    {
        if (DialogManager.Result == "Correct")
        {
            var dialogTexts = new List<DialogData>();

            dialogTexts.Add(new DialogData(_name + "Wow Selamat, Jawaban anda benar.", char_name));

            DialogManager.Show(dialogTexts);
        }
        else if (DialogManager.Result == "Wrong")
        {
            var dialogTexts = new List<DialogData>();

            dialogTexts.Add(new DialogData(_name + "Hmm, Jawaban anda salah.", char_name));

            DialogManager.Show(dialogTexts);
        }
    }
}
