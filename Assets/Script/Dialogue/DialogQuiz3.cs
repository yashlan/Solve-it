using Doublsb.Dialog;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Yashlan
{
    public class DialogQuiz3 : MonoBehaviour
    {
        [Header("gambar kuis")]
        public Image[] images;

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

            dialogTexts.Add(new DialogData(_name + "Hi, Selamat Datang kembali.", char_name));

            dialogTexts.Add(new DialogData(_name + "Oke, pada kuis kali ini saya akan memberikan pertanyaan sesuai dengan Materi ke 3.", char_name));

            dialogTexts.Add(new DialogData(_name + "Ready ?", char_name));

            dialogTexts.Add(new DialogData(_name + "oke ini soal pertama.", char_name));

            var Soal1 = new DialogData(_name + "cara yang digunakan untuk mengambil keputusan apabila di dalam program dihadapkan pada kondisi tertentu disebut ?", char_name);
            Soal1.SelectList.Add(wrong, "Pernyataan");
            Soal1.SelectList.Add(wrong, "Pembagian");
            Soal1.SelectList.Add(wrong, "Penggabungan");
            Soal1.SelectList.Add(correct, "Percabangan");

            dialogTexts.Add(Soal1);
            Soal1.Callback = () => Check_Correct();

            dialogTexts.Add(new DialogData(_name + "Oke, sekarang pertanyaan kedua.", char_name));

            var Soal2 = new DialogData(_name + "Pernyataan yang menguji satu buah kondisi adalah ?", char_name);
            Soal2.SelectList.Add(correct, "if");
            Soal2.SelectList.Add(wrong, "else");
            Soal2.SelectList.Add(wrong, "elif");
            Soal2.SelectList.Add(wrong, "else if");

            dialogTexts.Add(Soal2);
            Soal2.Callback = () => Check_Correct();

            dialogTexts.Add(new DialogData(_name + "Lanjut, pertanyaan ketiga.", char_name));

            var Soal3 = new DialogData(_name + "Pernyataan yang digunakan untuk menguji lebih dari 2 kondisi adalah ?", char_name);
            Soal3.SelectList.Add(wrong, "if");
            Soal3.SelectList.Add(wrong, "else");
            Soal3.SelectList.Add(wrong, "if else if else");
            Soal3.SelectList.Add(correct, "if elif else");

            dialogTexts.Add(Soal3);
            Soal3.Callback = () => Check_Correct();

            dialogTexts.Add(new DialogData(_name + "Sekarang, pertanyaan keempat.", char_name));

            var Soal4 = new DialogData(_name + "Jika a = 5 maka outputnya ?", char_name);
            Soal4.SelectList.Add(wrong, "Python is Simple");
            Soal4.SelectList.Add(wrong, "Python Simple");
            Soal4.SelectList.Add(correct, "Python is Awesome");
            Soal4.SelectList.Add(wrong, "Python is Awesomes");

            dialogTexts.Add(Soal4);
            Soal4.Callback = () => Check_Correct();

            dialogTexts.Add(new DialogData(_name + "Terakhir, pertanyaan kelima.", char_name));

            var Soal5 = new DialogData(_name + "jika tahun = 1979, maka hasil outputnya ?", char_name);
            Soal5.SelectList.Add(wrong, "error");
            Soal5.SelectList.Add(correct, "anthon anda tergolong generasi X");
            Soal5.SelectList.Add(wrong, "anthon anda tergolong generasi Y");
            Soal5.SelectList.Add(wrong, "anda tergolong generasi Z");

            dialogTexts.Add(Soal5);
            Soal5.Callback = () => Check_Correct();

            dialogTexts.Add(new DialogData(_name + "Oke, anda sudah menjawab semua soal.", char_name));
            dialogTexts.Add(new DialogData(_name + "Silakan klik tulisan ini untuk melihat grade anda.", char_name, ()=> ShowPanelHasil()));

            DialogManager.Show(dialogTexts);
        }

        private void FixedUpdate()
        {
            if (DialogManager.Printer_Text.text == _name + "Jika a = 5 maka outputnya ?")
                ShowImages(0, 1);
            else if (DialogManager.Printer_Text.text == _name + "jika tahun = 1979, maka hasil outputnya ?")
                ShowImages(1, 0);
            else
                HideImages();
        }

        void ShowImages(int index, int index_to_disable)
        {
            images[index_to_disable].gameObject.SetActive(false);
            images[index].gameObject.SetActive(true);
        }

        void HideImages()
        {
            foreach (var item in images)
            {
                item.gameObject.SetActive(false);
            }
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
