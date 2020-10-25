using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Text;

namespace DataBaseLab2
{
    class Model
    {
        private string connstring = "Host=localhost;Username=postgres;Password=2749;Database=postgres";
        private NpgsqlConnection con;

        public Model() {
            con = new NpgsqlConnection(connstring);
            con.Open();
        }
        //Insert
        private int FindId(string id_name, string table_name, string colum_name, string param) {
            string sql = "SELECT \"" + id_name + "\" FROM public.\"" + table_name + "\" WHERE \"" + colum_name + "\"='" + param + "'";
            using var cmd = new NpgsqlCommand(sql, con);
            using NpgsqlDataReader rdr = cmd.ExecuteReader();
            rdr.Read();
            return rdr.GetInt32(0);
        }
        public NpgsqlDataReader InsertStadium(string s_name, int capacity, string address)
        {
            string sql = "INSERT INTO public.\"Stadiums\"(\"s_name\", \"capacity\", \"address\") " +
                "VALUES('" + s_name + "', " + capacity + ", '" + address + "')";
            using var cmd = new NpgsqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            cmd.CommandText = "SELECT * FROM public.\"Stadiums\" WHERE \"StadiumID\" = (SELECT MAX(\"StadiumID\") FROM public.\"Stadiums\")";
            return cmd.ExecuteReader();
        }
        public NpgsqlDataReader InsertTeam(string t_name, string trainer)
        {
            string sql = "INSERT INTO public.\"Teams\"(\"t_name\", \"trainer\") " +
                "VALUES('" + t_name + "', '" + trainer + "')";
            using var cmd = new NpgsqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            cmd.CommandText = "SELECT * FROM public.\"Teams\" WHERE \"TeamID\" = (SELECT MAX(\"TeamID\") FROM public.\"Teams\")";
            return cmd.ExecuteReader();
        }
        public NpgsqlDataReader InsertMatch(DateTime start_time, string s_name)
        {
            int StadiumID = FindId("StadiumID", "Stadiums", "s_name", s_name);
            string sql = "INSERT INTO public.\"Matches\"(\"start_time\", \"StadiumID\") " +
                "VALUES('" + start_time + "', " + StadiumID + ")";
            using var cmd = new NpgsqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            cmd.CommandText = "SELECT * FROM public.\"Matches\" WHERE \"MatchID\" = (SELECT MAX(\"MatchID\") FROM public.\"Matches\")";
            return cmd.ExecuteReader();
        }
        public NpgsqlDataReader InsertMatch(DateTime start_time, int StadiumID)
        {
            string sql = "INSERT INTO public.\"Matches\"(\"start_time\", \"StadiumID\") " +
                "VALUES('" + start_time + "', " + StadiumID + ")";
            using var cmd = new NpgsqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            cmd.CommandText = "SELECT * FROM public.\"Matches\" WHERE \"MatchID\" = (SELECT MAX(\"MatchID\") FROM public.\"Matches\")";
            return cmd.ExecuteReader();
        }
        public NpgsqlDataReader InsertGame(string t_name, DateTime start_time)
        {
            int TeamID = FindId("TeamID", "Teams", "t_name", t_name);
            int MatchID = FindId("MatchID", "Matches", "start_time", start_time.ToString());
            string sql = "INSERT INTO public.\"Games\"(\"TeamID\", \"MatchID\") " +
                "VALUES(" + TeamID + ", " + MatchID + ")";
            using var cmd = new NpgsqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            cmd.CommandText = "SELECT * FROM public.\"Games\" WHERE \"GameID\" = (SELECT MAX(\"GameID\") FROM public.\"Games\")";
            return cmd.ExecuteReader();
        }
        public NpgsqlDataReader InsertGame(int TeamID, int MatchID)
        {
            string sql = "INSERT INTO public.\"Games\"(\"TeamID\", \"MatchID\") " +
                "VALUES(" + TeamID + ", " + MatchID + ")";
            using var cmd = new NpgsqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            cmd.CommandText = "SELECT * FROM public.\"Games\" WHERE \"GameID\" = (SELECT MAX(\"GameID\") FROM public.\"Games\")";
            return cmd.ExecuteReader();
        }
        public NpgsqlDataReader InsertGoal(int minute, string t_name, DateTime start_time)
        {
            int TeamID = FindId("TeamID", "Teams", "t_name", t_name);
            int MatchID = FindId("MatchID", "Matches", "start_time", start_time.ToString());
            string sql = "INSERT INTO public.\"Goals\"(\"minute\", \"TeamID\", \"MatchID\") " +
                "VALUES(" + minute + ", " + TeamID + ", " + MatchID + ")";
            using var cmd = new NpgsqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            cmd.CommandText = "SELECT * FROM public.\"Goals\" WHERE \"GoalID\" = (SELECT MAX(\"GoalID\") FROM public.\"Goals\")";
            return cmd.ExecuteReader();
        }
        public NpgsqlDataReader InsertGoal(int minute, int TeamID, int MatchID)
        {
            string sql = "INSERT INTO public.\"Goals\"(\"minute\", \"TeamID\", \"MatchID\") " +
                "VALUES(" + minute + ", " + TeamID + ", " + MatchID + ")";
            using var cmd = new NpgsqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            cmd.CommandText = "SELECT * FROM public.\"Goals\" WHERE \"GoalID\" = (SELECT MAX(\"GoalID\") FROM public.\"Goals\")";
            return cmd.ExecuteReader();
        }
        //Update
        public NpgsqlDataReader UpdateStadium(string s_name, int capacity, string address, int StadiumID)
        {
            string sql = "UPDATE public.\"Stadiums\" SET \"s_name\"= '" + s_name + "' ," +
                " \"capacity\" = " + capacity + ", \"address\" ='" + address + "' WHERE \"StadiumID\" = " + StadiumID;
            using var cmd = new NpgsqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            cmd.CommandText = "SELECT * FROM public.\"Stadiums\" WHERE \"StadiumID\" = " + StadiumID;
            return cmd.ExecuteReader();
        }
        public NpgsqlDataReader UpdateTeam(string t_name, string trainer, int TeamID)
        {
            string sql = "UPDATE public.\"Teams\" SET \"t_name\"='" + t_name + "', \"trainer\"= '" +
                trainer + "' WHERE \"TeamID\" = " + TeamID;
            using var cmd = new NpgsqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            cmd.CommandText = "SELECT * FROM public.\"Teams\" WHERE \"TeamID\" = " + TeamID;
            return cmd.ExecuteReader();
        }
        public NpgsqlDataReader UpdateMatch(DateTime start_time, int StadiumID, int MatchID)
        {
            string sql = "UPDATE public.\"Matches\" SET \"start_time\"= '" + start_time + "', \"StadiumID\"= " +
                StadiumID + " WHERE \"MatchID\" = " + MatchID;
            using var cmd = new NpgsqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            cmd.CommandText = "SELECT * FROM public.\"Matches\" WHERE \"MatchID\" = " + MatchID;
            return cmd.ExecuteReader();
        }
        public NpgsqlDataReader UpdateGame(int TeamID, int MatchID, int GameID)
        {
            string sql = "UPDATE public.\"Games\" SET \"TeamID\"= " + TeamID + ", \"MatchID\"= " +
                MatchID + " WHERE \"GameID\" = " + GameID;
            using var cmd = new NpgsqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            cmd.CommandText = "SELECT * FROM public.\"Games\" WHERE \"GameID\" = " + GameID;
            return cmd.ExecuteReader();
        }
        public NpgsqlDataReader UpdateGoal(int minute, int TeamID, int MatchID, int GoalID)
        {
            string sql = "UPDATE public.\"Goals\" SET \"minute\"= " + minute + ", \"TeamID\"= " +
               TeamID + ", \"MatchID\"= " + MatchID + "  WHERE \"GoalID\" = " + GoalID;
            using var cmd = new NpgsqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            cmd.CommandText = "SELECT * FROM public.\"Goals\" WHERE \"GoalID\" = " + GoalID;
            return cmd.ExecuteReader();
        }
        //Delete
        public int DeleteStadium(int StadiumID)
        {
            string sql = "DELETE FROM public.\"Stadiums\" WHERE \"StadiumID\" = " + StadiumID;
            using var cmd = new NpgsqlCommand(sql, con);
            return cmd.ExecuteNonQuery();
        }

