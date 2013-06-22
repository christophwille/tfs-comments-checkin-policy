using System;
using System.Collections.Generic;
using System.Text;

namespace CCCPLib.Extensibility
{
    public interface ICheckCodeCommentsHost
    {
        void ReportError(string offendingClass, string offendingElement, int offendingLine);
        void ReportError(string offendingError);
    }
}
