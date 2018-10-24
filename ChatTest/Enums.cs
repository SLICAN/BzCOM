using System.Collections.Generic;

namespace ChatTest
{
    /// <summary>
    /// 
    /// </summary>
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
