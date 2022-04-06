// Author: Amir Aslamov
// Description of Program: This program is created to serve as a web-scraper and srape data from all the web-pages associated
//                         with the official web-site of College of Education at University of South Florida. This program is
//                         written as part of the volunteer program under the supervision of Dr. Reginald Lucien from the Judy
//                         Genshaft Honors College at University of South Florida
// Date: 03/27/2022



using System;
using System.IO;
using System.Collections.Generic;

namespace Scraper
{
    class Program
    {
        static void Main(string[] args)
        {
            // all the web pages are hardcoded and saved into a list

            // this list below will contain all the web-pages from section "About"
            List<String> urls_About = new List<string>()
            {
                "https://www.usf.edu/education/about-us/index.aspx",
                "https://www.usf.edu/education/about-us/advising.aspx",
                "https://www.usf.edu/education/about-us/accreditation.aspx",
                "https://www.usf.edu/education/about-us/all-degree-programs.aspx",
                "https://www.usf.edu/education/blog/",
                "https://www.usf.edu/education/about-us/contact-us.aspx",
                "https://www.usf.edu/education/about-us/community-engagement.aspx",
                "https://www.usf.edu/education/about-us/departments.aspx",
                "https://www.usf.edu/education/about-us/locations.aspx",
                "https://www.usf.edu/education/about-us/mission-vision.aspx",
                "https://www.usf.edu/education/about-us/office-of-the-dean.aspx",
                "https://www.usf.edu/education/about-us/special-interest-programs.aspx",
                "https://www.usf.edu/education/about-us/summer-programs.aspx"
            };

            // this list below will contain all the web-pages from section "Undergraduate Programs"
            List<String> urls_UndergraduatePrograms = new List<String>()
            {
                "https://www.usf.edu/education/undergraduate/index.aspx",
                "https://www.usf.edu/education/undergraduate/minors.aspx",
                "https://www.usf.edu/education/undergraduate/academic-advising/index.aspx",
                "https://www.usf.edu/education/academics/campusfolio.aspx",
                "https://www.usf.edu/education/field-and-clinical-education/index.aspx",
                "https://www.usf.edu/education/undergraduate/scholarships-grants.aspx",
                "https://www.usf.edu/education/undergraduate/undergraduate-student-organizations.aspx",
                "https://www.usf.edu/education/undergraduate/study-abroad.aspx",
                "https://www.usf.edu/education/resources-for-educators/teacher-certification/about-ftce.aspx",
                "https://www.usf.edu/education/undergraduate/academic-advising/coedu-applications.aspx"
            };

            // this list below will contain all the web-pages from section "Graduate Studies"
            List<String> urls_GraduateStudies = new List<String>()
            {
                "https://www.usf.edu/education/graduate/index.aspx",
                "https://www.usf.edu/education/graduate/online-programs.aspx",
                "https://www.usf.edu/education/graduate/graduate-certificates.aspx",
                "https://www.usf.edu/education/graduate/graduate-endorsements.aspx",
                "https://www.usf.edu/education/graduate/information-sessions.aspx",
                "https://www.usf.edu/education/graduate/graduate-support-office/welcome-from-associate-dean.aspx",
                "https://www.usf.edu/education/graduate/scholarships-grants.aspx",
                "https://www.usf.edu/education/undergraduate/study-abroad.aspx",
                "https://www.usf.edu/education/resources-for-educators/teacher-certification/about-ftce.aspx",
                "https://www.usf.edu/education/academics/campusfolio.aspx",
                "https://www.usf.edu/education/field-and-clinical-education/index.aspx"
            };

            // this list below will contain all the web-pages from section "Faculty and Staff"
            List<String> urls_FacultyAndStaff = new List<String>()
            {
                "https://www.usf.edu/education/faculty/index.aspx",
                "https://www.usf.edu/education/faculty/faculty-areas-of-expertise.aspx",
                "https://www.usf.edu/education/faculty/faculty-profiles/faculty-profiles.aspx",
                "https://www.usf.edu/education/blog/listing.aspx?tag=Faculty%20and%20Staff%20Notes",
                "https://www.usf.edu/education/administrative-resources/index.aspx"
            };

            // this list below will contain all the web-pages from section "Research"
            List<String> urls_Research = new List<String>()
            {
                "https://www.usf.edu/education/research/index.aspx",
                "https://www.usf.edu/education/research/research-centers-institutes.aspx",
                "https://www.usf.edu/education/research/research-activities.aspx",
                "https://www.usf.edu/education/blog/listing.aspx?category=Research"
            };

            // this list below will contain all the web-pages from section "Alummi and Giving"
            List<String> urls_AlumniAndGiving = new List<String>()
            {
                "https://www.usf.edu/education/alumni-friends/index.aspx",
                "https://www.usf.edu/education/blog/listing.aspx?category=Alumni%20and%20Friends",
                "https://www.usf.edu/education/blog/listing.aspx?tag=Alumni%20Spotlight",
                "https://www.usf.edu/education/alumni-friends/giving.aspx",
                "https://www.usf.edu/education/alumni-friends/alumni-association.aspx"
            };


            // Let's determine what section or sections the user wants to scrape
            // let's store all the options in a string
            string options_display = "\n\n1. All\n2. About\n3. Undergraduate Programs\n4. Graduate Studies\n5. Faculty and Staff\n6. Research\n7. Alumni and Giving\n\n8. EXIT\n";

            Console.WriteLine("\nWelcome to Web-Scrape program to fetch data from the web-pages of College of Education at University of South Florida.\n");

            bool progress = true;
            int user_selection = -1;
            while (progress)
            {
                Console.WriteLine(options_display);
                Console.Write("Please, select one of the numbers below to proceed: ");
                try
                {
                    user_selection = int.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("\nError! Invalid Entry! Try again.");
                    continue;
                }
                if (user_selection == 8)
                {
                    progress = false;
                }

                // now we check the user selection and scrape accordingly
                switch (user_selection)
                {
                    // in case 1, we write urls of all sections
                    case 1:
                        WriteUrls(urls_About, "About");
                        WriteUrls(urls_UndergraduatePrograms, "Undergraduate Programs");
                        WriteUrls(urls_GraduateStudies, "Graduate Studies");
                        WriteUrls(urls_FacultyAndStaff, "Faculty and Staff");
                        WriteUrls(urls_Research, "Research");
                        WriteUrls(urls_AlumniAndGiving, "Alumni and Giving");
                        break;
                    case 2:
                        WriteUrls(urls_About, "About");
                        break;
                    case 3:
                        WriteUrls(urls_UndergraduatePrograms, "Undergraduate Programs");
                        break;
                    case 4:
                        WriteUrls(urls_GraduateStudies, "Graduate Studies");
                        break;
                    case 5:
                        WriteUrls(urls_FacultyAndStaff, "Faculty and Staff");
                        break;
                    case 6:
                        WriteUrls(urls_Research, "Research");
                        break;
                    case 7:
                        WriteUrls(urls_AlumniAndGiving, "Alumni and Giving");
                        break;
                    case 8:
                        // the progress set to false to break the loop
                        progress = false;
                        break;
                    default:
                        Console.WriteLine("\nError! Invalid input! Try again.");
                        break;
                }
            }
        }


