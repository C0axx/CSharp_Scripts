using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.DirectoryServices;

namespace addNewUser
{

    class Program
    {
        static void Main()
        {


            try
            {
                DirectoryEntry AD = new DirectoryEntry("WinNT://" +
                                    Environment.MachineName + ",computer");
                DirectoryEntry NewUser = AD.Children.Add("testuser", "user");
                NewUser.Invoke("SetPassword", new object[] { "P@ssword1234!" });
                NewUser.CommitChanges();

                DirectoryEntry grp;
                grp = AD.Children.Find("Administrators", "group");
                if (grp != null) { grp.Invoke("Add", new object[] { NewUser.Path.ToString() }); }
                //Console.WriteLine("Account Created Successfully");
                //Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();

            }

        }
    }
}



