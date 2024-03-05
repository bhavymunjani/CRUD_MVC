using System;
using Npgsql;
namespace CRUD_MVC.Models
{
	public class EmployeeDB
	{
		public List<Employee> GetEmployees()
		{
			string cs = "Server=localhost;Port=5432;Database=postgres;User Id=postgres;Password=14181418;";
			NpgsqlConnection conn = null;

			List<Employee> EmployeeList = new List<Employee>();

			using(conn=new NpgsqlConnection(cs))
			{
				conn.Open();
				string select = "select * from public.Employee";
				NpgsqlCommand cmd = new NpgsqlCommand(select, conn);
				NpgsqlDataReader ndr = cmd.ExecuteReader();

				while (ndr.Read())
				{
					Employee emp = new Employee();
					emp.First_Name = ndr.GetValue(0).ToString();
					emp.Last_Name = ndr.GetValue(1).ToString();
					emp.Email = ndr.GetValue(2).ToString();
                    emp.Id = Convert.ToInt32(ndr.GetValue(3).ToString());
                    EmployeeList.Add(emp);
				}
            }
            return EmployeeList;
			
        }

		public bool AddEmployee(Employee emp)
		{
            string cs = "Server=localhost;Port=5432;Database=postgres;User Id=postgres;Password=14181418;";
            NpgsqlConnection conn = null;

			using(conn=new NpgsqlConnection(cs))
			{
				
				string insert = "insert into public.Employee values(@firstname,@lastname,@email)";
				NpgsqlCommand cmd = new NpgsqlCommand(insert, conn);
				cmd.Parameters.AddWithValue("@firstname", emp.First_Name);
                cmd.Parameters.AddWithValue("@lastname", emp.Last_Name);
                cmd.Parameters.AddWithValue("@email", emp.Email);
                conn.Open();
                int count=cmd.ExecuteNonQuery();

                if (count > 0)
				{
					return true;
				}
				else
				{
					return false;
				}
            }
        }

		public bool updateEmployee(Employee emp)
		{
            string cs = "Server=localhost;Port=5432;Database=postgres;User Id=postgres;Password=14181418;";
            NpgsqlConnection conn = null;

            using (conn = new NpgsqlConnection(cs))
			{
				conn.Open();
				string update = "Update public.Employee Set First_Name=@fname,Last_Name=@lname,Email=@email where Id=@id";
				NpgsqlCommand cmd = new NpgsqlCommand(update, conn);
				cmd.Parameters.AddWithValue("@fname", emp.First_Name);
				cmd.Parameters.AddWithValue("@lname", emp.Last_Name);
				cmd.Parameters.AddWithValue("@email", emp.Email);
				cmd.Parameters.AddWithValue("@id", emp.Id);
				int count=cmd.ExecuteNonQuery();

				if(count > 0)
				{
					return true;
				}
				else
				{
					return false;
				}
			}

        }

		public bool deleteEmployee(Employee emp)
		{
			string cs = "Server=localhost;Port=5432;Database=postgres;User Id=postgres;Password=14181418;";
			NpgsqlConnection conn = null;

			using (conn = new NpgsqlConnection(cs))
			{
				string delete = "delete from public.Employee where Id=@id";
				NpgsqlCommand cmd = new NpgsqlCommand(delete, conn);
				cmd.Parameters.AddWithValue("@id", emp.Id);
				conn.Open();
				int count = cmd.ExecuteNonQuery();

				if(count > 0)
				{
					return true;
				}
				else
				{
					return false;
				}
			}
		}

    }
}

