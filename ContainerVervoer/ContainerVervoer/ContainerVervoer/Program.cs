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

            Console.WriteLine(GenerateOutputString(ship.GetContainerRows()));
        }

        static string GenerateOutputString(List<ContainerRow> containerRows)
        {
            //length=1 & width=1 & stacks="" & weight="" 

            //seperate containers 1-1-1-1
            //seperate stack 1-1,1-1
            //seperate row 1,1/1,1

            string output = "";
            output += $"https://i872272core.venus.fhict.nl/ContainerVisualizer/index.html?length={containerRows.Count}&width={containerRows[0].GetContainerStacks().Count}&stacks=";

            string weight = "";
            int l = 0;
            for(int i =0; i< containerRows[0].GetContainerStacks().Count; i++)
            {
                int k = 0;
                foreach(ContainerRow containerRow in containerRows)
                {
                    IReadOnlyList<ContainerStack> stacks = containerRow.GetContainerStacks();
                    int j = 0;
                    if(stacks.Count <= i || stacks[i].GetContainers() == null)
                    {
                        output += ",";
                        weight += ",";
                        continue;
                    } 
                    foreach(Container container in stacks[i].GetContainers())
                    {
                        output += (int)container.Type;
                        weight += container.Weight / 1000;
                        j++;
                        if (j != stacks[i].GetContainers().Count)
                        {
                            output += "-";
                            weight += "-";
                        }
                    }
                    k++;
                    if (k != containerRows.Count)
                    {
                        output += ",";
                        weight += ",";
                    }
                }
                l++;
                if (l != containerRows[0].GetContainerStacks().Count)
                {
                    output += "/";
                    weight += "/";
                }
            }

            output += $"&weights={weight}";

            return output;
        }

        static List<Container> CreateContainers()
        {
            List<Container> containers = new List<Container>();
            Random rand = new Random();

            for(int i = 0; i< 40; i++)
            {
                containers.Add(new Container((ContainerType)rand.Next(1,4) , rand.Next(4, 30) * 1000));
            }
            //containers.Add(new Container(ContainerType.Default, 30000));
            //containers.Add(new Container(ContainerType.Default, 30000));
            //containers.Add(new Container(ContainerType.Default, 30000));
            //containers.Add(new Container(ContainerType.Default, 30000));
            //containers.Add(new Container(ContainerType.Default, 30000));
            //containers.Add(new Container(ContainerType.Default, 30000));
            //containers.Add(new Container(ContainerType.Default, 30000));
            //containers.Add(new Container(ContainerType.Default, 30000));
            //containers.Add(new Container(ContainerType.Default, 30000));
            //containers.Add(new Container(ContainerType.Default, 30000));
            //containers.Add(new Container(ContainerType.Default, 30000));
            //containers.Add(new Container(ContainerType.Default, 30000));
            //containers.Add(new Container(ContainerType.Default, 30000));
            //containers.Add(new Container(ContainerType.Default, 30000));
            //containers.Add(new Container(ContainerType.Default, 30000));
            //containers.Add(new Container(ContainerType.Default, 30000));
            //containers.Add(new Container(ContainerType.Default, 30000));
            //containers.Add(new Container(ContainerType.Default, 30000));
            //containers.Add(new Container(ContainerType.Default, 30000));
            //containers.Add(new Container(ContainerType.Default, 30000));
            //containers.Add(new Container(ContainerType.Default, 30000));
            //containers.Add(new Container(ContainerType.Default, 30000));
            //containers.Add(new Container(ContainerType.Default, 30000));
            //containers.Add(new Container(ContainerType.Default, 30000));
            //containers.Add(new Container(ContainerType.Default, 30000));
            //containers.Add(new Container(ContainerType.Default, 30000));
            //containers.Add(new Container(ContainerType.Default, 30000));
            //containers.Add(new Container(ContainerType.Default, 30000));
            //containers.Add(new Container(ContainerType.Default, 30000));
            //containers.Add(new Container(ContainerType.Default, 30000));
            //containers.Add(new Container(ContainerType.Default, 30000));
            //containers.Add(new Container(ContainerType.Default, 30000));
            //containers.Add(new Container(ContainerType.Default, 30000));
            //containers.Add(new Container(ContainerType.Default, 30000));
            //containers.Add(new Container(ContainerType.Default, 30000));
            //containers.Add(new Container(ContainerType.Default, 30000));
            //containers.Add(new Container(ContainerType.Default, 30000));
            //containers.Add(new Container(ContainerType.Default, 30000));
            //containers.Add(new Container(ContainerType.Default, 30000));
            //containers.Add(new Container(ContainerType.Default, 30000));
            //containers.Add(new Container(ContainerType.Default, 30000));
            //containers.Add(new Container(ContainerType.Default, 30000));
            //containers.Add(new Container(ContainerType.Default, 30000));
            //containers.Add(new Container(ContainerType.Default, 30000));
            //containers.Add(new Container(ContainerType.Default, 30000));
            //containers.Add(new Container(ContainerType.Default, 30000));

            return containers;
        }
    }
}
