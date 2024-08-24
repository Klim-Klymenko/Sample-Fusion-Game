using System;
using UnityEngine;

namespace Sample.System
{
    public sealed class ClickInput : MonoBehaviour
    {
        public event Action<Vector3> OnPointClicked;
        public event Action<GameObject> OnTargetClicked; 

        [SerializeField]
        private Camera _camera;

        [SerializeField]
        private LayerMask _layerMask;

        private void Update()
        {
            if (!Input.GetMouseButtonDown(0))
            {
                return;
            }

            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

            if (!Physics.Raycast(ray, out RaycastHit raycastHit, 200f, _layerMask))
            {
                return;
            }

            Transform hitTransform = raycastHit.transform;
            if (hitTransform.CompareTag(GameObjectTags.GROUND))
            {
                Debug.Log($"POINT CLICKED {raycastHit.point}");
                this.OnPointClicked?.Invoke(raycastHit.point);
            }
            else if (hitTransform.CompareTag(GameObjectTags.ENTITY))
            {
                Debug.Log($"TARGET CLICKED {hitTransform.name}");
                this.OnTargetClicked?.Invoke(hitTransform.gameObject);
            }
        }
    }
}