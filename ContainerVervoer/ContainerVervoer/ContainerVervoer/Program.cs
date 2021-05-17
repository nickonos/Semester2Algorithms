using System;
using System.Collections.Generic;

namespace ContainerVervoer
{
    class Program
    {
        static void Main(string[] args)
        {
            //uitgaande van gemiddelde gewicht container 17000
            //gemiddelde max hoogte = 1 + 7,058823529411765
            //max gewicht = gem max h * x * y
            List<Container> containers = new List<Container>();

            Ship ship = new Ship(new IntVector2(8, 4), 27105882);
            containers.AddRange(CreateContainers());
            ship.AddContainers(containers);
            ship.Sort();
        }

        static List<Container> CreateContainers()
        {
            List<Container> containers = new List<Container>();

            containers.Add(new Container(ContainerType.Default, 30000));
            containers.Add(new Container(ContainerType.Default, 30000));
            containers.Add(new Container(ContainerType.Default, 30000));
            containers.Add(new Container(ContainerType.Default, 30000));
            containers.Add(new Container(ContainerType.Default, 30000));
            containers.Add(new Container(ContainerType.Default, 30000));
            containers.Add(new Container(ContainerType.Default, 30000));
            containers.Add(new Container(ContainerType.Default, 30000));
            containers.Add(new Container(ContainerType.Default, 30000));
            containers.Add(new Container(ContainerType.Default, 30000));
            containers.Add(new Container(ContainerType.Default, 30000));
            containers.Add(new Container(ContainerType.Default, 30000));
            containers.Add(new Container(ContainerType.Default, 30000));
            containers.Add(new Container(ContainerType.Default, 30000));
            containers.Add(new Container(ContainerType.Default, 30000));
            containers.Add(new Container(ContainerType.Default, 30000));
            containers.Add(new Container(ContainerType.Default, 30000));
            containers.Add(new Container(ContainerType.Default, 30000));
            containers.Add(new Container(ContainerType.Default, 30000));
            containers.Add(new Container(ContainerType.Default, 30000));
            containers.Add(new Container(ContainerType.Default, 30000));
            containers.Add(new Container(ContainerType.Default, 30000));
            containers.Add(new Container(ContainerType.Default, 30000));
            containers.Add(new Container(ContainerType.Default, 30000));
            containers.Add(new Container(ContainerType.Default, 30000));
            containers.Add(new Container(ContainerType.Default, 30000));
            containers.Add(new Container(ContainerType.Default, 30000));
            containers.Add(new Container(ContainerType.Default, 30000));
            containers.Add(new Container(ContainerType.Default, 30000));
            containers.Add(new Container(ContainerType.Default, 30000));
            containers.Add(new Container(ContainerType.Default, 30000));
            containers.Add(new Container(ContainerType.Default, 30000));
            containers.Add(new Container(ContainerType.Default, 30000));
            containers.Add(new Container(ContainerType.Default, 30000));
            containers.Add(new Container(ContainerType.Default, 30000));
            containers.Add(new Container(ContainerType.Default, 30000));
            containers.Add(new Container(ContainerType.Default, 30000));
            containers.Add(new Container(ContainerType.Default, 30000));
            containers.Add(new Container(ContainerType.Default, 30000));
            containers.Add(new Container(ContainerType.Default, 30000));
            containers.Add(new Container(ContainerType.Default, 30000));
            containers.Add(new Container(ContainerType.Default, 30000));
            containers.Add(new Container(ContainerType.Default, 30000));
            containers.Add(new Container(ContainerType.Default, 30000));
            containers.Add(new Container(ContainerType.Default, 30000));
            containers.Add(new Container(ContainerType.Default, 30000));

            return containers;
        }
    }
}
