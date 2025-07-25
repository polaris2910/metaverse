using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MiniGame : MonoBehaviour
{
    private bool popupIsActive;

    public GameObject interactionPopup;  // ��ȣ�ۿ� �ȳ� UI (�����Ϳ��� ����)
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
        {
            popupIsActive = true;

            interactionPopup.SetActive(true); // �÷��̾ �����ϸ� �˾� ǥ��

        }
    }
    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space) && popupIsActive)
        {
            SceneManager.LoadScene("bird"); //�̴ϰ��Ӻҷ�����
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            popupIsActive = false;
            interactionPopup.SetActive(false); // �÷��̾ ����� �˾� ����
        }
    }

}
