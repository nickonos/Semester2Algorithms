﻿using System;
using System.Collections.Generic;

namespace ContainerVervoer
{
    class Program
    {
        static void Main(string[] args)
        {
          
            List<Container> containers = new List<Container>();

            Ship ship = new Ship(new IntVector2(4, 4), 27105882);
            containers.AddRange(CreateContainers());
            ship.AddContainers(containers);
            ship.Sort();


            Console.WriteLine(GenerateOutputString(ship.GetContainerRows()));
        }

        static string GenerateOutputString(List<ContainerRow> containerRows)
        {
            //PrintValues(containerRows);

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

        static void PrintValues(List<ContainerRow> rows)
        {
            foreach(ContainerRow row in rows)
            {
                IReadOnlyList<ContainerStack> stacks = row.GetContainerStacks();
                foreach(ContainerStack stack in stacks)
                {
                    Console.Write($"{stack.CalculateWeightOnTop()} ");
                }
                Console.WriteLine();
            }
        }

        static List<Container> CreateContainers()
        {
            List<Container> containers = new List<Container>();
            Random rand = new Random();

            for(int i = 0; i< 100; i++)
            {
                int random = rand.Next(1, 15);
                ContainerType container = (ContainerType)random;
                if (random > 4)
                    container = ContainerType.Default;
                containers.Add(new Container( container, rand.Next(4, 30) * 1000));
            }
            return containers;
        }
    }
}
