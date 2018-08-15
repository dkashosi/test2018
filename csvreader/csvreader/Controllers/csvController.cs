using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using csvreader.Models;
using System.IO;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace csvreader.Controllers
{
    public class csvController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Welcome(string name, int numTimes)
        {

            List<csv> myList = readData();


            return View(myList);
        }

        private List<csv> readData()
        {
            List<csv> myList = new List<csv>();
            string path = @"C:\Users\danie\source\repos\csvreader\data.csv";
            if (!System.IO.File.Exists(path))
            {
                csv temp = new csv();
                temp.AccountNumber = "Null";
                myList.Add(temp);
                return myList;
                
            }
            else
            {
                using (StreamReader sr = System.IO.File.OpenText(path))
                {
                    string s = "";
                    while ((s = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(s);
                        csv temp = parseLine(s);
                        myList.Add(temp);
                        
                    }
                }
                return myList;
            }
        }
        private csv parseLine(string s)
        {
            csv Account = new csv();
            int nextIndex = 0;
            nextIndex = s.IndexOf(',');

            Account.AccountNumber = s.Substring(0, nextIndex );
            s = s.Substring(nextIndex+1);
            nextIndex = s.IndexOf(',');
            Account.LastName = s.Substring(0, nextIndex);
            s = s.Substring(nextIndex + 1);
            nextIndex = s.IndexOf(',');
            Account.FirstName = s.Substring(0, nextIndex);
            s = s.Substring(nextIndex + 1);
            nextIndex = s.IndexOf(',');
            Account.MiddleName = s.Substring(0, nextIndex);
            s = s.Substring(nextIndex + 1);
            nextIndex = s.IndexOf(',');

            //get the adress city and state
            Account.Address = s.Substring(0, nextIndex);
            s = s.Substring(nextIndex + 1);
            nextIndex = s.IndexOf(',');
            Account.Address += s.Substring(0, nextIndex);
            s = s.Substring(nextIndex + 1);
            nextIndex = s.IndexOf(',');
            Account.Address += s.Substring(0, nextIndex);
            s = s.Substring(nextIndex + 1);
            nextIndex = s.IndexOf(',');
            Account.Address += s.Substring(0, nextIndex);
            s = s.Substring(nextIndex + 1);
            nextIndex = s.IndexOf(',');
            Account.Address += s.Substring(0, nextIndex);
            s = s.Substring(nextIndex + 1);
            nextIndex = s.IndexOf(',');


            Account.PhoneNumber = s.Substring(0, nextIndex);
            s = s.Substring(nextIndex + 1);
            nextIndex = s.IndexOf(',');
            Account.SPhoneNumber = s.Substring(0, nextIndex);
            s = s.Substring(nextIndex + 1);
            nextIndex = s.IndexOf(',');
            Account.OpendedDate = s.Substring(0, nextIndex);
            s = s.Substring(nextIndex + 1);
            nextIndex = s.IndexOf(',');
            Account.Balance = s.Substring(0, nextIndex);
            s = s.Substring(nextIndex + 1);
            Account.Type = s;

            return Account;
        }

    }
}
