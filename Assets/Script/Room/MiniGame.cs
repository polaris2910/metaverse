using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MiniGame : MonoBehaviour
{
    private bool popupIsActive;

    public GameObject interactionPopup;  // 상호작용 안내 UI (에디터에서 연결)
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
        {
            popupIsActive = true;

            interactionPopup.SetActive(true); // 플레이어가 접근하면 팝업 표시

        }
    }
    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space) && popupIsActive)
        {
            SceneManager.LoadScene("bird"); //미니게임불러오기
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            popupIsActive = false;
            interactionPopup.SetActive(false); // 플레이어가 벗어나면 팝업 숨김
        }
    }

}
