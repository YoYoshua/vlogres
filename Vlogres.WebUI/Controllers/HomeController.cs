using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vlogres.WebUI.Models;

namespace Vlogres.WebUI.Controllers
{
    public class HomeController : Controller
    {

        // GET: Home
        public ActionResult Index()
        {
            //Prepare a path for file
            string path = Server.MapPath("Content/Textfiles/testlist.txt");

            //Get list from text file
            List<ListElement> testList = ParseTextfile(path);
            return View(testList);
        }

        private List<ListElement> ParseTextfile(string filepath)
        {
            if(filepath != null)
            {
                try
                {
                    //Get all lines from file
                    string[] lines = System.IO.File.ReadAllLines(filepath, System.Text.Encoding.GetEncoding("Windows-1250"));

                    //Prepare result list
                    List<ListElement> result = new List<ListElement>();

                    foreach (string line in lines)
                    {
                        ListElement temp = new ListElement();
                        string[] split = line.Split('|');

                        if (split.Length == 2)
                        {
                            temp.Author = split[0];
                            temp.Title = split[1];
                            result.Add(temp);
                        }
                        else continue;
                    }

                    //Return parsed list
                    return result;
                }
                catch(IOException e)
                {
                    Console.WriteLine(e.Message);
                    return new List<ListElement>();
                }
            }
            else
            {
                return new List<ListElement>();
            }
        }
    }
}