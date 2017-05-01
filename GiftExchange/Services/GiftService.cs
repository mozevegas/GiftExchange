using GiftExchange.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace GiftExchange.Services
{
    public class GiftService
    {
        // DatabaseLocation
        const string connectionString =
            @"Server=localhost\SQLEXPRESS;Database=GiftExchangeDB;Trusted_Connection=True;";
        
        public List<Presents> GetGiftList ()
        {
            var rv = new List<Presents>();
            using (var connection = new SqlConnection(connectionString))
            {
                var query = "SELECT * FROM PresentsFinal";
                var cmd = new SqlCommand(query, connection);
                connection.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    rv.Add(new Presents(reader));
                }
                connection.Close();
            }
            return rv;
        }

        public void AddGiftDB (Presents Present)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var query = $"INSERT INTO [dbo].[PresentsFinal] ([Contents], [Gift Hint], [ColorWrapper], [Height], [Width], [Depth],[Weight],[IsOpened]) VALUES({Present.Contents}, {Present.GiftHint}, {Present.ColorWrapper}, {Present.Height}, {Present.Width}, {Present.Depth}, {Present.Weight}, {Present.IsOpened})";
                var cmd = new SqlCommand(query, connection);
                // cmd.Parameters.AddWithValue
                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }
    }
}