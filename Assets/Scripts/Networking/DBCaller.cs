using Infissy.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
   public class DBCaller
    {
        public static int Login(string usern,string passw)
        {
            var form = new WWWForm();
            form.AddField("usern", usern);
            form.AddField("passw", passw);
            var www = new WWW("http://www.bargiua.it/Infissy/Calls/login.aspx", form);
            var page = www.text;
            return int.Parse(page.Split('#')[1].Split(';')[0]);
        }
        public List<Card> GCFM(int idMazzo)
        {

            var form = new WWWForm();
            form.AddField("idMazzo", idMazzo);           
            var www = new WWW("http://www.bargiua.it/Infissy/Calls/gcfm.aspx", form);
            var page = www.text;
            var mazzo = new List<Card>();
            var mazzoStringL=page.Split('#')[1].Split(Environment.NewLine.ToCharArray());
            foreach (var carta in mazzoStringL)
            {
                
            }
            return null;

        }
    }
}