        public int DeleteStadiums() {
            string sql = "DELETE FROM public.\"Stadiums\"";
            using var cmd = new NpgsqlCommand(sql, con);
            return cmd.ExecuteNonQuery();
        }

        public int DeleteTeam(int TeamID)
        {
            string sql = "DELETE FROM public.\"Teams\" WHERE \"TeamID\" = " + TeamID;
            using var cmd = new NpgsqlCommand(sql, con);
            return cmd.ExecuteNonQuery();
        }

        public int DeleteTeams()
        {
            string sql = "DELETE FROM public.\"Teams\"";
            using var cmd = new NpgsqlCommand(sql, con);
            return cmd.ExecuteNonQuery();
        }

        public int DeleteMatch(int MatchID)
        {
            string sql = "DELETE FROM public.\"Matches\" WHERE \"MatchID\" = " + MatchID;
            using var cmd = new NpgsqlCommand(sql, con);
            return cmd.ExecuteNonQuery();
        }

        public int DeleteMatches()
        {
            string sql = "DELETE FROM public.\"Matches\"";
            using var cmd = new NpgsqlCommand(sql, con);
            return cmd.ExecuteNonQuery();
        }

        public int DeleteGame(int GameID)
        {
            string sql = "DELETE FROM public.\"Games\" WHERE \"GameID\" = " + GameID;
            using var cmd = new NpgsqlCommand(sql, con);
            return cmd.ExecuteNonQuery();
        }

