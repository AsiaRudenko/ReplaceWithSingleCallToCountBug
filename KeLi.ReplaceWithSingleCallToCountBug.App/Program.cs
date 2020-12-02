/*
 * MIT License
 *
 * Copyright(c) 2019 KeLi
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 */

/*
             ,---------------------------------------------------,              ,---------,
        ,----------------------------------------------------------,          ,"        ,"|
      ,"                                                         ,"|        ,"        ,"  |
     +----------------------------------------------------------+  |      ,"        ,"    |
     |  .----------------------------------------------------.  |  |     +---------+      |
     |  | C:\>FILE -INFO                                     |  |  |     | -==----'|      |
     |  |                                                    |  |  |     |         |      |
     |  |                                                    |  |  |/----|`---=    |      |
     |  |              Author: KeLi                          |  |  |     |         |      |
     |  |              Email: kelicto@protonmail.com         |  |  |     |         |      |
     |  |              Creation Time: 12/02/2020 04:30:00 PM |  |  |     |         |      |
     |  | C:\>_                                              |  |  |     | -==----'|      |
     |  |                                                    |  |  |   ,/|==== ooo |      ;
     |  |                                                    |  |  |  // |(((( [66]|    ,"
     |  `----------------------------------------------------'  |," .;'| |((((     |  ,"
     +----------------------------------------------------------+  ;;  | |         |,"
        /_)_________________________________________________(_/  //'   | +---------+
           ___________________________/___  `,
          /  oooooooooooooooo  .o.  oooo /,   \,"-----------
         / ==ooooooooooooooo==.o.  ooo= //   ,`\--{)B     ,"
        /_==__==========__==_ooo__ooo=_/'   /___________,"
*/

using System;
using System.Collections.Generic;
using System.Linq;

// ReSharper disable ReplaceWithSingleCallToCount
// ReSharper disable InvokeAsExtensionMethod

namespace KeLi.ReplaceWithSingleCallToCountBug.App
{
    internal class Program
    {
        private static void Main()
        {
            ShowRightCase();
            ShowWrongCase();
        }

        private static void ShowRightCase()
        {
            var fruits = new List<string>()
            {
                "Apple",
                "Banana",
                "Peach",
                "Orange"
            };

            // Raw code.
            Console.WriteLine(fruits.Where(w => w.In("Apple", "Peach")).Count() == 2);

            // Suggets for step 1.
            Console.WriteLine(fruits.Count(w => LinqExtension.In(w, "Apple", "Peach")) == 2);

            // Suggets for step 2.
            Console.WriteLine(fruits.Count(w => w.In("Apple", "Peach")) == 2);
        }

        private static void ShowWrongCase()
        {
            var persons = new[]
            {
                new { Fruit = "Apple", Name = "Jake" },
                new { Fruit = "Peach", Name = "Tony" },
            };

            // Raw code.
            Console.WriteLine(persons.Where(w => w.Name.In("Apple", "Peach")).Count() == 2);

            // Suggets for step 1.
            Console.WriteLine(persons.Count(w => LinqExtension.In("Apple", "Peach")) == 2);

            // Suggets for step 2.
            Console.WriteLine(persons.Count(w => "Apple".In("Peach")) == 2);
        }
    }
}
