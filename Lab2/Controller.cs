using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace DataBaseLab2
{
    class Controller
    {
        private Model model;
        public Controller() {
            model = new Model();
        }
        public void ControllerLoop() {
            while (true)
            {
                View.MainMenu();
                int command_int = 0;
                string command = Console.ReadLine();
                try
                {
                    command_int = Convert.ToInt32(command);
                }
                catch (Exception ex) {
                    View.ReportError(ex.Message);
                }
                switch (command_int) {
                    case 1:
                        View.InsertInfo();
                        Insert(Console.ReadLine());
                        break;
                    case 2:
                        View.UpdateInfo();
                        Update(Console.ReadLine());
                        break;
                    case 3:
                        View.DeleteInfo();
                        Delete(Console.ReadLine());
                        break;
                    case 4:
                        View.ReadInfo();
                        Read(Console.ReadLine());
                        break;
                    case 5:
                        View.SelectInfo();
                        Select(Console.ReadLine());
                        break;
                    case 6:
                        View.RandomSelectInfo();
                        RandomInsert(Console.ReadLine());
                        break;
                }
                
            }
        }
        public void Insert(string task)
        {
            string[] parameters = task.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (parameters.Length == 0)
                return;
            switch (parameters[0])
            {
                case "Stadiums":
                    try
                    {
                        string s_name = parameters[1];
                        int capacity = Convert.ToInt32(parameters[2]);
                        string address = parameters[3];
                        View.ShowRead(model.InsertStadium(s_name, capacity, address));
                    }
                    catch (Exception ex) { View.ReportError(ex.Message); }
                    break;
                case "Teams":
                    try
                    {
                        string t_name = parameters[1];
                        string trainer = parameters[2];
                        View.ShowRead(model.InsertTeam(t_name, trainer));
                    }
                    catch (Exception ex) { View.ReportError(ex.Message); }
                    break;
                case "Matches":
                    try
                    {
                        DateTime start_time = Convert.ToDateTime(parameters[1]);
                        string s_name = parameters[2];
                        View.ShowRead(model.InsertMatch(start_time, s_name));
                    }
                    catch (Exception ex)
                    {
                        try
                        {
                            DateTime start_time = Convert.ToDateTime(parameters[1]);
                            int StadiumID = Convert.ToInt32(parameters[2]);
                            View.ShowRead(model.InsertMatch(start_time, StadiumID));
                        }
                        catch (Exception ex1) { View.ReportErrors(ex.Message, ex1.Message); }
                    }
                    break;
                case "Games":
                    try
                    {
                        string t_name = parameters[1];
                        DateTime start_time = Convert.ToDateTime(parameters[2]);
                        View.ShowRead(model.InsertGame(t_name, start_time));
                    }
                    catch (Exception ex)
                    {
                        try
                        {
                            int TeamID = Convert.ToInt32(parameters[1]);
                            int MatchID = Convert.ToInt32(parameters[2]);
                            View.ShowRead(model.InsertGame(TeamID, MatchID));
                        }
                        catch (Exception ex1) { View.ReportErrors(ex.Message, ex1.Message); }
                    }
                    break;
                case "Goals":
                    try
                    {
                        int minute = Convert.ToInt32(parameters[1]);
                        string t_name = parameters[2];
                        DateTime start_time = Convert.ToDateTime(parameters[3]);
                        View.ShowRead(model.InsertGoal(minute, t_name, start_time));
                    }
                    catch (Exception ex)
                    {
                        try
                        {
                            int minute = Convert.ToInt32(parameters[1]);
                            int TeamID = Convert.ToInt32(parameters[2]);
                            int MatchID = Convert.ToInt32(parameters[3]);
                            View.ShowRead(model.InsertGoal(minute, TeamID, MatchID));
                        }
                        catch (Exception ex1) { View.ReportErrors(ex.Message, ex1.Message); }
                    }
                    break;
            }
        }
        public void Update(string task)
        {
            string[] parameters = task.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (parameters.Length == 0)
                return;
            switch (parameters[0])
            {
                case "Stadiums":
                    try
                    {
                        string s_name = parameters[1];
                        int capacity = Convert.ToInt32(parameters[2]);
                        string address = parameters[3];
                        int StadiumID = Convert.ToInt32(parameters[4]);
                        View.ShowRead(model.UpdateStadium(s_name, capacity, address, StadiumID));
                    }
                    catch (Exception ex) { View.ReportError(ex.Message); }
                    break;
                case "Teams":
                    try
                    {
                        string t_name = parameters[1];
                        string trainer = parameters[2];
                        int TeamID = Convert.ToInt32(parameters[3]);
                        View.ShowRead(model.UpdateTeam(t_name, trainer, TeamID));
                    }
                    catch (Exception ex) { View.ReportError(ex.Message); }
                    break;
                case "Matches":
                    try
                    {
                        DateTime start_time = Convert.ToDateTime(parameters[1]);
                        int StadiumID = Convert.ToInt32(parameters[2]);
                        int MatchID = Convert.ToInt32(parameters[3]);
                        View.ShowRead(model.UpdateMatch(start_time, StadiumID, MatchID));
                    }
                    catch (Exception ex) { View.ReportError(ex.Message); }
                    break;
                case "Games":
                    try
                    {
                        int TeamID = Convert.ToInt32(parameters[1]);
                        int MatchID = Convert.ToInt32(parameters[2]);
                        int GameID = Convert.ToInt32(parameters[3]);
                        View.ShowRead(model.UpdateGame(TeamID, MatchID, GameID));
                    }
                    catch (Exception ex) { View.ReportError(ex.Message); }
                    break;
                case "Goals":
                    try
                    {
                        int minute = Convert.ToInt32(parameters[1]);
                        int TeamID = Convert.ToInt32(parameters[2]);
                        int MatchID = Convert.ToInt32(parameters[3]);
                        int GoalID = Convert.ToInt32(parameters[4]);
                        View.ShowRead(model.UpdateGoal(minute, TeamID, MatchID, GoalID));
                    }
                    catch (Exception ex) { View.ReportError(ex.Message); }
                    break;
            }
        }

        public void Delete(string task)
        {
            string[] parameters = task.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (parameters.Length == 0)
                return;
            switch (parameters[0])
            {
                case "Stadiums":
                    try
                    {
                        int StadiumID = Convert.ToInt32(parameters[1]);
                        View.DeleteReport(model.DeleteStadium(StadiumID));
                    }
                    catch (Exception ex)
                    {
                        View.DeleteReport(model.DeleteStadiums());
                    }
                    break;
                case "Teams":
                    try
                    {
                        int TeamID = Convert.ToInt32(parameters[1]);
                        View.DeleteReport(model.DeleteTeam(TeamID));
                    }
                    catch (Exception ex)
                    {
                        View.DeleteReport(model.DeleteTeams());
                    }
                    break;
                case "Matches":
                    try
                    {
                        int MatchID = Convert.ToInt32(parameters[1]);
                        View.DeleteReport(model.DeleteMatch(MatchID));
                    }
                    catch (Exception ex)
                    {
                        View.DeleteReport(model.DeleteMatches());
                    }
                    break;
                case "Games":
                    try
                    {
                        int GameID = Convert.ToInt32(parameters[1]);
                        View.DeleteReport(model.DeleteGame(GameID));
                    }
                    catch (Exception ex)
                    {
                        View.DeleteReport(model.DeleteGames());
                    }
                    break;
                case "Goals":
                    try
                    {
                        int GoalID = Convert.ToInt32(parameters[1]);
                        View.DeleteReport(model.DeleteGoal(GoalID));
                    }
                    catch (Exception ex)
                    {
                        View.DeleteReport(model.DeleteGoals());
                    }
                    break;
            }
        }

        public void Read(string parameter)
        {
            switch (parameter)
            {
                case "Stadiums":
                    View.ShowRead(model.ReadStadiums());
                    break;
                case "Teams":
                    View.ShowRead(model.ReadTeams());
                    break;
                case "Matches":
                    View.ShowRead(model.ReadMatches());
                    break;
                case "Games":
                    View.ShowRead(model.ReadGames());
                    break;
                case "Goals":
                    View.ShowRead(model.ReadGoals());
                    break;
            }
        }
        public void Select(string command)
        {
            int command_int = 0;
            try
            {
                command_int = Convert.ToInt32(command);
                Stopwatch stopWatch = new Stopwatch();
                stopWatch.Start();
                switch (command_int)
                {
                    case 1:
                        string task = Console.ReadLine();
                        string[] parameters = task.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        char s_ch = Convert.ToChar(parameters[0]);
                        char t_ch = Convert.ToChar(parameters[1]);
                        View.ShowRead(model.SelectLIKE(s_ch, t_ch));
                        break;
                    case 2:
                        string task1 = Console.ReadLine();
                        string[] parameters1 = task1.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        int minute = Convert.ToInt32(parameters1[0]);
                        int count_goals= Convert.ToInt32(parameters1[1]);

                        View.ShowRead(model.SelectMatchesUpToMin(minute, count_goals));
                        break;
                    case 3:
                        View.ShowRead(model.SelectTeamWhereMaxGoals());
                        break;
                }
                stopWatch.Stop();
                View.TimerReport(stopWatch.Elapsed);
            }
            catch (Exception ex)
            {
                View.ReportError(ex.Message);
            }
        }
        public void RandomInsert(string task)
        {
            string[] parameters = task.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (parameters.Length == 0)
                return;
            try
            {
                int counter = Convert.ToInt32(parameters[1]);
                switch (parameters[0])
                {
                    case "Stadiums":
                        View.InsertReport(model.RandomInsertStadiums(counter));
                        break;
                    case "Teams":
                        View.InsertReport(model.RandomInsertTeams(counter));
                        break;
                    case "Matches":
                        View.InsertReport(model.RandomInsertMatches(counter));
                        break;
                    case "Games":
                        View.InsertReport(model.RandomInsertGames(counter));
                        break;
                    case "Goals":
                        View.InsertReport(model.RandomInsertGoals(counter));
                        break;
                }
            }
            catch (Exception ex)
            {
                View.ReportError(ex.Message);
            }
        }
    }
}
