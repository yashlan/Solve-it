using Doublsb.Dialog;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Yashlan
{
    public class DialogQuiz2 : MonoBehaviour
    {
        [Header("Init Obj")]
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

            dialogTexts.Add(new DialogData(_name + "Hi, Bertemu lagi dengan saya " + char_name + ".", char_name));

            dialogTexts.Add(new DialogData(_name + "Pada kuis ke 2 ini, saya akan memberikan pertanyaan tentang Materi ke 2.", char_name));

            dialogTexts.Add(new DialogData(_name + "Seperti biasa, Jika anda menjawab benar maka skor bertambah 20, Jika menjawab salah anda tidak mendapat skor.", char_name));

            dialogTexts.Add(new DialogData(_name + "Okay, Are you ready ?", char_name));

            dialogTexts.Add(new DialogData(_name + "ini soal pertama.", char_name));

            var Soal1 = new DialogData(_name + "Untuk membuat sebuah alur logika, penghitungan angka, atau yang lainnya kita membutuhkan ?", char_name);
            Soal1.SelectList.Add(wrong, "Variabel");
            Soal1.SelectList.Add(wrong, "Pertanyaan");
            Soal1.SelectList.Add(correct, "Operator");
            Soal1.SelectList.Add(wrong, "Aritmatika");

            dialogTexts.Add(Soal1);
            Soal1.Callback = () => Check_Correct();

            dialogTexts.Add(new DialogData(_name + "Oke, sekarang pertanyaan kedua.", char_name));

            var Soal2 = new DialogData(_name + "Pada Pemrograman Python terdapat beberapa grup dari operator seperti teks diatas, kecuali ?", char_name);
            Soal2.SelectList.Add(wrong, "Aritmatika");
            Soal2.SelectList.Add(wrong, "Penugasan");
            Soal2.SelectList.Add(wrong, "Identitas");
            Soal2.SelectList.Add(correct, "Geometri");

            dialogTexts.Add(Soal2);
            Soal2.Callback = () => Check_Correct();

            dialogTexts.Add(new DialogData(_name + "Lanjut, pertanyaan ketiga.", char_name));

            var Soal3 = new DialogData(_name + ">>> 10__3. Agar Outputnya : 1000, operator apa yang perlu ditambahkan ?", char_name);
            Soal3.SelectList.Add(wrong, "*");
            Soal3.SelectList.Add(correct, "**");
            Soal3.SelectList.Add(wrong, "/");
            Soal3.SelectList.Add(wrong, "%");

            dialogTexts.Add(Soal3);
            Soal3.Callback = () => Check_Correct();

            dialogTexts.Add(new DialogData(_name + "Sekarang, pertanyaan keempat.", char_name));

            var Soal4 = new DialogData(_name + "10 != 15. Maksud dari pernyataan tersebut adalah ?", char_name);
            Soal4.SelectList.Add(wrong, "10 tidak sama 15");
            Soal4.SelectList.Add(wrong, "10 sama dengan 15");
            Soal4.SelectList.Add(wrong, "10 dengan 15");
            Soal4.SelectList.Add(correct, "10 tidak sama dengan 15");

            dialogTexts.Add(Soal4);
            Soal4.Callback = () => Check_Correct();

            dialogTexts.Add(new DialogData(_name + "Terakhir, pertanyaan kelima.", char_name));

            var Soal5 = new DialogData(_name + ">>> 150 % 4 ** 2. Berapa hasil outputnya ?", char_name);
            Soal5.SelectList.Add(correct, "6");
            Soal5.SelectList.Add(wrong, "7");
            Soal5.SelectList.Add(wrong, "8");
            Soal5.SelectList.Add(wrong, "9");

            dialogTexts.Add(Soal5);
            Soal5.Callback = () => Check_Correct();

            dialogTexts.Add(new DialogData(_name + "Oke, anda sudah menjawab semua soal.", char_name));
            dialogTexts.Add(new DialogData(_name + "Silakan klik tulisan ini untuk melihat grade anda.", char_name, () => ShowPanelHasil()));

            DialogManager.Show(dialogTexts);
        }

        void ShowPanelHasil()
        {
            panelHasil.SetActive(true);
            txt_skor.text = "SKOR : " + ScoreManager.Score;
            txt_grade.text = "GRADE : " + Grade();
        }

        private string Grade()
        {
            string grade = "";

            if (ScoreManager.Score > 80 && ScoreManager.Score <= 100)
                grade = "BAIK SEKALI";
            else if (ScoreManager.Score > 60 && ScoreManager.Score <= 80)
                grade = "BAIK";
            else if (ScoreManager.Score > 40 && ScoreManager.Score <= 60)
                grade = "CUKUP";
            else if (ScoreManager.Score > 20 && ScoreManager.Score <= 40)
                grade = "KURANG";
            else if (ScoreManager.Score >= 0 && ScoreManager.Score <= 20)
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
                dialogTexts.Add(new DialogData(_name + "Skor anda saat ini " + ScoreManager.Score + ".", char_name));

                DialogManager.Show(dialogTexts);
            }
            else if (DialogManager.Result == wrong)
            {
                var dialogTexts = new List<DialogData>();

                dialogTexts.Add(new DialogData(_name + "Maaf, Jawaban anda salah. Anda tidak mendapatkan skor.", char_name));
                dialogTexts.Add(new DialogData(_name + "Skor anda saat ini " + ScoreManager.Score + ".", char_name));

                DialogManager.Show(dialogTexts);
            }
        }
    }

}
