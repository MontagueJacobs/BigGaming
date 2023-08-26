using UnityEngine;

public class TimeManager : MonoBehaviour
{
    [SerializeField ] float SlowdownFactor;
    [SerializeField]  float SlowDownLength;

    void Update(){
        Time.timeScale += (1f / SlowDownLength ) * Time.unscaledDeltaTime;
        Time.timeScale = Mathf.Clamp(Time.timeScale,0f,1f);
    }
   public void SlowMotion() {
        Time.timeScale = SlowdownFactor;
        Time.fixedDeltaTime = Time.timeScale * 0.2f;
    }
    
 }
