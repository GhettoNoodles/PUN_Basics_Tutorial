using System.Collections;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Com.SpeakGeek.JacquesPun
{
    [RequireComponent(typeof(TMP_InputField))]
    public class PlayerNameInputField : MonoBehaviour
    {
        #region Private Constants

            // Store the PlayerPref Key to avoid typos
            const string playerNamePrefKey = "PlayerName";

        #endregion

        #region MonoBehaviour CallBacks
            
            void Start()
            {
                string defaultName = string.Empty;
                InputField _inputField = this.GetComponent<InputField>();
                if (_inputField != null)
                {
                    if (PlayerPrefs.HasKey(playerNamePrefKey))
                    {
                        defaultName = PlayerPrefs.GetString(playerNamePrefKey);
                        _inputField.text = defaultName;
                    }
                }

                PhotonNetwork.NickName = defaultName;
            }

        #endregion

        #region Public Methods

            /// <summary>
            /// Sets the name of the player, and save it in the PlayerPrefs for future sessions.
            /// </summary>
            /// <param name="value">The name of the Player</param>
            public void SetPlayerName(string value)
            {
                // #Important
                if (string.IsNullOrEmpty(value))
                {
                    Debug.LogError("Player Name is null or empty");
                    return;
                }

                PhotonNetwork.NickName = value;

                PlayerPrefs.SetString(playerNamePrefKey, value);
            }

        #endregion
    }
}

