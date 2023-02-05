using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AdvanceCutscene : MonoBehaviour
{
    // Start is called before the first frame update
    public string scene;
    bool go = false;
    void Start()
    {
        StartCoroutine(WaitTime());
    }

    IEnumerator WaitTime()
    {
        yield return new WaitForSecondsRealtime(0.1f);
        go = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(go && !DialogueManager.Instance.dialogueIsPlaying)
            SceneManager.LoadScene(scene);
    }
}
