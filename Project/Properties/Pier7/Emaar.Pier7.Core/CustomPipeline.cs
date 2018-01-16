using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sitecore.Data.Items;
using Sitecore.Pipelines;
namespace Emaar.Core
{
    /// <summary>
    /// 	<CustomPipeline>
  ///<processor type = "Emaar.Core.DateSet, Emaar.Core" />
  ///< processor type="Emaar.Core.TextSet, Emaar.Core"/>
///</CustomPipeline>
    /// </summary>
    public class CustomPipelineArgs : PipelineArgs
    {
        private bool m_valid = false;
        private string m_message = string.Empty;
        private Item m_item = null;

        public bool Valid
        {
            get { return m_valid; }
            set { m_valid = value; }
        }

        public string Message
        {
            get { return m_message; }
            set { m_message = value; }
        }

        public Item Item
        {
            get { return m_item; }
            set { m_item = value; }
        }

        public CustomPipelineArgs(Item item)
        {
            m_item = item;
        }
    }


    interface ICustomPipelineProcessor
    {
        void Process(CustomPipelineArgs args);
    }
    //Events
    public class DateSet : ICustomPipelineProcessor
    {
        public void Process(CustomPipelineArgs args)
        {
            if (args.Item["date"] == string.Empty)
            {
                args.Valid = false;
                args.Message = "im dataset";
            }

        }
    }

    public class TextSet : ICustomPipelineProcessor
    {
        public void Process(CustomPipelineArgs args)
        {
            if (args.Item["text"] == string.Empty)
            {
                args.Valid = false;
                args.Message = "im text";
            }
        }
    }
}
