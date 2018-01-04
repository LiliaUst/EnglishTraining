using UstSoft.DataTransferObjects.Verbs;

namespace UstSoft.DomainServices.Interfaces
{
    public interface IVerbsService
    {
        VerbDto[] GetVerbs();
        VerbSaveResult SaveVerb(VerbDto verbDto);
    }
}
