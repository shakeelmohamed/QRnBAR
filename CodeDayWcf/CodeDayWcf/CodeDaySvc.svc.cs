using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Security.Cryptography;
using System.ServiceModel.Activation;

namespace CodeDayWcf
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class CodeDaySvc : ICodeDaySvc
    {
        List<ScoreboardItem> ICodeDaySvc.GetScoreboard()
        {
            // Get all scores as a list
            return GetScoreboard();
        }

        bool ICodeDaySvc.Scan(string imei, string code, string points)
        {
            bool isSuccessful = true;
            try
            {
                using (codeDayEntities context = new codeDayEntities())
                {
                    //Make sure the user already exists
                    if (context.CD_Users.Where(u => u.IMEI == imei).Count() > 0)
                    {
                        if (context.CD_Codes.Where(c => c.Code == code).Count() == 0)
                        {
                            context.CD_Codes.AddObject(new CD_Codes { CodeID = Guid.NewGuid(), Code = code, Points = Int32.Parse(points), IMEI = imei, ScanTime = DateTime.Now });
                            context.SaveChanges();
                        }
                        else { isSuccessful = false; }
                    }
                    else { isSuccessful = false; }
                }
            }
            catch { isSuccessful = false; }

            return isSuccessful;
        }

        bool ICodeDaySvc.SetupPlayer(string imei, string nickname)
        {
            bool isSuccessful = true;
            try
            {
                using (codeDayEntities context = new codeDayEntities())
                {
                    if (context.CD_Users.Where(u => u.IMEI == imei).Count() == 0)
                    {
                        context.CD_Users.AddObject(new CD_Users { IMEI = imei, Nickname = nickname });
                    }
                    else
                    {
                        CD_Users user = context.CD_Users.Where(u => u.IMEI == imei).FirstOrDefault();
                        user.Nickname = nickname;
                    }
                    context.SaveChanges();
                }
            }
            catch { isSuccessful = false; }

            return isSuccessful;
        }

        string ICodeDaySvc.GetPlayer(string imei)
        {
            string user = String.Empty;
            try
            {
                using (codeDayEntities context = new codeDayEntities())
                {
                    if (context.CD_Users.Where(u => u.IMEI == imei).Count() > 0)
                    {
                        user = context.CD_Users.Where(u => u.IMEI == imei).Select(u => u.Nickname).FirstOrDefault();
                    }
                }
            }
            catch { }

            return user;
        }

        bool ICodeDaySvc.DeletePlayer(string imei, string deleteCodesFlag)
        {
            bool isSuccessful = true;
            try
            {
                using (codeDayEntities context = new codeDayEntities())
                {
                    // Delete all users matching the IMEI
                    IList<CD_Users> users = new List<CD_Users>();
                    users = context.CD_Users.Where(u => u.IMEI == imei).ToList();
                    foreach (CD_Users user in users)
                    {
                        context.DeleteObject(user);
                    }

                    // Depending on the flag
                    bool isDeleteCodes = Convert.ToBoolean(deleteCodesFlag);
                    if (isDeleteCodes)
                    {
                        IList<CD_Codes> codes = new List<CD_Codes>();
                        codes = context.CD_Codes.Where(c => c.IMEI == imei).ToList();
                        foreach (CD_Codes code in codes)
                        {
                            context.DeleteObject(code);
                        }
                    }

                    // Save database all changes
                    context.SaveChanges();
                }
            }
            catch { isSuccessful = false; }

            return isSuccessful;
        }

        // Private Methods
        private static string MD5Hash(string input)
        {
            // Create a new instance of the MD5CryptoServiceProvider object.
            MD5 md5Hasher = MD5.Create();

            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }
        private static List<ScoreboardItem> GetScoreboard()
        {
            // Get all scores as a list
            List<ScoreboardItem> scores = new List<ScoreboardItem>();
            using (codeDayEntities context = new codeDayEntities())
            {
                scores = context.vw_Scoreboard.OrderByDescending(s => s.TotalScore).ThenBy(s => s.TotalScans).ThenByDescending(s => s.LastScanTime).Select(s => new ScoreboardItem()
                {
                    ID = s.IMEI,
                    Position = 0,
                    Nickname = s.Nickname,
                    Score = s.TotalScore ?? 0,
                    Scans = s.TotalScans ?? 0,
                    LastUpdated = s.LastScanTime ?? DateTime.Now
                }).ToList();
            }

            // Loop through each item and set the Position number and hash the IMEIs
            for (int i = 0; i < scores.Count; i++)
            {
                scores[i].Position = i + 1;
                scores[i].ID = MD5Hash(scores[i].ID);
            }

            return scores;
        }
    }
}
