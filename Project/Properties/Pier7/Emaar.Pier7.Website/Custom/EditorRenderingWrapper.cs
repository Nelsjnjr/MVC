using Sitecore.Mvc.ExperienceEditor.Presentation;
using System.IO;

namespace Emaar.Pier7.Website.Custom
{
   public class EditorRenderingWrapper : Wrapper
   {
      public EditorRenderingWrapper(TextWriter writer, IMarker marker)
          : base(writer, marker)
      {
      }
   }
}