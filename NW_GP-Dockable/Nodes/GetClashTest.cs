﻿using System.Windows.Controls;
using System.Xml;
using Autodesk.Navisworks.Api;
using TUM.CMS.VplControl.Nodes;
using Autodesk.Navisworks.Api.Clash;
using TUM.CMS.VplControl.Core;
using System.Windows.Data;

using System.Collections.Generic;
using System;

namespace NW_GraphicPrograming.Nodes
{
    public class NW_ClashTest : Node
    {
        public NW_ClashTest(VplControl hostCanvas)
            : base(hostCanvas)
        {
            AddInputPortToNode("NW Document", typeof(Document));
            AddOutputPortToNode("Navis Clash Tests", typeof(List<Object>));

            AddControlToNode(new Label { Content = "NW Clash Tests" });

        }

        public override void Calculate()
        {

            Document doc = InputPorts[0].Data as Document;
            var testData = doc.GetClash().TestsData;

            if (testData != null && testData.Tests.Count > 0)
            {
                List<Object> clashTestList = new List<Object>();
                foreach (var t in testData.Tests)
                {
               
                    clashTestList.Add(t as Object);
                }

                OutputPorts[0].Data = clashTestList;
            }
            else
            { OutputPorts[0].Data = 0; }
 
        }


        public override void SerializeNetwork(XmlWriter xmlWriter)
        {
            base.SerializeNetwork(xmlWriter);

            // add your xml serialization methods here
        }

        public override void DeserializeNetwork(XmlReader xmlReader)
        {
            base.DeserializeNetwork(xmlReader);

            // add your xml deserialization methods here
        }

        public override Node Clone()
        {
            return new NW_ClashTest(HostCanvas)
            {
                Top = Top,
                Left = Left
            };
        
        }
    }

}