using Reactivities.Application.Core;
using System;

namespace Reactivities.Application.Activities
{
    public class ActivityParams : PagingParams
    {
        public bool isGoing { get; set; }
        public bool isHost { get; set; }
        public DateTime StartDate { get; set; } = DateTime.UtcNow;
    }
}
