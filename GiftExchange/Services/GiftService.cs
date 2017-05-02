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

        public List<Presents> GetGiftList()
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

        public Presents AddGiftDB(Presents Presents)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var query = @"INSERT INTO [dbo].[PresentsFinal]
                            ([Contents]
                            ,[GiftHint]
                            , [ColorWrapper]
                            , [Height]
                            , [Width]
                            , [Depth]
                            ,[Weight]
                            ,[IsOpened])
                            VALUES( @Contents, @GiftHint, @ColorWrapper, @Height, @Width, @Depth, @Weight, @IsOpened)";
                var cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@Contents", Presents.Contents);
                cmd.Parameters.AddWithValue("@GiftHint", Presents.GiftHint);
                cmd.Parameters.AddWithValue("@ColorWrapper", Presents.ColorWrapper);
                cmd.Parameters.AddWithValue("@Height", Presents.Height);
                cmd.Parameters.AddWithValue("@Width", Presents.Width);
                cmd.Parameters.AddWithValue("@Depth", Presents.Depth);
                cmd.Parameters.AddWithValue("@Weight", Presents.Weight);
                cmd.Parameters.AddWithValue("@IsOpened", Presents.IsOpened);
                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
            }
            return Presents;
        }
        public static Presents GetPresent(int id)
        {
            var present = new List<Presents>();
            using (var connection = new SqlConnection(connectionString))
            {
                var query = "SELECT * FROM PresentsFinal WHERE id=@Id";
                var cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@id", id);
                connection.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    present.Add(new Presents(reader));
                }
                connection.Close();
            }
            return present[0];
        }
        public Presents EditPresent(Presents Present)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var query = @"UPDATE [dbo].[PresentsFinal]
                           SET[Contents]=@Contents
			               ,[GiftHint]=@GiftHint
                           ,[ColorWrapper]=@ColorWrapper
                           ,[Height]=@Height
                           ,[Width]=@Width
                           ,[Depth]=@Depth
                           ,[Weight]=@Weight
                           ,[IsOpened]=@IsOpened
                            WHERE Id=@Id";
                var cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@Id", Present.Id);
                cmd.Parameters.AddWithValue("@Contents", Present.Contents);
                cmd.Parameters.AddWithValue("@GiftHint", Present.GiftHint);
                cmd.Parameters.AddWithValue("@ColorWrapper", Present.ColorWrapper);
                cmd.Parameters.AddWithValue("@Height", Present.Height);
                cmd.Parameters.AddWithValue("@Width", Present.Width);
                cmd.Parameters.AddWithValue("@Depth", Present.Depth);
                cmd.Parameters.AddWithValue("@Weight", Present.Weight);
                cmd.Parameters.AddWithValue("@IsOpened", Present.IsOpened);
                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
            }
            return Present;
        }
        public Presents DeletePresent(Presents Present)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var query = @"DELETE FROM [dbo].[PresentsFinal] WHERE Id=@Id";
                var cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@id", Present.Id);
                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
            }
            return Present;
        }
    }
}