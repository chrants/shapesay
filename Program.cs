using System;
using System.Collections.Generic;
using System.Linq;

namespace shapesay
{
    class Program
    {
        static void Main(string[] args)
        {

            string[] names = {
                "Burke", "Connor", "Frank", "Everett",
                "Albert", "George", "Harris", "David", "Thanh",
                "Christian", "Cat", "Dog", "Joe"
            };

            var salaries = new[] { new { Name = "Burke", Pay = 8000 }, new { Name = "Frank", Pay = 500 },
                                   new { Name = "Thanh", Pay = 4400 }, new { Name = "Christian", Pay = 10000 } };

            var output = String.Join("\n",
                    (from salaryGroup in
                        (from salary in
                            (from name in names
                             orderby name
                             join salary in salaries
                             on name equals salary.Name
                             select salary
                            )
                         group salary by salary.Pay switch
                         {
                             int pay when (pay < 5000) => "Dirt Poor",
                             int pay when (5000 <= pay && pay <= 8000) => "Middle Class",
                             _ => "Filthy Rich"
                         } into salaryGroups
                         orderby salaryGroups.Key switch { "Dirt Poor" => 0, "Middle Class" => 1, "Filthy Rich" => 2, _ => -1 }
                         select new { salaryGroups.Key, Group = String.Join(", ", salaryGroups) }
                    )
                     select String.Join("\n", $"{salaryGroup.Key}:\t {salaryGroup.Group}"))
                );

            string[] fakeArgs = { output, "-Rect", "-Rect", "-Rect" };
            ShapeSay.Say(fakeArgs);
        }
    }
}
