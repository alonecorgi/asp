using System;
using System.Collections.Generic;

namespace Led.Models;

public partial class LED_state
{
    public int id { get; set; }

    public string? state { get; set; }

    public DateTime? time { get; set; }
}
