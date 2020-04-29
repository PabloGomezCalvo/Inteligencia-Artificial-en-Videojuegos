
using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks.Unity.UnityTransform
{
    [TaskCategory("Unity/Custom")]
    [TaskDescription("Set the direction of look")]
    public class LookDirectionTask : Action
    {
        [Tooltip("The GameObject that the task operates on. If null the task GameObject is used.")]
        public SharedGameObject targetGameObject;

        private Transform targetTransform;
        private GameObject prevGameObject;
        private Rigidbody targetRigidbody;


        public override void OnStart()
        {
            var currentGameObject = GetDefaultGameObject(targetGameObject.Value);
            if (currentGameObject != prevGameObject)
            {
                targetTransform = currentGameObject.GetComponent<Transform>();
                prevGameObject = currentGameObject;
                targetRigidbody = currentGameObject.GetComponent<Rigidbody>();

            }
            if (currentGameObject != prevGameObject)
            {
            }
        }

        public override TaskStatus OnUpdate()
        {
            if (targetTransform == null)
            {
                Debug.LogWarning("Transform is null");
                return TaskStatus.Failure;
            }

            if (targetRigidbody == null)
            {
                Debug.LogWarning("rigidbody is null");
                return TaskStatus.Failure;
            }

            targetTransform.LookAt(targetTransform.position + targetRigidbody.velocity);

            

            return TaskStatus.Success;
        }

        public override void OnReset()
        {
            targetGameObject = null;
        }
    }
}