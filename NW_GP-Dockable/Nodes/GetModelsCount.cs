﻿using System.Windows.Controls;
using System.Xml;
using Autodesk.Navisworks.Api;
using TUM.CMS.VplControl.Nodes;
using TUM.CMS.VplControl.Core;
using System.Windows.Data;

namespace NW_GraphicPrograming.Nodes
{
    public class NW_CountOfModels : Node
    {
        public NW_CountOfModels(VplControl hostCanvas)
            : base(hostCanvas)
        {
            AddInputPortToNode("NW_Document", typeof(Document));
            AddOutputPortToNode("Navis Models Count", typeof(object));

            AddControlToNode(new Label { Content = "NW Models in file" });

        }

        public override void Calculate()
        {

            Document doc = InputPorts[0].Data as Document;
            OutputPorts[0].Data = doc.Models.Count;
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
            return new NW_CountOfModels(HostCanvas)
            {
                Top = Top,
                Left = Left
            };
        
        }
    }

}