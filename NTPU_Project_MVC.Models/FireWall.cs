using System;
using System.Collections.Generic;

namespace NTPU_Project_MVC.Models;

public partial class FireWall
{
    public string? Time { get; set; }

    public string? TypeId { get; set; }

    public string? Fw { get; set; }

    public string? Pri { get; set; }

    public string? Msg { get; set; }

    public string? Src { get; set; }

    public string? Dst { get; set; }

    public string? Proto { get; set; }

    public string? FwAction { get; set; }
}
