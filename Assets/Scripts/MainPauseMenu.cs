using System;
using UnityEngine;
using UnityEngine.UI;

public class MainPauseMenu : MonoBehaviour
{
  //  private Toggle m_MenuToggle;
	private float m_TimeScaleRef = 1f;
//    private float m_VolumeRef = 1f;
    private bool m_Paused;

    public GameObject pauseCanvas;


    private void PausedGame ()
    {
        m_TimeScaleRef = Time.timeScale;
        Time.timeScale = 0f;

        //      m_VolumeRef = AudioListener.volume;
        //      AudioListener.volume = 0f;
        pauseCanvas.SetActive(true);
        m_Paused = true;
    }


    public void UnpausedGame()
    {
        Time.timeScale = m_TimeScaleRef;
        pauseCanvas.SetActive(false);
    //    AudioListener.volume = m_VolumeRef;
        m_Paused = false;
    }


    public void OnMenuStatusChange ()
    {
        if (!m_Paused)
        {
            PausedGame();
        }
        else if (m_Paused)
        {
            UnpausedGame();
        }
    }



	void Update()
	{
		if(Input.GetKeyUp(KeyCode.Escape))
		{
            //    m_MenuToggle.isOn = !m_MenuToggle.isOn;
            OnMenuStatusChange();
        //    Cursor.visible = m_MenuToggle.isOn;//force the cursor visible if anythign had hidden it
		}
	}


}
