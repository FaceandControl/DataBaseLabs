using DataBase3.Models;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace DataBase3
{
    class Model
    {
        private postgresContext ctx;

        public Model()
        {
            ctx = new postgresContext();
        }
        //Insert
        public Stadiums InsertStadium(string s_name, int capacity, string address)
        {
            ctx.Stadiums.Add(new Stadiums
            {
                SName = s_name,
                Capacity = capacity,
                Address = address
            });
            ctx.SaveChanges();
            return ctx.Stadiums.OrderByDescending(u => u.StadiumId).FirstOrDefault();
        }

        public Teams InsertTeam(string t_name, string trainer)
        {
            ctx.Teams.Add(new Teams
            {
                TName = t_name,
                Trainer = trainer
            });
            ctx.SaveChanges();
            return ctx.Teams.OrderByDescending(u => u.TeamId).FirstOrDefault();
        }

        public Matches InsertMatch(DateTime start_time, int StadiumID)
        {
            ctx.Matches.Add(new Matches
            {
                StartTime = start_time,
                StadiumId = StadiumID
            });
            ctx.SaveChanges();
            return ctx.Matches.OrderByDescending(u => u.MatchId).FirstOrDefault();
        }

        public Matches InsertMatch(DateTime start_time, string s_name)
        {
            int StadiumID = ctx.Stadiums.Single(u => u.SName == s_name).StadiumId;
            ctx.Matches.Add(new Matches
            {
                StartTime = start_time,
                StadiumId = StadiumID
            });
            ctx.SaveChanges();
            return ctx.Matches.OrderByDescending(u => u.MatchId).FirstOrDefault();
        }

        public Games InsertGame(int TeamID, int MatchID)
        {
            ctx.Games.Add(new Games
            {
                TeamId = TeamID,
                MatchId = MatchID
            });
            ctx.SaveChanges();
            return ctx.Games.OrderByDescending(u => u.GameId).FirstOrDefault();
        }

        public Games InsertGame(string t_name, DateTime start_time)
        {
            int TeamId = ctx.Teams.Single(u => u.TName == t_name).TeamId;
            int MatchId = ctx.Matches.Single(u => u.StartTime == start_time).MatchId;
            ctx.Games.Add(new Games
            {
                TeamId = TeamId,
                MatchId = MatchId
            });
            ctx.SaveChanges();
            return ctx.Games.OrderByDescending(u => u.GameId).FirstOrDefault();
        }

        public Goals InsertGoal(int minute, int TeamID, int MatchID)
        {
            ctx.Goals.Add(new Goals
            {
                Minute = minute,
                TeamId = TeamID,
                MatchId = MatchID
            });
            ctx.SaveChanges();
            return ctx.Goals.OrderByDescending(u => u.GoalId).FirstOrDefault();
        }

        public Goals InsertGoal(int minute, string t_name, DateTime start_time)
        {
            int TeamId = ctx.Teams.Single(u => u.TName == t_name).TeamId;
            int MatchId = ctx.Matches.Single(u => u.StartTime == start_time).MatchId;
            ctx.Goals.Add(new Goals
            {
                Minute = minute,
                TeamId = TeamId,
                MatchId = MatchId
            });
            ctx.SaveChanges();
            return ctx.Goals.OrderByDescending(u => u.GoalId).FirstOrDefault();
        }

        //Update

        public Stadiums UpdateStadium(string s_name, int capacity, string address, int StadiumID)
        {
            Stadiums stadium = ctx.Stadiums.Single(u => u.StadiumId == StadiumID);
            stadium.SName = s_name;
            stadium.Capacity = capacity;
            stadium.Address = address;
            ctx.SaveChanges();
            return ctx.Stadiums.Single(u => u.StadiumId == StadiumID);
        }

        public Teams UpdateTeam(string t_name, string trainer, int TeamID)
        {
            Teams team = ctx.Teams.Single(u => u.TeamId == TeamID);
            team.TName = t_name;
            team.Trainer = trainer;
            ctx.SaveChanges();
            return ctx.Teams.Single(u => u.TeamId == TeamID);
        }

        public Matches UpdateMatch(DateTime start_time, int StadiumID, int MatchID)
        {
            Matches match = ctx.Matches.Single(u => u.MatchId == MatchID);
            match.StartTime = start_time;
            match.StadiumId = StadiumID;
            ctx.SaveChanges();
            return ctx.Matches.Single(u => u.MatchId == MatchID);
        }

        public Games UpdateGame(int TeamID, int MatchID, int GameID)
        {
            Games game = ctx.Games.Single(u => u.GameId == GameID);
            game.TeamId = TeamID;
            game.MatchId = MatchID;
            ctx.SaveChanges();
            return ctx.Games.Single(u => u.GameId == GameID);
        }

        public Goals UpdateGoal(int minute, int TeamID, int MatchID, int GoalID)
        {
            Goals goals = ctx.Goals.Single(u => u.GoalId == GoalID);
            goals.Minute = minute;
            goals.TeamId = TeamID;
            goals.MatchId = MatchID;
            ctx.SaveChanges();
            return ctx.Goals.Single(u => u.GoalId == GoalID);
        }

        //Delete
        public int DeleteStadium(int StadiumID)
        {
            Stadiums stadium = ctx.Stadiums.Where(u => u.StadiumId == StadiumID).FirstOrDefault();
            ctx.Stadiums.Remove(stadium);
            return ctx.SaveChanges();
        }

        public int DeleteStadiums()
        {
            var stadiums = ctx.Set<Stadiums>();
            ctx.Stadiums.RemoveRange(stadiums);
            return ctx.SaveChanges();
        }

        public int DeleteTeam(int TeamID)
        {
            Teams team = ctx.Teams.Where(u => u.TeamId == TeamID).FirstOrDefault();
            ctx.Teams.Remove(team);
            return ctx.SaveChanges();
        }

        public int DeleteTeams()
        {
            var teams = ctx.Set<Teams>();
            ctx.Teams.RemoveRange(teams);
            return ctx.SaveChanges();
        }

        public int DeleteMatch(int MatchID)
        {
            Matches match = ctx.Matches.Where(u => u.MatchId == MatchID).FirstOrDefault();
            ctx.Matches.Remove(match);
            return ctx.SaveChanges();
        }

        public int DeleteMatches()
        {
            var matches = ctx.Set<Matches>();
            ctx.Matches.RemoveRange(matches);
            return ctx.SaveChanges();
        }

        public int DeleteGame(int GameID)
        {
            Games game = ctx.Games.Where(u => u.GameId == GameID).FirstOrDefault();
            ctx.Games.Remove(game);
            return ctx.SaveChanges();
        }

        public int DeleteGames()
        {
            var games = ctx.Set<Games>();
            ctx.Games.RemoveRange(games);
            return ctx.SaveChanges();
        }

        public int DeleteGoal(int GoalID)
        {
            Goals goal = ctx.Goals.Where(u => u.GoalId == GoalID).FirstOrDefault();
            ctx.Goals.Remove(goal);
            return ctx.SaveChanges();
        }

        public int DeleteGoals()
        {
            var goals = ctx.Set<Goals>();
            ctx.Goals.RemoveRange(goals);
            return ctx.SaveChanges();
        }

        //Read

        public List<T> ReadData<T>() where T:class
        {
            
            return ctx.Set<T>().ToList();
        }
    }
}
