using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine.Events;

namespace Yashlan
{
	public class AutoType : MonoBehaviour
	{
		[Header("Use Image")]
		public bool useImage = false;
		public Image image0;
		public Image image1;
		public Image image2;
		public Image image3;
		public Image image4;
		public Image image5;

		[Header("AutoType Judul")]
		public bool autoTypeTitle = false;

		[Header("hanya sekali")]
		public bool JustOnce = false;

		[Header("Button Next Materi")]
		public GameObject btn_next;

		bool startAutoType = false;
		public float delay;
		public AudioClip sound;

		public string[] title;
		public string[] message;
		private TextMeshProUGUI textMesh;
		//private Text text;
		AudioSource audio_;

		int msg_index = 0;
		int title_index = 0;


        #region Initalize Title and Message
		void SetMessage()
        {
			if (SceneManager.GetSceneByName("materi 1").isLoaded)
			{
				message[0] = MateriRepository.MATERI_1_0;
				message[1] = MateriRepository.MATERI_1_1;
				message[2] = MateriRepository.MATERI_1_2;
				message[3] = MateriRepository.MATERI_1_3;
				message[4] = MateriRepository.MATERI_1_4;
				message[5] = MateriRepository.MATERI_1_5;
				message[6] = MateriRepository.MATERI_1_6;
				message[7] = MateriRepository.MATERI_1_7;

			}

			if (SceneManager.GetSceneByName("materi 2").isLoaded)
            {
				message[0] = MateriRepository.MATERI_2_0;
				message[1] = MateriRepository.MATERI_2_1;
				message[2] = MateriRepository.MATERI_2_2;
				message[3] = MateriRepository.MATERI_2_3;
			}

			if (SceneManager.GetSceneByName("materi 3").isLoaded)
            {
				message[0] = MateriRepository.MATERI_3_0;
				message[1] = MateriRepository.MATERI_3_1;
				message[2] = MateriRepository.MATERI_3_2;
				message[3] = MateriRepository.MATERI_3_3;
				message[4] = MateriRepository.MATERI_3_4;
			}

		}

		void SetTitle()
        {
			if (SceneManager.GetSceneByName("materi 1").isLoaded)
			{
				title[0] = MateriRepository.Judul_Materi_1_0;
				title[1] = MateriRepository.Judul_Materi_1_1;
				title[2] = MateriRepository.Judul_Materi_1_2;
				title[3] = MateriRepository.Judul_Materi_1_3;
				title[4] = MateriRepository.Judul_Materi_1_4;
				title[5] = MateriRepository.Judul_Materi_1_5;
				title[6] = MateriRepository.Judul_Materi_1_6;
				title[7] = MateriRepository.Judul_Materi_1_7;
			}

			if (SceneManager.GetSceneByName("materi 2").isLoaded)
            {
				title[0] = MateriRepository.Judul_Materi_2_0;
				title[1] = MateriRepository.Judul_Materi_2_1;
				title[2] = MateriRepository.Judul_Materi_2_2;
				title[3] = MateriRepository.Judul_Materi_2_3;
			}

			if (SceneManager.GetSceneByName("materi 3").isLoaded)
			{
				title[0] = MateriRepository.Judul_Materi_3_0;
				title[1] = MateriRepository.Judul_Materi_3_1;
				title[2] = MateriRepository.Judul_Materi_3_2;
				title[3] = MateriRepository.Judul_Materi_3_3;
				title[4] = MateriRepository.Judul_Materi_3_4;
			}
		}
        #endregion

        // Use this for initialization
        void Start()
		{
			AudioMixerGroup audioMixerGroup = Resources.Load("AudioMixer", typeof(AudioMixerGroup)) as AudioMixerGroup;
			audio_ = gameObject.AddComponent<AudioSource>();
			audio_.outputAudioMixerGroup = audioMixerGroup;
			audio_.clip = sound;

			textMesh = GetComponent<TextMeshProUGUI>();
			textMesh.text = "";

			if (JustOnce)
			{
				if (autoTypeTitle)
				{
					SetTitle();
					StartCoroutine(TypeTextTitle(0));
				}
                else
                {
					SetMessage();
					StartCoroutine(TypeTextJustOnce(0));
				}
			} 
		}

