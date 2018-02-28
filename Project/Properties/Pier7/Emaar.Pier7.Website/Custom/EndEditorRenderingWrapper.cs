using System;
using System.Linq;
using Sitecore.Mvc.Pipelines.Response.RenderRendering;

namespace Emaar.Pier7.Website.Custom
{
   public class EndEditorRenderingWrapper : RenderRenderingProcessor
   {
      public override void Process(RenderRenderingArgs args)
      {
         foreach (IDisposable wrapper in args.Disposables.OfType<EditorRenderingWrapper>())
         {
            wrapper.Dispose();
         }
      }
   }
}