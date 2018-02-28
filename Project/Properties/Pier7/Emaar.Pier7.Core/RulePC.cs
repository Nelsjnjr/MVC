using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sitecore.Analytics;
using Sitecore.Diagnostics;
using Sitecore.Rules;
using Sitecore.Rules.Conditions;
using Sitecore.Rules.Actions;
using Sitecore.SecurityModel;

namespace Emaar.Core
{
    public class CheckspecificTemplate<T> : StringOperatorCondition<T> where T : RuleContext
    {
        public string Value { get; set; }

        protected override bool Execute(T ruleContext)
        {
            var itemTemplateName = ruleContext.Item.TemplateName;
            return Compare(itemTemplateName, Value);
        }
    }

    public class SetNewTitle<T> : RuleAction<T> where T : RuleContext
    {


        public override void Apply(T ruleContext)
        {
            using (new SecurityDisabler())
            {
                ruleContext.Item.Editing.BeginEdit();
                ruleContext.Item["Title"] = "Title1";
                ruleContext.Item.Editing.EndEdit();
            }
        }


    }
}



