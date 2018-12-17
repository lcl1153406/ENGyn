﻿using System.Windows.Controls;
using System.Xml;
using ColorTranslator = System.Drawing.ColorTranslator;
using Autodesk.Navisworks.Api;
using System.Text;
using Autodesk.Navisworks.Api.DocumentParts;
using TUM.CMS.VplControl.Core;
using System.Collections.Generic;
using Newtonsoft.Json;
using System;
using System.Xml.Serialization;
using System.IO;

using System.Windows;

namespace ENGyn.Nodes.Appearance
{
    public class GetJsonProfileFromXML : Node
    {
        //TODO: read xml and convert to json profile
        #region Node class methods
        public GetJsonProfileFromXML(VplControl hostCanvas)
            : base(hostCanvas)
        {
            AddInputPortToNode("File path", typeof(string));
            AddOutputPortToNode("File path", typeof(string));
            //Help 
            this.BottomComment.Text = "Creates an Json version of the SearchSet xml to be read by SetAppearanceByProfile";
            this.ShowHelpOnMouseOver = true;
        }

        public override void Calculate()
        {
            string path = InputPorts[0].Data as string;
            
            if (path != null && File.Exists(path))
            {
                var exchange = Tools.readXML(path);
                Tools.convertXMLtoConfiguration(path.Replace(".xml", ".json"));
                pathFile = path.Replace(".xml", ".json");
            }
            OutputPorts[0].Data = pathFile;
        }

        public static string pathFile;
        public override Node Clone()
        {
            return new GetJsonProfileFromXML(HostCanvas)
            {
                Top = Top,
                Left = Left
            };

        }
        #endregion



    }

    }