		private void Update()
		{
			if (!startAutoType && !JustOnce)
			{
				startAutoType = true;

                switch (message.Length) 
				{
					case 1:
						StartCoroutine(TypeTextOne(0));
						break;
					case 2:
						StartCoroutine(TypeTextTwo(0, 1));
						break;
					case 3:
						StartCoroutine(TypeTextThree(0, 1, 2));
						break;
					case 4:
						StartCoroutine(TypeTextFour(0, 1, 2, 3));
						break;
					case 5:
						StartCoroutine(TypeTextFive(0, 1, 2, 3, 4));
						break;
				}

			}

			if (useImage)
			{
				if (SceneManager.GetSceneByName("materi 2").isLoaded)
				{
					HideImage();
					SetImageMateri2();
				}

				if (SceneManager.GetSceneByName("materi 3").isLoaded)
                {
					HideImage();
					SetImageMateri3();
				}

			}
		}

		#region Button Onclick
		public void AutoTypeOnClick()
		{
			int max_index_msg = message.Length - 1;
			int max_index_title = title.Length - 1;

			if (autoTypeTitle)
            {
				if (title_index >= max_index_title)
					title_index = 0;
				else
					title_index++;
			}
            else
            {
				if (msg_index >= max_index_msg)
					msg_index = 0;
				else
					msg_index++;
			}

			textMesh.text = "";
			if(btn_next != null)
				btn_next.SetActive(false);

			if (autoTypeTitle)
				StartCoroutine(TypeTextTitle(title_index));
			else
				StartCoroutine(TypeTextJustOnce(msg_index));

            //print(title_index);
        }
		#endregion

		#region MATERI SCENE

		void HideImage()
		{
			if (image0 != null)
				image0.gameObject.SetActive(false);

			if (image1 != null)
				image1.gameObject.SetActive(false);

			if (image2 != null)
				image2.gameObject.SetActive(false);

			if (image3 != null)
				image3.gameObject.SetActive(false);

			if (image4 != null)
				image4.gameObject.SetActive(false);

			if (image5 != null)
				image5.gameObject.SetActive(false);
		}

		void SetImageMateri2()
		{
			if (textMesh.text == MateriRepository.Judul_Materi_2_0)
				ShowImages(image0);
			if (textMesh.text == MateriRepository.Judul_Materi_2_1)
				ShowImages(image1);
			if (textMesh.text == MateriRepository.Judul_Materi_2_2)
				ShowImages(image2);
			if (textMesh.text == MateriRepository.Judul_Materi_2_3)
				ShowImages(image3);
		}

		void SetImageMateri3()
        {
			if (textMesh.text == MateriRepository.Judul_Materi_3_1)
				ShowImages(image1);
		}


		void ShowImages(Image image)
        {
			if (image != null)
            {
				image.gameObject.SetActive(true);

				if (image.gameObject.activeSelf)
				{
					if (btn_next != null)
						btn_next.SetActive(true);
				}

			}
		}

        IEnumerator TypeTextJustOnce(int index)
		{
			foreach (char letter in message[index].ToCharArray())
			{
				textMesh.text += letter;
				if (sound != null)
					audio_.PlayOneShot(sound);
				yield return 0;
				yield return new WaitForSeconds(delay);

				if (textMesh.text == message[index])
					btn_next.SetActive(true);
			}
		}

		IEnumerator TypeTextTitle(int index)
        {
			foreach (char letter in title[index].ToCharArray())
			{
				textMesh.text += letter;
				if (sound != null)
					audio_.PlayOneShot(sound);
				yield return 0;
				yield return new WaitForSeconds(delay);
			}
		}
        #endregion



        #region INTRUKSI

		IEnumerator TypeTextOne(int index0)
        {
            while (true)
            {
				foreach (char letter in message[index0].ToCharArray())
				{
					textMesh.text += letter;
					if (sound != null)
						audio_.PlayOneShot(sound);
					yield return 0;
					yield return new WaitForSeconds(delay);
				}
				yield return new WaitForSeconds(1.5f);
				textMesh.text = "";
				yield return new WaitForSeconds(1.0f);
			}
        }

		IEnumerator TypeTextTwo(int index0, int index1)
		{
			while (true)
			{
				foreach (char letter in message[index0].ToCharArray())
				{
					textMesh.text += letter;
					if (sound != null)
						audio_.PlayOneShot(sound);
					yield return 0;
					yield return new WaitForSeconds(delay);
				}
				yield return new WaitForSeconds(1.5f);
				textMesh.text = "";
				yield return new WaitForSeconds(1.0f);
				foreach (char letter in message[index1].ToCharArray())
				{
					textMesh.text += letter;
					if (sound != null)
						audio_.PlayOneShot(sound);
					yield return 0;
					yield return new WaitForSeconds(delay);
				}
				yield return new WaitForSeconds(1.5f);
				textMesh.text = "";
				yield return new WaitForSeconds(1.0f);
			}
		}

