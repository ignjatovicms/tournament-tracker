using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerLibrary.DataAccess;

namespace TrackerLibrary 
{
    public static class GlobalConfig
    {
        public const string PrizesFile = "PrizeModels.csv";
        public const string PeopleFile = "PersonModels.csv";
        public const string TeamFile = "TeamModels.csv";
        public const string TournamentFile = "TournamentModels.csv";
        public const string MatchupFile = "MatchupModels.csv";
        public const string MatchupEntryFile = "MatchupEntryModels.csv";
        public static readonly string CnnString = ConfigurationManager.ConnectionStrings["Tournaments"].ConnectionString;

        public static IDataConnection Connection { get; private set; }/// <summary>
                                                                      /// /
                                                                      /// </summary>
                                                                      /// <param name="db"></param>

        public static void InitializeConnections(DatabaseType db)
        {
            if (db == DatabaseType.Sql)
            {
                SqlConnector sql = new SqlConnector();
                Connection = sql;
            }
            else if (db == DatabaseType.TextFile)
            {
                TextConnector text = new TextConnector();
                Connection = text;
            }
        }

      

        public static string AppKeyLookup(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }

        /*switch(db)
        {
            case DatabaseType.Sql:
                SqlConnector sql = new SqlConnector();
                Connection = sql;
                break;
                case DatabaseType.TextFile:
                TextConnector text = new TextConnector();
                Connection = text;
                break;
                default break;
        }
        */
    }
}
