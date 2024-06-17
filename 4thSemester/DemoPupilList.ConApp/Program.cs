#nullable disable
namespace DemoPupilList.ConApp
{
    class Program
    {
        static void Main(string[] args)
        {
            DemoPupilList pupilList = new();
            pupilList.Append(new() { FirstName = "Maxi", LastName = "Muster" });
            pupilList.Append(new() { FirstName = "Tobias", LastName = "Huber" });
            pupilList.Append(new() { FirstName = "Mario", LastName = "Neubauer" });

//            Console.WriteLine(pupilList);

            for (int i = 0; i < pupilList.Count; i++)
            {
                Console.WriteLine(pupilList[i]);
            }

            Console.WriteLine("press any key to exit...");
            Console.ReadKey();
        }
    }
}