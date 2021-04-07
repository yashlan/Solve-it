using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Yashlan 
{
    public class MateriRepository : MonoBehaviour
    {
        #region instance Class

        private static MateriRepository instance = null;
        public static MateriRepository Instance
        {
            get { return instance; }
        }

        void Awake()
        {
            if (instance != null && instance != this)
            {
                Destroy(this.gameObject);
                return;
            }

            else
            {
                DontDestroyOnLoad(gameObject);
                instance = this;
            }
        }

        #endregion of instance class


        #region JUDUL MATERI 1

        public static string Judul_Materi_1_0 = "PENGENALAN PYTHON";
        public static string Judul_Materi_1_1 = "INSTALASI";
        public static string Judul_Materi_1_2 = "MEMULAI PROGRAM PYTHON";
        public static string Judul_Materi_1_3 = "SINTAKS";
        public static string Judul_Materi_1_4 = "KOMENTAR";
        public static string Judul_Materi_1_5 = "VARIABEL";
        public static string Judul_Materi_1_6 = "BOOLEAN";
        public static string Judul_Materi_1_7 = "STRING";


        #endregion

        #region Message Materi 1

        public static string MATERI_1_0 = "Python diciptakan oleh Guido van Rossum. " +
                                          "Pada awalnya, python menghasilkan aplikasi berbasis console, " +
                                          "namun seiring makin populernya bahasa python, " +
                                          "aplikasi yang dihasilkan mulai beragam fungsi. "+
                                          "Python adalah bahasa pemrograman interpreter multifungsi " +
                                          "yang berorientasi objek yang memakai filosofi " +
                                          "perancangan dengan fokus kepada tingkat keterbacaan kode.";


        public static string MATERI_1_1 = "Bagi pengguna Linux, Python tidak perlu diinstal. " +
                                          "Karena Sebagian besar distro Linux sudah menyediakannya secara default. " +
                                          "Untuk mengeceknya, silahkan ketik perintah <color=red>python --version</color> di terminal. \n" +
                                          "Untuk Windows Bisa Download di situs resmi python <color=red>(www.python.org/downloads/).</color>";

        public static string MATERI_1_2 = "Sesudah Anda memastikan Python sudah terinstall dengan baik" +
                                          " di perangkat. Langkah selanjutnya adalah melakukan percobaan beberapa" +
                                          " eksekusi program Python. Namun sebelum itu akan lebih baik" +
                                          " jika mengetahui terlebih dahulu apa saja komponen yang terdapat di dalam Python.";

        public static string MATERI_1_3 = "Python sintaks dapat dieksekusi langsung dengan mengetikkannya di Command Line." +
                                          " Selain itu, Anda dapat membuat file Python di dalam server menggunakan ekstensi .py " +
                                          "dan menjalankannya menggunakan Command Line.\n " +
                                          "contoh <color=red>>>> print(“Hello, World!”)</color> \noutputnya : <color=red>Hello, World!</color>";

        public static string MATERI_1_4 = "Sama seperti bahasa pemrograman lainnya, " +
                                          "Python juga memiliki kode untuk menjadikan baris program menjadi komentar. " +
                                          "Anda dapat menggunakan tanda pagar ‘#’ " +
                                          "untuk menjadikan baris kode di Python menjadi komentar. \n" +
                                          "contoh : <color=red># ini adalah baris komentar</color>";

        public static string MATERI_1_5 = "Python juga memiliki Variabel, " +
                                          "tidak berbeda dengan bahasa pemrograman lainnya. " +
                                          "Variabel ini digunakan untuk proses penyimpanan " +
                                          "dan bekerja dengan berbagai tipe data." +                         
                                          " Python secara otomatis akan memberikan tipe variabel sesuai" +
                                          " dengan nilai yang diberikan" +
                                          " pada variabel tersebut. Misalnya pada contoh di bawah ini:\n" +
                                          "<color=red>x = 5 # x bertipe integer</color>\n" +
                                          "<color=red>y = “anthon” # y bertipe string</color>";

        public static string MATERI_1_6 = "Setelah mempelajari variabel bekerja, " +
                                          "di bagian ini Anda akan belajar tentang Booleans. " +
                                          "Jika Variabel dapat menyimpan bilangan dengan satu tipe data," +
                                          " booleans juga digunakan untuk menyimpan sebuah tipe data, tapi tipe data yang berbeda.\n" +
                                          "Tipe data di Booleans hanya ‘benar’ atau ‘salah’. Jadi ini mirip dengan saklar lampu, hanya memiliki dua nilai.\n" +
                                          "contoh :\n<color=red>a = true # true artinya benar</color>\n" +
                                          "<color=red>b = false # false artinya salah";

        public static string MATERI_1_7 = "Ketika ingin belajar Python string, " +
                                          "Anda hanya perlu menambahkan tanda kutip tunggal " +
                                          "atau tanda kutip ganda di antara nilai variabel yang ingin ditambahkan. " +
                                          "Misalnya saja ketika Anda ingin menambahkan string “Anthon” ke dalam variabel x " +
                                          "maka yang perlu Anda lakukan adalah mendeklarasikannya seperti di bawah ini:\n" +
                                          "<color=red>x = “Anthon” Atau x = ’Anthon’</color>\n" +
                                          "<color=red># “Anthon” sama artinya dengan ‘Anthon’.</color>";

        #endregion


        #region JUDUL MATERI 2

        public static string Judul_Materi_2_0 = "PENGENALAN OPERATOR";
        public static string Judul_Materi_2_1 = "OPERATOR ARITMATIKA";
        public static string Judul_Materi_2_2 = "OPERATOR PERBANDINGAN";
        public static string Judul_Materi_2_3 = "OPERATOR LOGIKA";


        #endregion

        #region Message Materi 2

        public static string MATERI_2_0 = "Selama melakukan proses coding Anda pasti akan " +
                                          "membutuhkan operator untuk membuat sebuah alur logika, " +
                                          "penghitungan angka, atau yang lainnya.Operator ini bekerja " +
                                          "untuk melakukan operasi pada variabel dan nilai. Dalam bahasa " +
                                          "pemrograman Python, terdapat beberapa grup dari operator, seperti " +
                                          "operator aritmatika, penugasan (assignment), pembanding (comparison), " +
                                          "logika (logical), identitas (identity), keanggotaan (membership), dan bitwise.";

        public static string MATERI_2_1 = "";
        public static string MATERI_2_2 = "";
        public static string MATERI_2_3 = "";

        #endregion


        #region JUDUL MATERI 3

        public static string Judul_Materi_3_0 = "PERCABANGAN";
        public static string Judul_Materi_3_1 = "PERNYATAAN/STATEMENT";
        public static string Judul_Materi_3_2 = "PERNYATAAN IF";
        public static string Judul_Materi_3_3 = "PERNYATAAN IF ELSE";
        public static string Judul_Materi_3_4 = "PERNYATAAN IF ELIF ELSE";

        #endregion

        #region Message MATERI 3

        public static string MATERI_3_0 = "Percabangan adalah cara yang digunakan untuk " +
                                          "mengambil keputusan apabila di dalam program " +
                                          "dihadapkan pada kondisi tertentu. Jumlah kondisinya bisa satu, dua atau lebih. " + 
                                          "Percabangan mengevaluasi kondisi atau ekspresi yang hasilnya benar atau salah. " +
                                          "Kondisi atau ekspresi tersebut disebut ekspresi boolean. " +
                                          "Hasil dari pengecekan kondisi adalah True atau False. Bila benar (True), " +
                                          "maka pernyataan yang ada di dalam blok kondisi tersebut akan dieksekusi. " +
                                          "Bila salah (False), maka blok pernyataan lain yang dieksekusi.";

        public static string MATERI_3_1 = "";

        public static string MATERI_3_2 = "Pernyataan if menguji satu buah kondisi. " +
                                          "Bila hasilnya benar maka pernyataan di dalam blok if tersebut dieksekusi. " +
                                          "Bila salah, maka pernyataan tidak dieksekusi. " +
                                          "Sintaksnya adalah seperti berikut:\n\n" + 
                                          "<color=red>if kondisi:\n" +
                                          "    blok pernyataan if</color>";

        public static string MATERI_3_3 = "Pernyataan if…else menguji 2 kondisi. " +
                                          "Kondisi pertama kalau benar, dan kondisi kedua kalau salah. " +
                                          "Sintaksnya adalah seperti berikut:\n\n" +
                                          "<color=red>if kondisi:\n" +
                                          "    blok pernyataan if\n" + 
                                          "else:\n" +
                                          "    blok pernyataan else</color>";

        public static string MATERI_3_4 = "Pernyataan ini digunakan untuk menguji lebih dari 2 kondisi. " +
                                          "Bila kondisi pada if benar, maka pernyataan di dalamnya yang dieksekusi. " +
                                          "Bila salah, maka masuk ke pengujian kondisi elif. " +
                                          "Terakhir bila tidak ada if atau elif yang benar, " +
                                          "maka yang dijalankan adalah yang di blok else. " +
                                          "Sintaksnya adalah seperti berikut:\n" +
                                          "<color=red>if kondisi :\n" +
                                          "    blok pernyataan if\n" + 
                                          "elif kondisi:\n" +
                                          "    blok pernyataan elif\n" +
                                          "else:\n" +
                                          "    blok pernyataan else</color>";
        #endregion



    }

}
