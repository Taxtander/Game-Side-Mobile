using UnityEngine;

namespace Player.Automatic
{
    public class AutomaticPlayerVariabls : MonoBehaviour
    {
        private PlayerAutoRun playerAutoRun;

        void Awake()
        {
            playerAutoRun = GetComponent<PlayerAutoRun>();
        }

        public float XScale
        {
            get => playerAutoRun.XScale;
            set => playerAutoRun.XScale = value;
        }

        public bool FaceRight
        {
            get => playerAutoRun.FaceRight;
            set => playerAutoRun.FaceRight = value;
        }

        public float Speed
        {
            get => playerAutoRun.Speed1;
            set => playerAutoRun.Speed1 = value;
        }
    }
}