using System.Collections;
using UnityEngine;

public class PlayerEffects : MonoBehaviour
{
   public void AddSpeed(int speedGiven, float speedDuration)
    {
        PlayerMovements.instance.mMoveSpeed += speedGiven;
        StartCoroutine(RemoveSpeed(speedGiven, speedDuration));
    }

    private IEnumerator RemoveSpeed(int speedGiven, float speedDuration)
    {
        yield return new WaitForSeconds(speedDuration);
        PlayerMovements.instance.mMoveSpeed -= speedGiven;
    }
}
