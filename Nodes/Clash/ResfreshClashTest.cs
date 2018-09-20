﻿using System.Windows.Controls;
using System.Xml;
using Autodesk.Navisworks.Api;
using TUM.CMS.VplControl.Nodes;
using Autodesk.Navisworks.Api.Clash;
using TUM.CMS.VplControl.Core;
using System.Windows.Data;

using System.Collections.Generic;
using System;
using System.Windows;
using System.Linq;
using System.Threading.Tasks;

namespace ENGyn.Nodes.Clash
{
    public class RefreshClashTests : Node
    {
        public RefreshClashTests(VplControl hostCanvas)
            : base(hostCanvas)
        {
            AddInputPortToNode("Tests", typeof(object));
            AddOutputPortToNode("Clash Tests", typeof(object));

        }

        public override void Calculate()
        {
            var input = InputPorts[0].Data;


           OutputPorts[0].Data = RefreshClashes(input);
           
        }

        private List<object> RefreshClashes(object input)
        {
            //Get clashes from document
            Document doc = Autodesk.Navisworks.Api.Application.ActiveDocument;
            var testData = doc.GetClash().TestsData;
            var output = new List<object>();
            if (input != null)
            {


                if (MainTools.IsList(input))
                {


                    foreach (var item in (System.Collections.IEnumerable)input)
                    {

                        var ClashTest = doc.ResolveReference(item as SavedItemReference) as ClashTest;
                        var clash = doc.Clash as DocumentClash;
                        clash.TestsData.TestsRunTest(ClashTest);
                        output.Add(item);
                    }

                }

                if (input.GetType() == typeof(ClashTest))
                {

                    var ClashTest = doc.ResolveReference(input as SavedItemReference) as ClashTest;
                    testData.TestsRunTest(ClashTest);
                    output.Add(input);
                }

            }
            
            

            return output;
        }



        public override Node Clone()
        {
            return new RefreshClashTests(HostCanvas)
            {
                Top = Top,
                Left = Left
            };

        }
    }

}