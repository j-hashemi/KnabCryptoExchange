using Exchange.Command.Core;

namespace Exchange.Command.Commands
{
    public class FillDataFromServerCommand:BaseRequest<FillDataFromServerCommandResponse>
    {
        
    }

    public class FillDataFromServerCommandResponse : BaseResponse
    {
        public int TotalRecordAdded { get; set; }
    }
}