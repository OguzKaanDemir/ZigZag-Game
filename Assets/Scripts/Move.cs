using System.Collections;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Move : MonoBehaviour
{
    public Text pText;
    public int z = 0, point = 0, clrPoint = 0;
    public float speed;
    bool isStart;
    public CreateParkour cp;
    public GameObject StartPanel, TextPanel, Diamond;


    void Update()
    {

        if (transform.position.y < 0)
        {
            SceneManager.LoadScene(0);
        }

        if (isStart)
        {
            if (z%2 == 0)
            {
                transform.Translate(-speed * Time.deltaTime, 0, 0);
            }
            else
            {
                transform.Translate(0, 0, speed * Time.deltaTime);
            }
        }

        MoveBall();
        pText.text = point.ToString();
    }

    private void MoveBall()
    {
        if (Input.GetMouseButtonUp(0))
        {
            z++;
            point++;
            clrPoint++;
            StartPanel.SetActive(false);
            TextPanel.SetActive(true);
            isStart = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            cp.CreateObj();
            StartCoroutine(DeletePlatform(collision.gameObject));
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Diamond")
        {
            point += 3;
            clrPoint += 3;
            Destroy(other.gameObject);
        }
    }

    IEnumerator DeletePlatform(GameObject DP)
    {
        DP.GetComponent<Rigidbody>().isKinematic = false;
        yield return new WaitForSeconds(1f);
        Destroy(DP);

        if (Random.Range(0, 6.1f) >= 5)
        {
            Instantiate(Diamond, new Vector3(cp.LastObj.transform.position.x, cp.LastObj.transform.position.y + .75f, cp.LastObj.transform.position.z), Diamond.transform.rotation);
        }
    }
}
