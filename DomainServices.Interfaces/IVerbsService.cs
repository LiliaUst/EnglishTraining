using System;
using System.Collections.Generic;
using System.Text;
using UstSoft.DataTransferObjects.Verbs;

namespace UstSoft.DomainServices.Interfaces
{
    public interface IVerbsService
    {
        VerbDto[] GetVerbs();
    }
}
