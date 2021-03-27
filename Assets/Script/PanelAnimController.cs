using UnityEngine;

namespace Yashlan
{
    public class PanelAnimController : MonoBehaviour
    {
        private SpriteRenderer sr;

        [SerializeField]
        private float alpha = 255;


        // Start is called before the first frame update
        void Start()
        {
            sr = GetComponent<SpriteRenderer>();
        }

        // Update is called once per frame
        void Update()
        {
            sr.color = new Color32(0, 0, 0, (byte)alpha);
            alpha -= 4;

            if (alpha <= 0)
                Destroy(gameObject);
        }
    }

}
