using Doublsb.Dialog;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Yashlan
{
    public class DialogQuiz1 : MonoBehaviour
    {
        public GameObject panelHasil;
        public Text txt_skor;
        public Text txt_grade;
        public DialogManager DialogManager;

        private const string _name = "Anthon : ";
        private const string char_name = "Anthon";

        private const string wrong = "wrong";
        private const string correct = "correct";

        private void Awake()
        {
            //reset skor
            ScoreManager.ResetScore();

            var dialogTexts = new List<DialogData>();

            dialogTexts.Add(new DialogData(_name + "Hi, saya " + char_name + ".", char_name));

            dialogTexts.Add(new DialogData(_name + "Saya akan memberikan beberapa kuis berdasarkan materi ke satu kepada anda.", char_name));

            dialogTexts.Add(new DialogData(_name + "Setiap anda menjawab dengan benar maka skor anda akan bertambah 20, Jika anda menjawab salah anda tidak mendapat skor.", char_name));

            dialogTexts.Add(new DialogData(_name + "Pastikan anda sudah siap ya.", char_name));

            dialogTexts.Add(new DialogData(_name + "oke ini soal pertama.", char_name));

            var Soal1 = new DialogData(_name + "Siapakah penemu bahasa pemrograman python ?", char_name);
            Soal1.SelectList.Add(correct, "Guido van Rossum");
            Soal1.SelectList.Add(wrong, "Dennis Ritchie");
            Soal1.SelectList.Add(wrong, "James Gosling");
            Soal1.SelectList.Add(wrong, "Yukihiro Matsumoto");

            dialogTexts.Add(Soal1);
            Soal1.Callback = () => Check_Correct();

            dialogTexts.Add(new DialogData(_name + "Oke, sekarang pertanyaan kedua.", char_name));

            var Soal2 = new DialogData(_name + ">>>______('Hello, World!'). syntax apakah yang perlu ditambah agar outputnya : Hello, World! ?", char_name);
            Soal2.SelectList.Add(wrong, "execute");
            Soal2.SelectList.Add(wrong, "console.Log");
            Soal2.SelectList.Add(correct, "print");
            Soal2.SelectList.Add(wrong, "debug.log");

            dialogTexts.Add(Soal2);
            Soal2.Callback = () => Check_Correct();

            dialogTexts.Add(new DialogData(_name + "Lanjut, pertanyaan ketiga.", char_name));

            var Soal3 = new DialogData(_name + "Tanda apakah yang perlu ditambahkan untuk membuat komentar ?", char_name);
            Soal3.SelectList.Add(wrong, "tanda /");
            Soal3.SelectList.Add(correct, "tanda #");
            Soal3.SelectList.Add(wrong, "tanda !");
            Soal3.SelectList.Add(wrong, "tanda ''");

            dialogTexts.Add(Soal3);
            Soal3.Callback = () => Check_Correct();

            dialogTexts.Add(new DialogData(_name + "Sekarang, pertanyaan keempat.", char_name));

            var Soal4 = new DialogData(_name + "x = 505, y = 'angka', apakah tipe data dari variabel x dan y ?", char_name);
            Soal4.SelectList.Add(wrong, "integer dan char");
            Soal4.SelectList.Add(wrong, "float dan integer");
            Soal4.SelectList.Add(wrong, "boolean dan string");
            Soal4.SelectList.Add(correct, "integer dan string");

            dialogTexts.Add(Soal4);
            Soal4.Callback = () => Check_Correct();

            dialogTexts.Add(new DialogData(_name + "Terakhir, pertanyaan kelima.", char_name));

            var Soal5 = new DialogData(_name + "tipe data yang nilai atau valuenya hanya ada benar dan salah adalah ?", char_name);
            Soal5.SelectList.Add(wrong, "float");
            Soal5.SelectList.Add(correct, "boolean");
            Soal5.SelectList.Add(wrong, "string");
            Soal5.SelectList.Add(wrong, "integer");

            dialogTexts.Add(Soal5);
            Soal5.Callback = () => Check_Correct();

            dialogTexts.Add(new DialogData(_name + "Oke, anda sudah menjawab semua soal.", char_name));
            dialogTexts.Add(new DialogData(_name + "Silakan klik tulisan ini untuk melihat grade anda.", char_name, () => ShowPanelHasil()));

            DialogManager.Show(dialogTexts);
        }

        void ShowPanelHasil()
        {
            panelHasil.SetActive(true);
            txt_skor.text  = "SKOR : "  + ScoreManager.Score;
            txt_grade.text = "GRADE : " + Grade();
        }

        private string Grade()
        {
            string grade = "";

            if (ScoreManager.Score      > 80 &&  ScoreManager.Score <= 100)
                grade = "BAIK SEKALI";
            else if (ScoreManager.Score > 60 &&  ScoreManager.Score <= 80)
                grade = "BAIK";
            else if (ScoreManager.Score > 40 &&  ScoreManager.Score <= 60)
                grade = "CUKUP";
            else if (ScoreManager.Score > 20 &&  ScoreManager.Score <= 40)
                grade = "KURANG";
            else if(ScoreManager.Score  >= 0 &&  ScoreManager.Score <= 20)
                grade = "SANGAT KURANG";

            return grade;
        }

        private void Check_Correct()
        {
            if (DialogManager.Result == correct)
            {
                //plus score
                ScoreManager.PlusScore(20);

                var dialogTexts = new List<DialogData>();

                dialogTexts.Add(new DialogData(_name + "Selamat, Jawaban anda benar. Skor anda bertambah 20.", char_name));
                dialogTexts.Add(new DialogData(_name + "Skor anda saat ini " + ScoreManager.Score + "."      , char_name));

                DialogManager.Show(dialogTexts);
            }
            else if (DialogManager.Result == wrong)
            {
                var dialogTexts = new List<DialogData>();

                dialogTexts.Add(new DialogData(_name + "Maaf, Jawaban anda salah. Anda tidak mendapatkan skor." , char_name));
                dialogTexts.Add(new DialogData(_name + "Skor anda saat ini " + ScoreManager.Score + "."    , char_name));

                DialogManager.Show(dialogTexts);
            }
        }
    }

}
