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
                    rv.Add(new Presents()
                    {
                        id = (int)reader["id"],
                        Contents = reader["Contents"].ToString(),
                        GiftHint = reader["GiftHint"].ToString(),
                        ColorWrapper = reader["ColorWrapper"].ToString(),
                        Height = (double?)reader["Height"],
                        Width = (double?)reader["Width"],
                        Depth = (double?)reader["Depth"],
                        Weight = (double?)reader["Weight"],
                        IsOpened = (bool)reader["IsOpened"]
                });
                }
                connection.Close();

            }
                return rv;
        }
        public static void AddGiftDB (Presents GiftNew)
        {
            const string connectionString =
                            @"Server=localhost\SQLEXPRESS;Database=GiftExchangeDB;Trusted_Connection=True;";
            using (var connection = new SqlConnection(connectionString))
            {
                var query = $"INSERT INTO [dbo].[PresentsFinal] ([Contents], [Gift Hint], [ColorWrapper], [Height], [Width], [Depth],[Weight],[IsOpened]) VALUES ({GiftNew.Contents}, {GiftNew.GiftHint}, {GiftNew.ColorWrapper}, {GiftNew.Height}, {GiftNew.Width}, {GiftNew.Depth}, {GiftNew.Weight}, {GiftNew.IsOpened})";
                var cmd = new SqlCommand(query, connection);
                // cmd.Parameters.AddWithValue
                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }
    }
}