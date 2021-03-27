using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

namespace Yashlan
{
	public class AutoType : MonoBehaviour
	{
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
			}
		}

		// Use this for initialization
		void Start()
		{
			audio_ = gameObject.AddComponent<AudioSource>();
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
				StartCoroutine(TypeText(0, 1, 2, 3, 4));
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

			//print(index);
		}
        #endregion

        #region MATERI SCENE
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
        IEnumerator TypeText(int index0, int index1, int index2, int index3, int index4)
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
