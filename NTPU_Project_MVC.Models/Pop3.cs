using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace NTPU_Project_MVC.Models;

[Table("pop3")]
public class Pop3
{
    [Column("日期")]
    public DateTime? Date { get; set; }
    [Column("時間")]
    public string? Time { get; set; }

    public string? Ip { get; set; }

    public string? Hash { get; set; }
    [Column("國別")]
    public string? Country { get; set; }
}
