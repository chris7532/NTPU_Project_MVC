using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace NTPU_Project_MVC.Models;

[Table("top20table")]
public partial class Top20table
{
    [Column("日期")]
    public string? Date { get; set; }

    public int? Hour { get; set; }

    public string? Src { get; set; }

    public string? Dst { get; set; }

    public int? Cnt { get; set; }

    public long? Rank { get; set; }
}
