using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AutoType : MonoBehaviour
{
	[Header("Button Next Materi")]
	public GameObject btn_next;

	[Header("hanya sekali")]
	public bool JustOnce = false;

    bool startAutoType = false;
	public float delay;
	public AudioClip sound;

    public string[] message;
    private Text text;
	AudioSource audio_;

	int index = 0;

	// Use this for initialization
	void Start()
	{
		audio_ = gameObject.AddComponent<AudioSource>();
		audio_.clip = sound;

		text = GetComponent<Text>();
		text.text = "";

		if (JustOnce)
        {
			StartCoroutine(TypeTextJustOnce(0));
		}

	}

	private void Update()
	{
		if (!startAutoType && !JustOnce)
		{
			startAutoType = true;
			StartCoroutine(TypeText(0,1,2,3,4));
		}		
	}

    #region Button Onclick
	public void AutoTypeOnClick()
    {
		int max_index = message.Length - 1;

		if (index >= max_index)
			index = 0;
		else
			index++;

		text.text = "";
		btn_next.SetActive(false);
		StartCoroutine(TypeTextJustOnce(index));
		//print(index);
	}
	#endregion

	IEnumerator TypeTextJustOnce(int index)
    {
		foreach (char letter in message[index].ToCharArray())
		{
			text.text += letter;
			if (sound != null)
				audio_.PlayOneShot(sound);
			yield return 0;
			yield return new WaitForSeconds(delay);

			if (text.text == message[index])
				btn_next.SetActive(true);
		}
	}

    IEnumerator TypeText(int index0, int index1, int index2, int index3, int index4)
	{
        while (true)
        {
			foreach (char letter in message[index0].ToCharArray())
			{
				text.text += letter;
				if (sound != null)
					audio_.PlayOneShot(sound);
				yield return 0;
				yield return new WaitForSeconds(delay);
			}
			yield return new WaitForSeconds(1.5f);
			text.text = "";
			yield return new WaitForSeconds(1.0f);
			foreach (char letter in message[index1].ToCharArray())
			{
				text.text += letter;
				if (sound != null)
					audio_.PlayOneShot(sound);
				yield return 0;
				yield return new WaitForSeconds(delay);
			}
			yield return new WaitForSeconds(1.5f);
			text.text = "";
			yield return new WaitForSeconds(1.0f);
			foreach (char letter in message[index2].ToCharArray())
			{
				text.text += letter;
				if (sound != null)
					audio_.PlayOneShot(sound);
				yield return 0;
				yield return new WaitForSeconds(delay);
			}
			yield return new WaitForSeconds(1.5f);
			text.text = "";
			yield return new WaitForSeconds(1.0f);
			foreach (char letter in message[index3].ToCharArray())
			{
				text.text += letter;
				if (sound != null)
					audio_.PlayOneShot(sound);
				yield return 0;
				yield return new WaitForSeconds(delay);
			}
			yield return new WaitForSeconds(1.5f);
			text.text = "";
			yield return new WaitForSeconds(1.0f);
			foreach (char letter in message[index4].ToCharArray())
			{
				text.text += letter;
				if (sound != null)
					audio_.PlayOneShot(sound);
				yield return 0;
				yield return new WaitForSeconds(delay);
			}
			yield return new WaitForSeconds(1.5f);
			text.text = "";
			yield return new WaitForSeconds(1.0f);
		}

	}
}
