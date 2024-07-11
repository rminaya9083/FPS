using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ChineseCyborgWarrior
{
    [ExecuteInEditMode]
    public sealed class EyeGetMatrix : MonoBehaviour
    {
        Renderer rend;
        public Transform head;
        private void Awake()
        {
            rend = GetComponent<Renderer>();
        }
        // Update is called once per frame
        void Update()
        {
            rend.material.SetMatrix("LocalToWorldMatrix_Inverse", head.localToWorldMatrix.inverse);
            rend.material.SetFloat("ScaleMul", transform.root.localScale.y * 3.266372f);
        }
    }

}
