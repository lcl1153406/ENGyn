﻿using System.Windows.Controls;
using System.Xml;
using Autodesk.Navisworks.Api;
using TUM.CMS.VplControl.Nodes;
using TUM.CMS.VplControl.Core;
using System.Windows.Data;
using System.Collections.Generic;

namespace NW_GraphicPrograming.Nodes
{
    public class NW_GetSelection : Node
    {
        public NW_GetSelection(VplControl hostCanvas)
            : base(hostCanvas)
        {
            AddInputPortToNode("NW Document", typeof(Document));
            AddOutputPortToNode("Selection", typeof(object));

            AddControlToNode(new Label { Content = "NW Get Selection" });

        }

        public override void Calculate()
        {

            Document doc = InputPorts[0].Data as Document;
            var sel = doc.CurrentSelection.SelectedItems;
            List<ModelItem> modelItems = new List<ModelItem>();
            foreach (var s in sel)
            {
                modelItems.Add(s);
            }
         OutputPorts[0].Data = modelItems;
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
            return new NW_ModelName(HostCanvas)
            {
                Top = Top,
                Left = Left
            };
        
        }
    }

}