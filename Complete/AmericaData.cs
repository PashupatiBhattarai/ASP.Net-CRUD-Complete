using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;



namespace Complete
{
    public class AmericaData
    {
        /// <summary>
        /// For getting data
        /// </summary>
        /// <returns> All usa data</returns>
        public List<America> GetAmerica()
        {
            List<America> lastAmerica = new List<America>();
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection("data source = HOMEPC;initial catalog=USA; integrated security=true");
                conn.Open();
                SqlCommand cmd = new SqlCommand("Select * from States", conn);
                SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    lastAmerica.Add(new America()
                    {
                        StateId = rd.GetInt32(0),
                        StateName = rd.GetString(1),
                        City = rd.GetString(2),
                        Population = rd.GetInt32(3),
                        Modifieddate = rd.GetDateTime(4)

                    });
                }
                return lastAmerica;
            }

            catch (Exception)
            {

                throw;
            }
            finally
            {
                conn.Close();
            }
        }
        /// <summary>
        /// For Add data
        /// </summary>
        /// <param name="StateName"></param>
        /// <param name="City"></param>
        /// <param name="Population"></param>
        /// <param name="Modifieddate"></param>
        public void Addmore(string StateName, string City, int Population, DateTime Modifieddate)
        {
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection("data source = HOMEPC;initial catalog=USA; integrated security=true");
                conn.Open();
                SqlCommand cmd = new SqlCommand("Adddata", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@statename", SqlDbType.VarChar, 50).Value = StateName;
                cmd.Parameters.Add("@city", SqlDbType.VarChar, 50).Value = City;
                cmd.Parameters.Add("@population", SqlDbType.Int).Value = Population;
                cmd.Parameters.Add("@modifiedate", SqlDbType.Date).Value = Modifieddate;
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                logger.LogIt("Addmore()", ex.Message);
            }
            finally
            {
                conn.Close();
            }


        }
        /// <summary>
        /// Update the data
        /// </summary>
        /// <param name="StateId"></param>
        /// <param name="StateName"></param>
        /// <param name="City"></param>
        /// <param name="Population"></param>
        /// <param name="Modifieddate"></param>
        public void UpdateMe(int StateId, string StateName, string City, int Population, DateTime Modifieddate)
        {
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection("data source = HOMEPC;initial catalog=USA; integrated security=true");
                conn.Open();
                SqlCommand cmd = new SqlCommand("updatetablee", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@stateid", SqlDbType.Int).Value = StateId;
                cmd.Parameters.Add("@statename", SqlDbType.VarChar, 50).Value = StateName;
                cmd.Parameters.Add("@city", SqlDbType.VarChar, 50).Value = City;
                cmd.Parameters.Add("@population", SqlDbType.Int).Value = Population;
                cmd.Parameters.Add("@modifieddate", SqlDbType.Date).Value = Modifieddate;
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                logger.LogIt("UpdateMe()", ex.Message);
            }
            finally
            {
                conn.Close();
            }

        }
        /// <summary>
        /// Delete Process
        /// </summary>
        /// <param name="StateId"></param>
        public void DeleteMe(int StateId)
        {
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection("data source = HOMEPC;initial catalog=USA; integrated security=true");
                conn.Open();
                SqlCommand cmd = new SqlCommand("deletedata", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@stateid", SqlDbType.Int).Value = StateId;
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                logger.LogIt("DeleteMe()", ex.Message);
            }
            finally
            {
                conn.Close();
            }


        }
        /// <summary>
        /// Find the Data
        /// </summary>
        /// <param name="StateId"></param>
        /// <returns></returns>
        public America FindCountryhome(int StateId)
        {
            America Ame = new America();
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection("data source = HOMEPC;initial catalog=USA; integrated security=true");
                conn.Open();
                SqlCommand cmd = new SqlCommand("finddata", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@stateid", SqlDbType.Int).Value = StateId;
                SqlDataReader rd = cmd.ExecuteReader();

                while (rd.Read())
                {
                    Ame = new America()
                    {
                        StateId = rd.GetInt32(0),
                        StateName = rd.GetString(1),
                        City = rd.GetString(2),
                        Population = rd.GetInt32(3),
                        Modifieddate = rd.GetDateTime(4)

                    };
                }
                return Ame;


            }
            catch (Exception ex)
            {
                logger.LogIt("FindCountryhome()", ex.Message);
                throw;
            }

            finally
            {
                conn.Close();
            }

           
            
            
        }
    }
}