		IEnumerator TypeTextThree(int index0, int index1, int index2)
        {
            while (true)
            {
				foreach (char letter in message[index0].ToCharArray())
				{
					textMesh.text += letter;
					if (sound != null)
						audio_.PlayOneShot(sound);
					yield return 0;
					yield return new WaitForSeconds(delay);
				}
				yield return new WaitForSeconds(1.5f);
				textMesh.text = "";
				yield return new WaitForSeconds(1.0f);
				foreach (char letter in message[index1].ToCharArray())
				{
					textMesh.text += letter;
					if (sound != null)
						audio_.PlayOneShot(sound);
					yield return 0;
					yield return new WaitForSeconds(delay);
				}
				yield return new WaitForSeconds(1.5f);
				textMesh.text = "";
				yield return new WaitForSeconds(1.0f);
				foreach (char letter in message[index2].ToCharArray())
				{
					textMesh.text += letter;
					if (sound != null)
						audio_.PlayOneShot(sound);
					yield return 0;
					yield return new WaitForSeconds(delay);
				}
				yield return new WaitForSeconds(1.5f);
				textMesh.text = "";
				yield return new WaitForSeconds(1.0f);
			}

		}

		IEnumerator TypeTextFour(int index0, int index1, int index2, int index3)
        {
			while (true)
			{
				foreach (char letter in message[index0].ToCharArray())
				{
					textMesh.text += letter;
					if (sound != null)
						audio_.PlayOneShot(sound);
					yield return 0;
					yield return new WaitForSeconds(delay);
				}
				yield return new WaitForSeconds(1.5f);
				textMesh.text = "";
				yield return new WaitForSeconds(1.0f);
				foreach (char letter in message[index1].ToCharArray())
				{
					textMesh.text += letter;
					if (sound != null)
						audio_.PlayOneShot(sound);
					yield return 0;
					yield return new WaitForSeconds(delay);
				}
				yield return new WaitForSeconds(1.5f);
				textMesh.text = "";
				yield return new WaitForSeconds(1.0f);
				foreach (char letter in message[index2].ToCharArray())
				{
					textMesh.text += letter;
					if (sound != null)
						audio_.PlayOneShot(sound);
					yield return 0;
					yield return new WaitForSeconds(delay);
				}
				yield return new WaitForSeconds(1.5f);
				textMesh.text = "";
				yield return new WaitForSeconds(1.0f);
				foreach (char letter in message[index3].ToCharArray())
				{
					textMesh.text += letter;
					if (sound != null)
						audio_.PlayOneShot(sound);
					yield return 0;
					yield return new WaitForSeconds(delay);
				}
				yield return new WaitForSeconds(1.5f);
				textMesh.text = "";
				yield return new WaitForSeconds(1.0f);
			}
		}

		IEnumerator TypeTextFive(int index0, int index1, int index2, int index3, int index4)
		{
			while (true)
			{
				foreach (char letter in message[index0].ToCharArray())
				{
					textMesh.text += letter;
					if (sound != null)
						audio_.PlayOneShot(sound);
					yield return 0;
					yield return new WaitForSeconds(delay);
				}
				yield return new WaitForSeconds(1.5f);
				textMesh.text = "";
				yield return new WaitForSeconds(1.0f);
				foreach (char letter in message[index1].ToCharArray())
				{
					textMesh.text += letter;
					if (sound != null)
						audio_.PlayOneShot(sound);
					yield return 0;
					yield return new WaitForSeconds(delay);
				}
				yield return new WaitForSeconds(1.5f);
				textMesh.text = "";
				yield return new WaitForSeconds(1.0f);
				foreach (char letter in message[index2].ToCharArray())
				{
					textMesh.text += letter;
					if (sound != null)
						audio_.PlayOneShot(sound);
					yield return 0;
					yield return new WaitForSeconds(delay);
				}
				yield return new WaitForSeconds(1.5f);
				textMesh.text = "";
				yield return new WaitForSeconds(1.0f);
				foreach (char letter in message[index3].ToCharArray())
				{
					textMesh.text += letter;
					if (sound != null)
						audio_.PlayOneShot(sound);
					yield return 0;
					yield return new WaitForSeconds(delay);
				}
				yield return new WaitForSeconds(1.5f);
				textMesh.text = "";
				yield return new WaitForSeconds(1.0f);
				foreach (char letter in message[index4].ToCharArray())
				{
					textMesh.text += letter;
					if (sound != null)
						audio_.PlayOneShot(sound);
					yield return 0;
					yield return new WaitForSeconds(delay);
				}
				yield return new WaitForSeconds(1.5f);
				textMesh.text = "";
				yield return new WaitForSeconds(1.0f);
			}

		}

        #endregion
    }

}
