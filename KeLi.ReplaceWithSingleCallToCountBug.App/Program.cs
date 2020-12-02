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
            //var fruits = new List<string>()
            //{
            //    "Apple",
            //    "Banana",
            //    "Peach",
            //    "Orange"
            //};

            // Raw code.
            //return fruits.Where(w => w.In("Apple", "Peach")).Count() == 2;

            // Sugget step 1.
            //return fruits.Count(w => LinqToObjectExtension.In(w, "Apple", "Peach")) == 2;

            // Sugget step 2.
            //return fruits.Count(w => w.In("Apple", "Peach")) == 2;
        }

        private static void ShowWrongCase()
        {
            //var persons = new[]
            //{
            //    new { Fruit = "Apple", Name = "Jake" },
            //    new { Fruit = "Peach", Name = "Tony" },
            //};

            //Raw code.
            //return persons.Where(w => w.Name.In("Apple", "Peach")).Count() == 2;

            //Sugget step 1.
            //return persons.Count(w => LinqToObjectExtension.In("Apple", "Peach")) == 2;

            //Sugget step 2.
            //return persons.Count(w => "Apple".In("Peach")) == 2;
        }
    }
}
