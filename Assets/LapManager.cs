using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class LapManager : MonoBehaviour
{
    public List<checkpoint> checkpoints;
    public int totalLaps = 3;
    public UIManager ui;

    private List<Playerrank> playerRanks = new List<Playerrank>();
    private Playerrank mainPlayerRank;
    public UnityEvent onPlayerFinished = new UnityEvent();

    void Start()
    {
        // Get players in the scene
        foreach (CarIdentity carIdentity in GameObject.FindObjectsOfType<CarIdentity>())
        {
            playerRanks.Add(new Playerrank(carIdentity));
        }
        ListenCheckpoints(true);
        ui.UpdateText("Lap " + playerRanks[0].lapNumber + " / " + totalLaps);
        Debug.Log("Lap " + playerRanks[0].lapNumber + " / " + totalLaps);
        mainPlayerRank = playerRanks.Find(player => player.identity.gameObject.tag == "Player");
    }

    private void ListenCheckpoints(bool subscribe)
    {
        foreach (checkpoint checkpoint in checkpoints)
        {
            if (subscribe)
            {
                checkpoint.Subscribe(CheckpointActivated);
            }
            else
            {
                checkpoint.Unsubscribe(CheckpointActivated);
            }
        }
    }


    public void CheckpointActivated(CarIdentity car, checkpoint checkpoint)
    {
        Playerrank player = playerRanks.Find((rank) => rank.identity == car);
        if (checkpoints.Contains(checkpoint) && player != null)
        {
            // if player has already finished don't do anything
            if (player.hasFinished) return;

            int checkpointNumber = checkpoints.IndexOf(checkpoint);
            // first time ever the car reach the first checkpoint
            bool startingFirstLap = checkpointNumber == 0 && player.lastCheckpoint == -1;
            // finish line checkpoint is triggered & last checkpoint was reached
            bool lapIsFinished = checkpointNumber == 0 && player.lastCheckpoint >= checkpoints.Count - 1;
            if (startingFirstLap || lapIsFinished)
            {
                player.lapNumber += 1;
                player.lastCheckpoint = 0;
                Debug.Log($"{player.identity.driverName}: Lap {player.lapNumber} / {totalLaps}");
               

                // if this was the final lap
                if (player.lapNumber > totalLaps)
                {
                    player.hasFinished = true;
                    // getting final rank, by finding number of finished players
                    player.rank = playerRanks.FindAll(player => player.hasFinished).Count;

                    // if first winner, display its name
                    if (player.rank == 1)
                    {

                        // TODO : create attribute divername in CarIdentity 
                        //Debug.Log(player.identity.driverName + " won");
                        //ui.UpdateLapText(player.identity.driverName + " won");
                        Debug.Log(player.identity.driverName + " won");
                        ui.UpdateText(player.identity.driverName + " won");
                    }
                    else if (player == mainPlayerRank) // display player rank if not winner
                    {
                        ui.UpdateText("\nYou finished in " + mainPlayerRank.rank + " place");
                    }

                    if (player == mainPlayerRank) onPlayerFinished.Invoke();
                }
                if(player.identity.gameObject.tag == "Player" && player.hasFinished)
                {
                    SceneManager.LoadScene("Planet3.1");
                }
                else
                {
                    // TODO : create attribute divername in CarIdentity 
                    //Debug.Log(player.identity.driverName + ": lap " + player.lapNumber);
                    if (car.gameObject.tag == "Player") ui.UpdateText("Lap " + player.lapNumber + " / " + totalLaps);
                }
            }
            // next checkpoint reached
            else if (checkpointNumber == player.lastCheckpoint + 1)
            {
                player.lastCheckpoint += 1;
            }
        }
    }
}
