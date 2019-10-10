using System.Collections.Generic;

namespace BzCOMWpf
{
    public enum Status
    {
        AVAILABLE,
        BRB,
        BUSY,
        UNAVAILABLE,
        UNKNOWN
    }

    public enum State
    {
        Disconnected,
        Connected,
        LoggedIn,
        DataSet,
        OpenedGate
    }
}
