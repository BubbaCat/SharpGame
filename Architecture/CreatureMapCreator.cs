using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace Game
{
    public static class CreatureMapCreator
    {
        private static readonly Dictionary<string, Func<ICreature>> factory = new Dictionary<string, Func<ICreature>>();

        public static ICreature[,] CreateMap(string map, string separator = "\r\n")
        {
            var rows = map.Split(new[] { separator }, StringSplitOptions.RemoveEmptyEntries);
            if (rows.Select(z => z.Length).Distinct().Count() != 1)
                throw new Exception($"Wrong test map '{map}'");
            var result = new ICreature[rows[0].Length, rows.Length];
            for (var x = 0; x < rows[0].Length; x++)
                for (var y = 0; y < rows.Length; y++)
                    result[x, y] = CreateCreatureBySymbol(rows[y][x]);
            return result;
        }
        public static ICreature[,] CreateMap(string map, ICreature[,] creatures, string separator = "\r\n")
        {
            var rows = map.Split(new[] { separator }, StringSplitOptions.RemoveEmptyEntries);
            var (playerX, playerY) = GetPositionOfPlayer(creatures);
            if (rows.Select(z => z.Length).Distinct().Count() != 1)
                throw new Exception($"Wrong test map '{map}'");
            var result = new ICreature[rows[0].Length, rows.Length];
            for (var x = 0; x < rows[0].Length; x++)
            for (var y = 0; y < rows.Length; y++)
            {
                if (rows[y][x] == 'P')
                    result[x, y] = creatures[playerX, playerY];
                result[x, y] = CreateCreatureBySymbol(rows[y][x]);
            }
            return result;
        }

        private static (int, int) GetPositionOfPlayer(ICreature[,] creatures)
        {
            for(var i = 0;i<creatures.GetLength(0);i++)
            for (var j = 0; j < creatures.GetLength(1); j++)
                if (creatures[i, j] is Player)
                    return (i, j);
            return (0, 0);
        }

        private static ICreature CreateCreatureByTypeName(string name)
        {
            if (!factory.ContainsKey(name))
            {
                var type = Assembly
                    .GetExecutingAssembly()
                    .GetTypes()
                    .FirstOrDefault(z => z.Name == name);
                if (type == null)
                    throw new Exception($"Can't find type '{name}'");
                factory[name] = () => (ICreature)Activator.CreateInstance(type);
            }

            return factory[name]();
        }


        private static ICreature CreateCreatureBySymbol(char c)
        {
            switch (c)
            {
                case 'P':
                    return CreateCreatureByTypeName("Player");
                case 'T':
                    return CreateCreatureByTypeName("Terrain");
                case 'G':
                    return CreateCreatureByTypeName("Door");
                case 'S':
                    return CreateCreatureByTypeName("Wall");
                case 'M':
                    return CreateCreatureByTypeName("Professor");
                case 'E':
                    return CreateCreatureByTypeName("Exit");
                case 'L':
                    return CreateCreatureByTypeName("Stairs");
                case ' ':
                    return null;
                default:
                    throw new Exception($"wrong character for ICreature {c}");
            }
        }
    }
}