        public int DeleteGames()
        {
            string sql = "DELETE FROM public.\"Games\"";
            using var cmd = new NpgsqlCommand(sql, con);
            return cmd.ExecuteNonQuery();
        }

        public int DeleteGoal(int GoalID)
        {
            string sql = "DELETE FROM public.\"Goals\" WHERE \"GoalID\" = " + GoalID;
            using var cmd = new NpgsqlCommand(sql, con);
            return cmd.ExecuteNonQuery();
        }

        public int DeleteGoals()
        {
            string sql = "DELETE FROM public.\"Goals\"";
            using var cmd = new NpgsqlCommand(sql, con);
            return cmd.ExecuteNonQuery();
        }
        //Read
        public NpgsqlDataReader ReadStadiums() {
            string sql = "SELECT * FROM public.\"Stadiums\"";
            using var cmd = new NpgsqlCommand(sql, con);
            return cmd.ExecuteReader();
        }
        public NpgsqlDataReader ReadTeams()
        {
            string sql = "SELECT * FROM public.\"Teams\"";
            using var cmd = new NpgsqlCommand(sql, con);
            return cmd.ExecuteReader();
        }
        public NpgsqlDataReader ReadMatches()
        {
            string sql = "SELECT * FROM public.\"Matches\"";
            using var cmd = new NpgsqlCommand(sql, con);
            return cmd.ExecuteReader();
        }

        public NpgsqlDataReader ReadGames()
        {
            string sql = "SELECT * FROM public.\"Games\"";
            using var cmd = new NpgsqlCommand(sql, con);
            return cmd.ExecuteReader();
        }

        public NpgsqlDataReader ReadGoals()
        {
            string sql = "SELECT * FROM public.\"Goals\"";
            using var cmd = new NpgsqlCommand(sql, con);
            return cmd.ExecuteReader();
        }
        //RandomInsert
        public int RandomInsertStadiums(int counter) {
            string sql_random_letter = "chr(trunc(65 + random() * 25)::int)";
            string sql = "INSERT INTO public.\"Stadiums\" (\"s_name\",  \"capacity\",  \"address\") SELECT " +
                sql_random_letter + " || " + sql_random_letter + ", round(100 + random() * 99900)," +
                sql_random_letter + " || " + sql_random_letter + " || " + sql_random_letter +
                "FROM generate_series(1, " + counter + ")";
            using var cmd = new NpgsqlCommand(sql, con);
            return cmd.ExecuteNonQuery();
        }
        public int RandomInsertTeams(int counter)
        {
            string sql_random_letter = "chr(trunc(65 + random() * 25)::int)";
            string sql = "INSERT INTO public.\"Teams\" (\"t_name\",  \"trainer\") SELECT " +
                sql_random_letter + " || " + sql_random_letter + "," +
                sql_random_letter + " || " + sql_random_letter + " || " + sql_random_letter +
                "FROM generate_series(1, " + counter + ")";
            using var cmd = new NpgsqlCommand(sql, con);
            return cmd.ExecuteNonQuery();
        }
        
