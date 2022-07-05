﻿using Grasshopper.Kernel;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jSwan
{
    public static class Utilities
    {

        public static void LockAllJswanComponents(GH_Document doc, LockableJSwanComponent.ComponentType Type)
        {
            doc.Objects.OfType<LockableJSwanComponent>().Where(c => c.Type == Type).ToList().ForEach(c =>
            {
                c.StructureLocked = true;
                c.UpdateMessage();
            });
        }

        

        public static object ToSimpleValue(this JToken token)
        {
            switch(token.Type)
            {
                case JTokenType.Integer:
                    return token.Value<int>();
                case JTokenType.String:
                    return token.Value<string>();
                case JTokenType.TimeSpan:
                    return token.Value<TimeSpan>();
                case JTokenType.Boolean:
                    return token.Value<bool>();
                case JTokenType.Date:
                    return token.Value<DateTime>();
                case JTokenType.Float:
                    return token.Value<double>();
                default:
                    return new JTokenGoo(token);
            }
        }
    }
}
