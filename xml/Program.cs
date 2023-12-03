using System.Reflection.Metadata;
using System.Xml;
using System.Xml.Linq;

namespace xml
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();
            Car mazda = new Car("Mazda", 100, "KA2034CA");
            Car bmw = new Car("BMW", 300, "CA2030LA");
            Car vw = new Car("VW", 220, "OA2184UA");
            Car lexus = new Car("Lexus", 400, "HA3994TA");
            Car daewoo = new Car("Daewoo", 100, "TA4392AA");
            cars.Add(mazda);
            cars.Add(bmw);
            cars.Add(vw);
            cars.Add(lexus);
            cars.Add(daewoo);

            SaveCollectionInXmlFile(cars);
            SetNewCarPriceByNumber("TA4392AA", 75);
            void SaveCollectionInXmlFile(IEnumerable<Car> cars)
            {
                if(cars != null || cars.Any())
                {
                    XDocument document = new XDocument(
                    new XElement("cars",
                    from car in cars
                    select new XElement("car",
                    new XAttribute("name", car.Name),
                    new XElement("price", car.Price),
                    new XElement("number", car.Number)
                   )));
                    try
                    {
                        document.Save("path");
                    }
                    catch(Exception e)
                    {
                        Console.WriteLine(e);
                    }
                }
            }

            void SetNewCarPriceByNumber(string carNumber, int newPrice)
            {
                if(carNumber == null || carNumber.Length==0)
                {
                    return;
                }
                XDocument doc = XDocument.Load("path");
                XElement root = doc.Root;
                XElement car = root.Descendants("car")
                    .FirstOrDefault(x => x.Element("number")
                    .Value == carNumber);

                if (car == null)
                {
                    Console.WriteLine("Car not found");
                    return;
                }

                car.SetElementValue("price", newPrice);
                try
                {
                    doc.Save("path");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }
    }
}