using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace GiftExchange.Models
{
    public class Presents
    {
        public Presents(SqlDataReader reader)
        {
            this.id = (int)reader["id"];
            this.Contents = reader["Contents"].ToString();
            this.GiftHint = reader["GiftHint"].ToString();
            this.ColorWrapper = reader["ColorWrapper"].ToString();
            this.Height = (int)reader["Height"];
            this.Width = (int)reader["Width"];
            this.Depth = (int)reader["Depth"];
            this.Weight = (int)reader["Weight"];
            this.IsOpened = (bool)reader["IsOpened"];
        }

        public int id { get; set; }
        public string Contents { get; set; }
        public string GiftHint { get; set; }
        public string ColorWrapper { get; set; }
        public double Height { get; set; }
        public double Width { get; set; }
        public double Depth { get; set; }
        public double Weight { get; set; }
        public bool IsOpened { get; set; }
    }
}