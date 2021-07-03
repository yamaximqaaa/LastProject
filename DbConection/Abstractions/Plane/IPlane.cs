using Entity.Enums;
using System;


namespace Abstractions.Plane
{
    public interface IPlane
    {
        #region plane prop
        string planeNum { get; set; }
        DateTime timeIn { get; set; }
        DateTime timeOut { get; set; }
        string city { get; set; }
        Airline airline { get; set; }
        Terminal terminal { get; set; }
        Status status { get; set; }
        string gate { get; set; }
        #endregion
    }
}