        // a helper function to scrape data from a list of urls and write the data into new files
        static public void WriteUrls(List<String> input, string section)
        {
            Console.WriteLine("\n" + input.Count + " sub sections in section: " + section);

            // scraper object
            ScrapingLogic scraper = new ScrapingLogic();
            // a list object to hold the returned data from the scraper parse
            List<String> output = new List<String>();

            int count = 1;
            int copy = 1;
            // let's loop throught the input list, get the scraped data, and write a new file with the data
            for (int i = 0; i < input.Count; i++)
            {
                // store the data into the list
                output = scraper.getInfo(input[i]);

                // a new file is created
                try
                {
                    if (File.Exists($"/Users/amiraslamov/Desktop/ScraperApp/Results/{section}/{FilterSection(input[i])}.txt"))
                    {
                        File.WriteAllLines($"/Users/amiraslamov/Desktop/ScraperApp/Results/{section}/{FilterSection(input[i]) + copy}.txt", output);
                        copy++;
                    }
                    else
                    {
                        File.WriteAllLines($"/Users/amiraslamov/Desktop/ScraperApp/Results/{section}/{FilterSection(input[i])}.txt", output);
                    }
                    count++;
                }
                catch
                {
                    Console.WriteLine("Error! Unexpected error occured in scraping and writing data to a file.");
                }
            }

            Console.WriteLine($"\nSuccess! Data scraped and written to the files inside the folder \"{section}\" successfully.");
        }


        // a helper function to filter section names from urls
        static public string FilterSection(string url)
        {
            string filtered = "";

            // there are a total of 5 "/" in each url
            int count = 0;
            bool attach = false;
            foreach (char ch in url)
            {
                if (attach)
                {
                    if (count == 5)
                    {
                        filtered += Char.ToUpper(ch);
                        count++;
                    }
                    else
                    {
                        filtered += ch;
                        continue;
                    }
                }
                if (ch == '/')
                {
                    count++;
                    if (count == 5)
                    {
                        attach = true;
                    }
                }
            }
            count = 0;
            foreach(char ch in filtered)
            {
                if (ch == '.' || ch == '/')
                {
                    filtered = filtered.Substring(0, count);
                    break;
                }
                count++;
            }

            if (filtered == "")
            {
                return "Blog";
            } else
            {
                return filtered;
            }
        }
    }
}