        public int RandomInsertMatches(int counter)
        {
            string sql = "INSERT INTO public.\"Matches\" (\"start_time\",  \"StadiumID\") SELECT " +
                "timestamp '2020-01-10' + random() * (timestamp '2040-01-01' - timestamp '2020-01-01'), " +
                "(SELECT \"StadiumID\" FROM public.\"Stadiums\" ORDER BY random() limit 1) " +
                "FROM generate_series(1, " + counter + ")";
            using var cmd = new NpgsqlCommand(sql, con);
            return cmd.ExecuteNonQuery();
        }
        public int RandomInsertGames(int counter)
        {
            string sql = "INSERT INTO public.\"Games\" (\"TeamID\",  \"MatchID\") SELECT " +
                 "(SELECT \"TeamID\" FROM public.\"Teams\" ORDER BY random() limit 1), " +
                 "(SELECT \"MatchID\" FROM public.\"Matches\" ORDER BY random() limit 1) " +
                 "FROM generate_series(1, " + counter + ")";
            using var cmd = new NpgsqlCommand(sql, con);
            return cmd.ExecuteNonQuery();
        }
        public int RandomInsertGoals(int counter)
        {
            string sql = "INSERT INTO public.\"Goals\" (\"minute\", \"TeamID\",  \"MatchID\") SELECT " +
                 "round(random() * 90)," +
                 "(SELECT \"TeamID\" FROM public.\"Teams\" ORDER BY random() limit 1), " +
                 "(SELECT \"MatchID\" FROM public.\"Matches\" ORDER BY random() limit 1) " +
                 "FROM generate_series(1, " + counter + ")";
            using var cmd = new NpgsqlCommand(sql, con);
            return cmd.ExecuteNonQuery();
        }
        public NpgsqlDataReader SelectLIKE(char s_ch, char t_ch) {
            string sql = "SELECT DISTINCT public.\"Stadiums\".\"s_name\", public.\"Teams\".\"t_name\", public.\"Teams\".\"trainer\"" +
                            "FROM public.\"Teams\" INNER JOIN " +
                            "public.\"Games\" ON public.\"Teams\".\"TeamID\" = public.\"Games\".\"TeamID\" " +
                            "INNER JOIN public.\"Matches\" ON public.\"Matches\".\"MatchID\" = public.\"Games\".\"MatchID\" " +
                            "INNER JOIN public.\"Stadiums\" ON public.\"Stadiums\".\"StadiumID\"=public.\"Matches\".\"StadiumID\" " +
                            "WHERE \"s_name\" LIKE '" + s_ch + "%' AND \"t_name\" LIKE '" + t_ch + "%'";
            using var cmd = new NpgsqlCommand(sql, con);
            return cmd.ExecuteReader();
        }
        public NpgsqlDataReader SelectMatchesUpToMin(int minute, int count_goals)
        {
            string sql = "select distinct \"MatchID\" from public.\"Goals\" as \"g\"" +
                            " where (SELECT Count(*) FROM public.\"Goals\" where minute < " + minute + "" +
                            " and \"MatchID\" = \"g\".\"MatchID\") > " + count_goals;
            using var cmd = new NpgsqlCommand(sql, con);
            return cmd.ExecuteReader();
        }
        public NpgsqlDataReader SelectTeamWhereMaxGoals()
        {
            string sql = "select distinct \"TeamID\" from public.\"Goals\" as \"m\" " +
                            "where (select Count(*) from public.\"Goals\" " +
                            "where public.\"Goals\".\"MatchID\" = \"m\".\"MatchID\" " +
                            "and public.\"Goals\".\"TeamID\" = \"m\".\"TeamID\") = " +
                            "(select max(y.m) from (select count(*) as m " +
                            "from public.\"Goals\" group by public.\"Goals\".\"MatchID\", " +
                            "public.\"Goals\".\"TeamID\") as y)";
            using var cmd = new NpgsqlCommand(sql, con);
            return cmd.ExecuteReader();
        }


    }
}

/*
 SELECT DISTINCT public."Stadiums"."s_name", public."Teams"."t_name", public."Teams"."trainer" 
FROM public."Teams" INNER JOIN
public."Games" ON public."Teams"."TeamID" = public."Games"."TeamID"
INNER JOIN public."Matches" ON public."Matches"."MatchID" = public."Games"."MatchID"
INNER JOIN public."Stadiums" ON public."Stadiums"."StadiumID"=public."Matches"."StadiumID" 
WHERE "s_name" LIKE 'M%' AND "t_name" LIKE 'S%'

 -- SELECT Count(*) FROM public."Goals" where minute < 30 group by "MatchID"; --
select distinct "MatchID" from public."Goals" as "g" where (SELECT Count(*) FROM public."Goals" where minute < 30 and "MatchID" = "g"."MatchID") > 2

 select distinct "TeamID" from public."Goals" as "m" where (select Count(*) from public."Goals" where public."Goals"."MatchID" = "m"."MatchID" 
 and public."Goals"."TeamID" = "m"."TeamID") = (select max(y.m) from (select count(*) as m from public."Goals" group by public."Goals"."MatchID",
 public."Goals"."TeamID") as y)
*/

