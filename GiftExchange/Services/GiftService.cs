﻿using GiftExchange.Models;
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
        
        public List<Models.Presents> GetGiftList ()
        {
            var rv = new List<Models.Presents>();
            using (var connection = new SqlConnection(connectionString))
            {
                var query = "SELECT * FROM PresentsFinal";
                var cmd = new SqlCommand(query, connection);
                connection.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    rv.Add(new Models.Presents(reader));
                }
                connection.Close();

            }
                return rv;
        }
        public Presents AddGift (int id)
        {
            Presents gift = null;
            using (var connection = new SqlConnection(connectionString))
            {
                var query = "SELECT";
                var cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@Id", id);
                connection.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    gift = new Presents(reader);
                }
                connection.Close();
                
            }
            return gift;
        }
    }
}