
using System.Collections.Generic;

public class Commons
{

    private static Commons _instance = null;
    private static readonly object _syncLock = new object();

    Dictionary<state, State> Stat = new Dictionary<state, State>()
        {
            { state.PendingAcceptance, new State { Id = 1, Description = "Pending Acceptance"} },
            { state.Accepted, new State { Id = 2, Description = "Acceptance"} },
            { state.Bought, new State { Id = 3, Description = "Bought" } },
            { state.PickedUp, new State { Id = 4, Description = "PickUp" } },
            { state.Rejected, new State { Id = 5, Description = "Rejected" } }

        };

    public static Commons Instance
    {
        get
        {
            if (_instance != null) return _instance;
            lock (_syncLock)
            {
                if (_instance == null)
                {
                    _instance = new Commons();
                }
            }
            return _instance;
        }
    }

    public State GetStatus(state status)
    {
        return Stat[status];
    }

}

public enum state
{
    PendingAcceptance = 1,
    Accepted = 2,
    Bought = 3,
    PickedUp = 4,
    Rejected = 5
};