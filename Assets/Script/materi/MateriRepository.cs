﻿using System.Collections;
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


        #endregion

        #region Message Materi 1

        public static string MATERI_1_0 = "Python diciptakan oleh Guido van Rossum.\n" +
                                          "Pada awalnya, python menghasilkan aplikasi berbasis console, " +
                                          "namun seiring makin populernya bahasa python, " +
                                          "aplikasi yang dihasilkan mulai beragam fungsi."+
                                          "Python adalah bahasa pemrograman interpreter multifungsi " +
                                          "yang berorientasi objek yang memakai filosofi " +
                                          "perancangan dengan fokus kepada tingkat keterbacaan kode.";


        public static string MATERI_1_1 = "Bagi pengguna Linux, Python tidak perlu diinstal." +
                                          "Karena Sebagian besar distro Linux sudah menyediakannya secara default." +
                                          "Untuk mengeceknya, silahkan ketik perintah <color=red>python --version</color> di terminal.\n" +
                                          "Untuk Windows Bisa Download di situs resmi python <color=red>(www.python.org/downloads/).</color>";

        public static string MATERI_1_2 = "Sesudah Anda memastikan Python sudah terinstall dengan baik" +
                                          " di perangkat.Langkah selanjutnya adalah melakukan percobaan beberapa" +
                                          " eksekusi program Python.Namun sebelum itu akan lebih baik" +
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
                                          "Kemudahan lainnya, Anda tidak perlu mendefinisikan tipe variabel." +
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

        #endregion

    }

}
