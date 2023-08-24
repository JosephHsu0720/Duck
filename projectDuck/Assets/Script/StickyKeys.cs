using System.Runtime.InteropServices;
using UnityEngine;

// https://forum.unity.com/threads/windows-sticky-keys-prompt.678487/
// https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-systemparametersinfoa


public class StickyKeys : MonoBehaviour {

#if UNITY_EDITOR_WIN || UNITY_STANDALONE_WIN

    public void Awake() {
        WindowsHelperAccessibilityKeys.DisableStickyKeyShortcut();
    }

    public class WindowsHelperAccessibilityKeys {
        [DllImport("user32.dll", EntryPoint = "SystemParametersInfo", SetLastError = false)]
        private static extern bool SystemParametersInfo(uint action, uint param, ref SKEY vparam, uint init);

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public struct SKEY {
            public uint cbSize;
            public uint dwFlags;
        }

        private static uint SKEYSize = sizeof(uint) * 2;

        public static bool GetStickyKeys() {
            SKEY StickyKeyParams = new SKEY { cbSize = SKEYSize, dwFlags = 0 };
            // 0x003A => Get sticky keys status
            SystemParametersInfo(0x003A, SKEYSize, ref StickyKeyParams, 0);

            return IsBitSet(StickyKeyParams.dwFlags, 0);
        }

        public static void DisableStickyKeyShortcut() {
            SKEY StickyKeyParams = new SKEY { cbSize = SKEYSize, dwFlags = 0 };
            // 0x003B => Set sticky keys
            SystemParametersInfo(0x003B, SKEYSize, ref StickyKeyParams, 0);
        }

        private static bool IsBitSet(uint value, int position) {
            return (value & (1 << position)) != 0;
        }
    }
#endif
}
