using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Yashlan 
{
    public class AnimationController : MonoBehaviour
    {
        private Animator anim;

        private void Awake()
        {
            anim = GetComponent<Animator>();
        }

        // Start is called before the first frame update
        void Start()
        {
            anim.SetBool("isMove", true);
        }


        #region EVENT ANIMATION
        public void IsMoveDisable()
        {
            anim.SetBool("isMove", false);
        }

        #endregion
    }
}


